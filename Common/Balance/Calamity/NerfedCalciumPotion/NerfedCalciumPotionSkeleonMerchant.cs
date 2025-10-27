using CalamityMod.Items.Potions;

namespace InfernalEclipseAPI.Common.Balance.Calamity.NerfedCalciumPotion;

public class NerfedCalciumPotionSkeletonMerchant : GlobalNPC
{
    public override void ModifyShop(NPCShop shop)
    {
        NPCShop.Entry entry;
        if (!InfernalConfig.Instance.CalamityBalanceChanges || shop.NpcType != 453 || !shop.TryGetEntry(ModContent.ItemType<CalciumPotion>(), out entry))
            return;
        entry.Disable();
    }
}