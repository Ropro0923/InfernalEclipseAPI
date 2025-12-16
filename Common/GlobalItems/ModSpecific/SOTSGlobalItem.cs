using System.Collections.Generic;
using CalamityMod;
using InfernalEclipseAPI.Core.Utils;
using SOTS;
using SOTS.Buffs.MinionBuffs;
using SOTS.FakePlayer;
using SOTS.Items.Celestial;
using Terraria.Localization;

namespace InfernalEclipseAPI.Common.GlobalItems.ModSpecific
{
    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            SOTSPlayer sotsPlayer = SOTSPlayer.ModPlayer(player);

            if (InfernalConfig.Instance.SOTSBalanceChanges)
            {
                if (item.type == ModContent.ItemType<SubspaceLocket>())
                {
                    ref StatModifier local = ref player.GetDamage(DamageClass.Generic);
                    local *= 0.675f;
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
