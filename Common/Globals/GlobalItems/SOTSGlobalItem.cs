using InfernalEclipseAPI.Core.Systems;
using SOTS;
using SOTS.Items.Earth;
using ThoriumMod.Items.BossMini;

namespace InfernalEclipseAPI.Common.Globals.GlobalItems
{
    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSGlobalItem : GlobalItem
    {
        public override void UpdateAccessory(Item item, Player player, bool hidevisual)
        {
            if (item.type == ModContent.ItemType<HarvestersScythe>())
            {
                SOTSPlayer.ModPlayer(player).CritBonusMultiplier -= 0.15f;
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
