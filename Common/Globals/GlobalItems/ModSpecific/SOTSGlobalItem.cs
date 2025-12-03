using CalamityMod;
using InfernalEclipseAPI.Core.Systems;
using SOTS;
using SOTS.Items.ChestItems;
using SOTS.Items.Earth;
using SOTS.Items.Tide;

namespace InfernalEclipseAPI.Common.Globals.GlobalItems.ModSpecific
{
    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hidevisual)
        {
            SOTSPlayer sotsPlayer = SOTSPlayer.ModPlayer(player);

            if (item.type == ModContent.ItemType<HarvestersScythe>())
            {
                sotsPlayer.CritBonusMultiplier -= 0.15f;
            }

            if (item.type == ModContent.ItemType<RockCandy>())
            {
                sotsPlayer.bonusPickaxePower -= 1;
            }

            if (item.type == ModContent.ItemType<HydrokineticAntennae>())
            {
                sotsPlayer.StatShareMeleeAndSummon = false;
                player.GetDamage<TrueMeleeDamageClass>() -= 0.15f;
            }

            if (InfernalCrossmod.SOTSBardHealer.Loaded)
            {
                Mod sBH = InfernalCrossmod.SOTSBardHealer.Mod;
                int FindItem(string name) => sBH.Find<ModItem>(name).Type;

                if (item.type == FindItem("SerpentsTongue"))
                {
                    SOTSPlayer.ModPlayer(player).CritBonusMultiplier -= 0.1f;
                }
            }
        }
    }
}
