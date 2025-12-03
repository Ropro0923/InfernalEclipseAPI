using System.Collections.Generic;
using System.Reflection;
using CalamityMod;
using CalamityMod.Items;
using CalamityMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.Localization;

namespace InfernalEclipseAPI.Content.Items.Weapons.Donor
{
    public class Streetsign : ModItem
    {
        private static bool VanillaShoot;
        private static readonly MethodInfo MiItemCheckShoot = typeof(Player).GetMethod("ItemCheck_Shoot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        public override void SetDefaults()
        {
            Item.damage = 3000;
            Item.DamageType = ModContent.GetInstance<TrueMeleeDamageClass>();

            Item.width = Item.height = 118;

            Item.useTime = Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.knockBack = 6f;

            Item.value = CalamityGlobalItem.RarityVioletBuyPrice;
            Item.rare = ModContent.RarityType<Violet>();
            Item.UseSound = SoundID.DD2_MonkStaffSwing;

            Item.Calamity().donorItem = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundImpact);
            base.OnHitNPC(player, target, hit, damageDone);
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            var state = player.GetModPlayer<BladeSwingState>();

            if (player.itemAnimation == player.itemAnimationMax)
            {
                state.swingDirection *= -1;
                state.pendingShoot = true;
            }

            state.useDirection = (Main.MouseWorld.X >= player.Center.X) ? 1 : -1;
            player.direction = state.useDirection;

            state.useRotation = player.Center.AngleTo(Main.MouseWorld);

            float x = 1f - (float)player.itemAnimation / player.itemAnimationMax;
            float lerp = x < 0.5f ? 4f * x * x * x : 1f - (float)Math.Pow(-2f * x + 2f, 3) / 2f;

            float arcMult = 1f;
            if (player.itemAnimationMax > 20)
                arcMult += 0.4f * (player.itemAnimationMax - 20) / 30f;
            arcMult = MathHelper.Clamp(arcMult, 1f, 1.3f);

            float arcStart = -110f * arcMult;
            float arcEnd = 90f * arcMult;

            player.itemRotation =
                state.useRotation
                + MathHelper.ToRadians(state.useDirection == 1 ? 45 : 135)
                + MathHelper.ToRadians(
                    MathHelper.Lerp(arcStart, arcEnd, state.swingDirection == 1 ? lerp : 1f - lerp)
                    * state.useDirection);

            if (player.gravDir == -1f)
                player.itemRotation = -player.itemRotation;

            if (state.pendingShoot && player.itemAnimation == player.itemAnimationMax)
            {
                state.pendingShoot = false;
                VanillaShoot = true;
                MiItemCheckShoot?.Invoke(player, new object[] { player.whoAmI, Item, player.GetWeaponDamage(Item) });
                VanillaShoot = false;
            }

            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full,
                player.itemRotation + MathHelper.ToRadians(-135f * state.useDirection));
            player.itemLocation = player.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full,
                player.itemRotation + MathHelper.ToRadians(-135f * state.useDirection));

            base.UseStyle(player, heldItemFrame);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedTo = new TooltipLine(Mod, "Dedicated", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.DedTo", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.Dedicated.rose")));
            dedTo.OverrideColor = new Color(196, 35, 44);
            CalamityUtils.HoldShiftTooltip(tooltips, new TooltipLine[] { dedTo });
        }
    }

    public sealed class BladeSwingState : ModPlayer
    {
        public int swingDirection = 1;
        public int useDirection = 1;
        public float useRotation = 0f;
        public bool pendingShoot = false;

        public override void ResetEffects()
        {
        }
    }
}
