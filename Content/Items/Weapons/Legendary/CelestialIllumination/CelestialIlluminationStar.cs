using InfernalEclipseAPI.Core.DamageClasses.LegendaryClass;
using Microsoft.Xna.Framework;

namespace InfernalEclipseAPI.Content.Items.Weapons.Legendary.CelestialIllumination
{
    public class CelestialIlluminationStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        //    ProjectileID.Sets.TrailCacheLength[Projectile.type] = 2;
        //    ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()  
        {
            Projectile.width = 46;
            Projectile.height = 46;
            Projectile.friendly = true;
            Projectile.penetrate = 5;
            Projectile.DamageType = ModContent.GetInstance<LegendaryMagic>();
            Projectile.timeLeft = 360;
            Projectile.friendly = true;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = height = 3;
            return true;
        }
        /*
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(texture.Width * 0.5f, Projectile.height * 0.5f);
            
            for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
            {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
        */
    }
}