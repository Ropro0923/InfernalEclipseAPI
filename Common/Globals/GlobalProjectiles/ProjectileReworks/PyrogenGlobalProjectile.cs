using Terraria.DataStructures;
using CalamityMod.Buffs.DamageOverTime;
using InfernalEclipseAPI.Core.Systems;
using Clamity.Content.Bosses.Pyrogen.Projectiles;

namespace InfernalEclipseAPI.Common.GlobalProjectiles.ProjectileReworks
{
    [JITWhenModsEnabled(InfernalCrossmod.Clamity.Name)]
    [ExtendsFromMod(InfernalCrossmod.Clamity.Name)]
    public class PyrogenGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public bool applyDebuff = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            /*
            if (projectile.type == ModContent.ProjectileType<FireBarrage>() || projectile.type == ModContent.ProjectileType<FireBarrageHoming>())
            {
                projectile.damage = 80;
                applyDebuff = true;
            }

            if (projectile.type == ModContent.ProjectileType<Fireblast>())
            {
                projectile.damage = 130;
                applyDebuff = true;
            }

            if (projectile.type == ModContent.ProjectileType<FireBomb>() || projectile.type == ModContent.ProjectileType<Firethrower>())
            {
                projectile.damage = 70;
                applyDebuff = true;
            }

            if (projectile.type == ModContent.ProjectileType<FireBombExplosion>())
            {
                projectile.damage = 100;
                applyDebuff = true;
            }
            */
        }

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            // Helper: check if projectile matches a Clamity projectile internal name
            bool IsClamityProj(string name)
            {
                return InfernalCrossmod.Clamity.Mod.Find<ModProjectile>(name)?.Type == projectile.type;
            }

            int intendedDamage = 0;
            bool applyDebuff = false;

            if (IsClamityProj("FireBarrage") || IsClamityProj("FireBarrageHoming"))
            {
                intendedDamage = 80;
                applyDebuff = true;
            }
            else if (IsClamityProj("Fireblast"))
            {
                intendedDamage = 130;
                applyDebuff = true;
            }
            else if (IsClamityProj("FireBomb") || IsClamityProj("Firethrower"))
            {
                intendedDamage = 70;
                applyDebuff = true;
            }
            else if (IsClamityProj("FireBombExplosion"))
            {
                intendedDamage = 100;
                applyDebuff = true;
            }
            else
            {
                return;
            }

            if (info.Damage < intendedDamage)
            {
                target.Hurt(PlayerDeathReason.ByProjectile(target.whoAmI, projectile.whoAmI), intendedDamage, 0);
            }

            if (applyDebuff)
            {
                target.AddBuff(ModContent.BuffType<BrimstoneFlames>(), 180);
            }
        }
    }
}
