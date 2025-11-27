using InfernalEclipseAPI.Core.World;
using CalamityMod.NPCs.BrimstoneElemental;
using CalamityMod.NPCs.AquaticScourge;
using CalamityMod.NPCs.Yharon;
using InfernalEclipseAPI.Content.Items.Placeables.Paintings;
using CalamityMod.Items.Placeables.Furniture.DevPaintings;
using Terraria.GameContent.ItemDropRules;
using InfernalEclipseAPI.Core.Systems;
using System.Collections.Generic;
using InfernumMode.Core.GlobalInstances.Systems;
using CalamityMod.World;

namespace InfernalEclipseAPI.Common.GlobalNPCs
{
    public class InfernalGlobalNPC : GlobalNPC
    {
        public override void SetDefaults(NPC entity)
        {
            if (InfernalCrossmod.Thorium.Loaded)
            {
                if (entity.buffImmune[BuffID.Confused])
                {
                    entity.buffImmune[InfernalCrossmod.Thorium.Mod.Find<ModBuff>("Stunned").Type] = true;
                }
            }

            switch (entity.type)
            {
                case NPCID.DetonatingBubble:
                    if (WorldSaveSystem.InfernumModeEnabled && Main.masterMode && CalamityWorld.revenge && NPC.AnyNPCs(NPCID.DukeFishron))
                        entity.dontTakeDamage = false;
                    break;
                default:
                    break;
            }
        }

        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.TheDestroyer)
            {
                InfernalWorld.dreadonDestroyerDialoguePlayed = false;
                InfernalWorld.dreadonDestroyer2DialoguePlayed = false;
            }
            if (npc.type == NPCID.Plantera)
            {
                InfernalWorld.jungleSubshockPlanteraDialoguePlayed = false;
                InfernalWorld.jungleSlagspitterPlateraDiaglougePlayer = false;
            }
            if (npc.type == ModContent.NPCType<BrimstoneElemental>() || npc.type == ModContent.NPCType<AquaticScourgeHead>())
            {
                InfernalWorld.sulfurScourgeDialoguePlayed = false;
                InfernalWorld.brimstoneDialoguePlayed = false;
            }
            if (npc.type == ModContent.NPCType<Yharon>())
            {
                InfernalWorld.yharonDischarge = false;
                InfernalWorld.yharonSmasher = false;
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.boss) //anything that is considered a boss will have a 1/100 chance to drop our dev painting directly
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<InfernalTwilight>(), ThankYouPainting.DropInt));
            }
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.Player;
            if (InfernalCrossmod.SOTS.Loaded)
            {
                if (player.ZoneHallow && Main.hardMode && !twoMechsDowned())
                {
                    pool.Remove(InfernalCrossmod.SOTS.Mod.Find<ModNPC>("HallowTreasureSlime").Type);
                }
            }
        }

        public static bool twoMechsDowned()
        {
            return (NPC.downedMechBoss1 && NPC.downedMechBoss2) || (NPC.downedMechBoss1 && NPC.downedMechBoss3) || (NPC.downedMechBoss2 && NPC.downedMechBoss3);
        }

        public override bool CheckDead(NPC npc)
        {
            if (npc.type == NPCID.TheDestroyer)
            {
                InfernalWorld.dreadonDestroyerDialoguePlayed = false;
                InfernalWorld.dreadonDestroyer2DialoguePlayed = false;
            }
            if (npc.type == NPCID.Plantera)
            {
                InfernalWorld.jungleSubshockPlanteraDialoguePlayed = false;
                InfernalWorld.jungleSlagspitterPlateraDiaglougePlayer = false;
            }
            if (npc.type == ModContent.NPCType<BrimstoneElemental>() || npc.type == ModContent.NPCType<AquaticScourgeHead>())
            {
                InfernalWorld.sulfurScourgeDialoguePlayed = false;
                InfernalWorld.brimstoneDialoguePlayed = false;
            }

            return base.CheckDead(npc);
        }
        public override bool InstancePerEntity => true;
    }
}
