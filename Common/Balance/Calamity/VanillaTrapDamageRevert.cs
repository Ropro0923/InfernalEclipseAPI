namespace InfernalEclipseAPI.Common.Balance.Calamity
{
    public class VanillaTrapDamageRevert : ModPlayer
    {
        public override void ModifyHitByProjectile(Projectile proj, ref Terraria.Player.HurtModifiers modifiers)
        {
            ref StatModifier sourceDamage = ref modifiers.SourceDamage;

            if (proj.type == ProjectileID.Explosives)
            {
                sourceDamage /= Main.expertMode ? 0.225f : 0.35f;
            }
            else if (proj.type == ProjectileID.RollingCactus || proj.type == ProjectileID.RollingCactusSpike)
            {
                sourceDamage /= Main.expertMode ? 0.3f : 0.5f;
            }

            if (!Main.expertMode)
                return;

            if (proj.type == ProjectileID.Boulder || proj.type == ProjectileID.MiniBoulder)
            {
                sourceDamage /= 0.65f;
            }
            else if (proj.type == ProjectileID.SpikyBallTrap || proj.type == ProjectileID.FlamethrowerTrap || proj.type == ProjectileID.PoisonDartTrap)
            {
                sourceDamage /= 0.625f;
            }
            else if (proj.type == ProjectileID.SpearTrap)
            {
                sourceDamage /= 0.6f;
            }
        }

    }
}
