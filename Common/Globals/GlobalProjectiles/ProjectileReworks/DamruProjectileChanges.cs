using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace InfernalEclipseAPI.Common.GlobalProjectiles.ProjectileReworks
{
    //Wardrobe Hummus
    public class DamruProjectileChanges : GlobalProjectile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return !ModLoader.TryGetMod("WHummusMultiModBalancing", out _);
        }
        public override bool InstancePerEntity => true;

        public override void PostDraw(Projectile projectile, Color lightColor)
        {
            if (projectile.ModProjectile != null &&
                projectile.ModProjectile.Mod.Name == "RagnarokMod" &&
                projectile.ModProjectile.Name == "AuricDamruShock")
            {
                Texture2D texture = TextureAssets.Projectile[projectile.type].Value;

                // Get the correct frame for animated projectiles
                Rectangle frame = texture.Frame(
                    1, Main.projFrames[projectile.type], 0, projectile.frame
                );

                Vector2 origin = frame.Size() / 2f;

                float lifeRatio = projectile.timeLeft / 60f;
                float fadeStrength = MathHelper.Clamp((float)Math.Sin(Math.PI * lifeRatio), 0f, 1f);
                Color fadedColor = lightColor * fadeStrength;
                float finalScale = projectile.scale * 1.75f;


                Main.EntitySpriteDraw(
                    texture,
                    projectile.Center - Main.screenPosition,
                    frame,
                    fadedColor,
                    projectile.rotation,
                    origin,
                    finalScale,
                    SpriteEffects.None,
                    0
                );
            }
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (projectile.ModProjectile != null &&
                projectile.ModProjectile.Mod.Name == "RagnarokMod" &&
                projectile.ModProjectile.Name == "AuricDamruFlareBomb")
            {
                Mod calamity = ModLoader.GetMod("CalamityMod");
                if (calamity != null)
                {
                    int meteorProjType = calamity.Find<ModProjectile>("BettyExplosion").Type;

                    Projectile.NewProjectile(
                        projectile.GetSource_Death(),
                        projectile.Center,
                        Microsoft.Xna.Framework.Vector2.Zero,
                        meteorProjType,
                        0,
                        0,
                        projectile.owner
                    );
                }
            }
        }

        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.ModProjectile != null &&
                projectile.ModProjectile.Mod.Name == "RagnarokMod" &&
                projectile.ModProjectile.Name == "AuricDamruShock")
            {
                return false;
            }

            return true;
        }
    }
}
