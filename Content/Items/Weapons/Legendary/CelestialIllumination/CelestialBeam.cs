using InfernalEclipseAPI.Core.DamageClasses.LegendaryClass;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;

namespace InfernalEclipseAPI.Content.Items.Weapons.Legendary.CelestialIllumination
{
    public class CelestialBeam : ModProjectile
    {
        public override string Texture => "CalamityMod/Projectiles/Boss/ProvidenceHolyRayNight";
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = ModContent.GetInstance<LegendaryMagic>();
            Projectile.timeLeft = 2;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = false;
            Projectile.localNPCHitCooldown = 3;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            float startAngle = Projectile.ai[0];
            float targetAngle = Projectile.ai[1];

            float lifetime = 50f;
            float progress = 1f - (Projectile.timeLeft / lifetime);
            progress = MathHelper.Clamp(progress, 0f, 1f);

            // Smoothstep easing
            float easedProgress = 0.5f - 0.5f * (float)Math.Cos(progress * Math.PI);
            float currentAngle = MathHelper.Lerp(startAngle, targetAngle, easedProgress);

            // Position & rotation
            Projectile.Center = player.Center + Vector2.UnitX.RotatedBy(currentAngle) * 8f;
            Projectile.velocity = Projectile.Center.DirectionFrom(player.Center);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Laser scan length
            float[] array = new float[3];
            Collision.LaserScan(Projectile.Center, Projectile.velocity, Projectile.scale, 800f, array);
            float avgLength = (array[0] + array[1] + array[2]) / 3f;
            Projectile.localAI[1] = MathHelper.Lerp(Projectile.localAI[1], avgLength, 0.5f);

            // Continuous beam projectiles
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.NewProjectile(
                    Projectile.GetSource_FromAI(),
                    Projectile.Center,
                    Projectile.velocity * 8,
                    ModContent.ProjectileType<CelestialBeam>(),
                    Projectile.damage,
                    Projectile.knockBack,
                    Projectile.owner
                );
            }
        }
    }
}