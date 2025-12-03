using ThoriumMod;
using ThoriumMod.Projectiles;
using CalamityMod.Projectiles.Melee;

namespace InfernalEclipseAPI.Common.GlobalProjectiles
{
    [ExtendsFromMod("ThoriumMod")]
    public class ProjectileToThoriumWeaponClass : GlobalProjectile
    {
        public override void SetDefaults(Projectile entity)
        {
            if (!InfernalConfig.Instance.ChanageWeaponClasses) return;

            if (entity.type == ModContent.ProjectileType<AncientFirePro>() || entity.type == ModContent.ProjectileType<AncientFirePro2>() || entity.type == ModContent.ProjectileType<BurningMeteor>())
            {
                entity.DamageType = ThoriumDamageBase<HealerDamage>.Instance;
            }
        }
    }
}
