using System.Collections.Generic;
using System.Reflection;
using CalamityMod;
using CalamityMod.Items;
using CalamityMod.Rarities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.DataStructures;
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

    public class StreetsignPlayer : ModPlayer
    {
        public int improbabilityCharge;
        public bool fullyCharged;

        public override void PostUpdate()
        {
            if (fullyCharged)
            {
                Lighting.AddLight(Player.Center, 0.2f, 0.4f, 1.0f);
                if (Main.rand.NextBool(5))
                    Dust.NewDust(Player.Center, 10, 10, DustID.Electric, 0, 0, 150, Color.Cyan, 0.75f);
            }
        }
    }

    public class StreetsignChargeLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            var modPlayer = player.GetModPlayer<StreetsignPlayer>();

            if (player.HeldItem.ModItem is not Streetsign) return;
            if (modPlayer.improbabilityCharge <= 0) return;

            Texture2D barBG = ModContent.Request<Texture2D>("CalamityMod/UI/MiscTextures/GenericBarBack", AssetRequestMode.ImmediateLoad).Value;
            Texture2D barFG = ModContent.Request<Texture2D>("CalamityMod/UI/MiscTextures/GenericBarFront", AssetRequestMode.ImmediateLoad).Value;

            Vector2 barOrigin = barBG.Size() * 0.5f;
            float barScale = 0.95f;
            Vector2 drawPos = player.Top + Vector2.UnitY * (-16f) - Main.screenPosition;

            Rectangle frameCrop = new Rectangle(0, 0, (int)(modPlayer.improbabilityCharge / 100f * barFG.Width), barFG.Height);

            float t = (float)((Math.Sin(Main.GlobalTimeWrappedHourly * 2f) + 1f) / 2f);
            Color color = Color.Lerp(new Color(135, 206, 250), Color.Gold, t);

            Main.spriteBatch.Draw(barBG, drawPos, null, color, 0f, barOrigin, barScale, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(barFG, drawPos, frameCrop, color * 0.8f, 0f, barOrigin, barScale, SpriteEffects.None, 0f);
        }
    }

    public static class StreetsignDrawHelper
    {
        public static void DrawChargeBarInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, float charge, float scale)
        {
            if (charge <= 0f) return;

            Texture2D barBG = ModContent.Request<Texture2D>("CalamityMod/UI/MiscTextures/GenericBarBack", AssetRequestMode.ImmediateLoad).Value;
            Texture2D barFG = ModContent.Request<Texture2D>("CalamityMod/UI/MiscTextures/GenericBarFront", AssetRequestMode.ImmediateLoad).Value;

            Vector2 barOrigin = barBG.Size() * 0.5f;

            // Position below the item slot
            float yOffset = -8f;
            Vector2 drawPos = position + Vector2.UnitY * scale * ((float)frame.Height - yOffset);

            // Crop the foreground based on charge
            Rectangle frameCrop = new Rectangle(0, 0, (int)(charge / 5f * barFG.Width), barFG.Height);

            // Smooth lerp color (you can change to any color you like)
            float t = (float)((Math.Sin(Main.GlobalTimeWrappedHourly * 2f) + 1f) / 2f);
            Color color = Color.Lerp(new Color(135, 206, 250), Color.Gold, t);

            float barScale = 0.75f;

            // Draw background
            spriteBatch.Draw(barBG, drawPos, null, color, 0f, barOrigin, scale * barScale, SpriteEffects.None, 0f);
            // Draw foreground
            spriteBatch.Draw(barFG, drawPos, frameCrop, color * 0.8f, 0f, barOrigin, scale * barScale, SpriteEffects.None, 0f);
        }
    }

}
