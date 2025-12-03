using CalamityMod.Projectiles.Boss;
using InfernumMode.Content.BehaviorOverrides.BossAIs.SupremeCalamitas;
using SOTS.Void;

namespace InfernalEclipseAPI.Common.GlobalNPCs.NPCDebuffs
{
    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class VoidDamageProjectile : GlobalProjectile
    {
        public bool canDoVoidDamage = false;
        public bool strongVoidDamge = false;
        public override bool InstancePerEntity => true;

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            if (projectile.type == ModContent.ProjectileType<SupremeCataclysmFist>() || projectile.type == ModContent.ProjectileType<SupremeCatastropheSlash>() || projectile.type == ModContent.ProjectileType<SupremeCataclysmFistOld>() || projectile.type == ModContent.ProjectileType<CatastropheSlash>()
                || canDoVoidDamage)
            {
                int damage = 1 + projectile.damage / (strongVoidDamge ? 3 : 6);
                VoidPlayer.VoidDamage(Mod, target, damage);
            }
        }
    }

    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class VoidDamageNPC : GlobalNPC
    {
        public bool canDoVoidDamage = false;
        public bool strongVoidDamge = false;
        public override bool InstancePerEntity => true;

        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo info)
        {
            if (canDoVoidDamage)
            {
                int damage = 1 + npc.damage / (strongVoidDamge ? 3 : 6);
                VoidPlayer.VoidDamage(Mod, target, damage);
            }
        }
    }
}
