using CalamityMod.Items.Potions;

namespace InfernalEclipseAPI.Common.Balance.Calamity.NerfedCalciumPotion;

public class NerfedCalciumPotionBuff : GlobalItem
{
    public override void SetDefaults(Item entity)
    {
        if (!InfernalConfig.Instance.CalamityBalanceChanges  || entity.type != ModContent.ItemType<CalciumPotion>())
            return;
        entity.buffTime = 18000;
    }
}