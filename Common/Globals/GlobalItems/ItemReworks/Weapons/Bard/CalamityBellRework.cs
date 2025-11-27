using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using InfernalEclipseAPI.Content.Projectiles;

namespace InfernalEclipseAPI.Common.Globals.GlobalItems.ItemReworks.Weapons.Bard
{
    [ExtendsFromMod("ThoriumMod")]
    public class CalamityBellRework : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            try
            {
                if (ModLoader.TryGetMod("RagnarokMod", out Mod ragnarokMod))
                {
                    if (ragnarokMod.TryFind("CalamityBell", out ModItem calamityBell))
                    {
                        if (item.type == calamityBell.Type)
                        {
                            int projType = ModContent.ProjectileType<FriendlyBrimstoneFireblast>();
                            Projectile.NewProjectile(source, position, velocity, projType, damage, knockback, player.whoAmI);
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
    }
}
