using System.Collections.Generic;
using CalamityMod;
using InfernalEclipseAPI.Core.Players;
using InfernalEclipseAPI.Core.Utils;
using SOTS;
using SOTS.Buffs.MinionBuffs;
using SOTS.FakePlayer;
using SOTS.Items;
using SOTS.Items.Celestial;
using SOTS.Items.CritBonus;
using SOTS.Items.Earth.Glowmoth;
using SOTS.Items.Planetarium.FromChests;
using SOTS.Items.Pyramid;
using Terraria.GameContent.RGB;
using Terraria.Localization;

namespace InfernalEclipseAPI.Common.GlobalItems.ModSpecific
{
    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            InfernalPlayer modPlayer = player.GetModPlayer<InfernalPlayer>();
            SOTSPlayer sotsPlayer = SOTSPlayer.ModPlayer(player);

            if (InfernalConfig.Instance.SOTSBalanceChanges)
            {
                if (item.type == ModContent.ItemType<SubspaceLocket>())
                {
                    ref StatModifier local = ref player.GetDamage(DamageClass.Generic);
                    local *= 0.675f;
                }

                if (item.type == ModContent.ItemType<EyeOfChaos>())
                {
                    player.GetCritChance(DamageClass.Generic) -= 18f;
                    modPlayer.eyeOfChaos = true;
                }

                if (item.type == ModContent.ItemType<SnakeEyes>())
                {
                    player.GetCritChance(DamageClass.Generic) -= 7f;
                    modPlayer.snakeEyes = true;
                }

                if (item.type == ModContent.ItemType<ChaosBadge>())
                {
                    player.GetCritChance(DamageClass.Generic) -= 9f;
                    modPlayer.chaosBadge = true;
                }

                if (item.type == ModContent.ItemType<FocusReticle>())
                {
                    player.GetCritChance(DamageClass.Generic) -= 20f;
                    modPlayer.focusReticle = true;
                }

                if (item.type == ModContent.ItemType<Starbelt>())
                {
                    player.GetCritChance(DamageClass.Magic) -= 5f;
                }

                if (item.type == ModContent.ItemType<GlowSpores>())
                {
                    player.GetCritChance(DamageClass.Magic) -= 3f;
                }

                if (item.type == ModContent.ItemType<SpiritGlove>())
                {
                    player.GetCritChance(DamageClass.Melee) -= 4f;
                }

                if (item.type == ModContent.ItemType<SwallowedPenny>())
                {
                    player.GetCritChance(DamageClass.Generic) -= 2f;
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (InfernalConfig.Instance.SOTSBalanceChanges)
            {
                if (item.type == ModContent.ItemType<SubspaceLocket>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.SubspaceLocket"));
                }

                if (item.type == ModContent.ItemType<EyeOfChaos>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.EyeOfChaos"));
                }

                if (item.type == ModContent.ItemType<SnakeEyes>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.SnakeEyes"));
                }

                if (item.type == ModContent.ItemType<ChaosBadge>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.ChaosBadge"));
                }

                if (item.type == ModContent.ItemType<FocusReticle>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.FocusReticle"));
                }

                if (item.type == ModContent.ItemType<Starbelt>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.Starbelt"));
                }

                if (item.type == ModContent.ItemType<GlowSpores>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.GlowSpores"));
                }

                if (item.type == ModContent.ItemType<SpiritGlove>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.SpiritGlove"));
                }

                if (item.type == ModContent.ItemType<SwallowedPenny>())
                {
                    InfernalUtilities.FullTooltipOveride(tooltips, Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.SwallowedPenny"));
                }
            }
        }
    }

    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSModPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (FakeModPlayer.ModPlayer(Player).servantActive == true || Player.HasBuff<TesseractBuff>())
            {
                Player.Calamity().rogueStealthMax = 0;
                Player.Calamity().wearingRogueArmor = false;
            }
        }
    }
}
