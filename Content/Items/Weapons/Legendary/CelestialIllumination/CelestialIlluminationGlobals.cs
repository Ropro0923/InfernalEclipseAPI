using Luminance.Common.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace InfernalEclipseAPI.Content.Items.Weapons.Legendary.CelestialIllumination
{
    public class CelestialIlluminationPlayer : ModPlayer
    {
        public int StarCount = 0;
        public const int MaxStars = 13;
        public override void OnRespawn()
        {
            StarCount = 0;
        }
        public override void OnHitNPCWithProj(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            CelestialIlluminationGlobalProjectile globalProj = projectile.GetGlobalProjectile<CelestialIlluminationGlobalProjectile>();
            if (projectile.type == ModContent.ProjectileType<CelestialIlluminationStar>() && StarCount < MaxStars && !globalProj.appliedCharge)
            {
                StarCount++;
                globalProj.appliedCharge = true;
            }
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            Texture2D StarTexture = ModContent.Request<Texture2D>($"{this.GetPath()}".Replace("Player", "StarMini")).Value;
            for (int i = 0; i < StarCount; i++)
            {
                Vector2 offset = new Vector2(0, -40).RotatedBy(MathHelper.ToRadians(360f / StarCount * i + Main.GlobalTimeWrappedHourly * 35));
                Main.EntitySpriteDraw(StarTexture, Player.Center - Main.screenPosition + offset, null, Color.White, 0f, StarTexture.Size() / 2, 1f, SpriteEffects.None, 0);
            }
            //    Main.EntitySpriteDraw(StarTexture);
        }
    }
    public class CelestialIlluminationStarReset : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.boss;
        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            foreach (Player player in Main.player)
            {
                if (!player.active || player is null)
                    continue;
                if (player.GetModPlayer<CelestialIlluminationPlayer>().StarCount is not 0 && !player.dead)
                    player.GetModPlayer<CelestialIlluminationPlayer>().StarCount = 0;
            }
        }
    }
    public class CelestialIlluminationGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool appliedCharge = false;
    }
}