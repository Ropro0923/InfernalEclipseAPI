using System.Runtime.CompilerServices;
using RevengeancePlus.Projectiles;
using Terraria.DataStructures;

namespace InfernalEclipseAPI.Core.Systems.BossChanges
{
    [JITWhenModsEnabled(InfernalCrossmod.SOTS.Name, InfernalCrossmod.RevengeancePlus.Name)]
    [ExtendsFromMod(InfernalCrossmod.SOTS.Name, InfernalCrossmod.RevengeancePlus.Name)]
    public class PutridPinkyNerf : ModSystem
    {
        private readonly ConditionalWeakTable<NPC, Holder> last = new();
        private class Holder { public float ai1; public float ai0; }

        public override void PostUpdateNPCs()
        {
            foreach (var npc in Main.npc)
            {
                if (npc == null || !npc.active) continue;

                var mn = npc.ModNPC;
                if (mn == null || mn.Mod?.Name != "SOTS" || mn.GetType().Name != "PutridPinkyPhase2")
                    continue;

                if (!last.TryGetValue(npc, out var h))
                    last.Add(npc, h = new Holder { ai0 = npc.ai[0], ai1 = npc.ai[1] });

                // Expected vanilla: ai[1] ticks down ~1 per frame in phases 1 & 3.
                bool affectedPhase = npc.ai[0] == 1f || npc.ai[0] == 3f;
                float delta = h.ai1 - npc.ai[1]; // positive when time was fast-forwarded

                if (affectedPhase && delta > 1f && delta <= 120f && Main.netMode != Terraria.ID.NetmodeID.MultiplayerClient)
                {
                    // Undo the extra so net change is -1
                    npc.ai[1] += (delta - 1f);
                    npc.netUpdate = true;
                }

                // Undo the 210 -> 1/60 jump if it happened this tick
                if (affectedPhase && h.ai1 == 210f && (npc.ai[1] == 1f || npc.ai[1] == 60f) && Main.netMode != Terraria.ID.NetmodeID.MultiplayerClient)
                {
                    npc.ai[1] = 209f; // proceed naturally next tick
                    npc.netUpdate = true;
                }

                h.ai0 = npc.ai[0];
                h.ai1 = npc.ai[1];
            }
        }
    }

    [JITWhenModsEnabled(InfernalCrossmod.SOTS.Name, InfernalCrossmod.RevengeancePlus.Name)]
    [ExtendsFromMod(InfernalCrossmod.SOTS.Name, InfernalCrossmod.RevengeancePlus.Name)]
    public class PinkBombNerf : GlobalProjectile
    {
        private bool _fromPP2 = false;
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Projectile projectile, bool lateInstantiation) => projectile.type == ModContent.ProjectileType<PinkBomb>();

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is EntitySource_Parent p && p.Entity is NPC npc)
            {
                var mn = npc.ModNPC;
                if (mn != null &&
                    string.Equals(mn.Mod?.Name, "SOTS", StringComparison.Ordinal) &&
                    string.Equals(mn.GetType().Name, "PutridPinkyPhase2", StringComparison.Ordinal))
                {
                    _fromPP2 = true;
                    projectile.ai[1] = 6f;
                    projectile.velocity *= 0.75f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        projectile.netUpdate = true;
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (!_fromPP2) return;

            // keep it fixed at 6 in case other logic tries to mutate it later
            if (projectile.ai[1] != 6f)
                projectile.ai[1] = 6f;

            if (Main.netMode != NetmodeID.MultiplayerClient)
                projectile.netUpdate = true;
        }
    }
}
