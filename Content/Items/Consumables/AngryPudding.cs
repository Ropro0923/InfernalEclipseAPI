using System.Collections.Generic;
using CalamityMod;
using InfernalEclipseAPI.Core.Systems;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace InfernalEclipseAPI.Content.Items.Consumables
{
    public class AngryPudding : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[]
            {
            new Color(180, 112, 82),
            new Color(205, 133, 81),
            new Color(255, 139, 190),
            new Color(255, 224, 96)
            };

            ItemID.Sets.IsFood[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToFood(58, 36, -1, 60 * 10);
        }

        public override bool? UseItem(Player player)
        {
            player.AddBuff(BuffID.PotionSickness, player.pStone ? 25 : 30);
            if (InfernalCrossmod.NoxusBoss.Loaded)
            {
                player.AddBuff(InfernalCrossmod.NoxusBoss.Mod.Find<ModBuff>("StarstrikinglySatiated").Type, 36000);
            }
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "DedItem", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.Contributor"))
            {
                OverrideColor = new Microsoft.Xna.Framework.Color(50, 205, 50)
            });

            TooltipLine dedTo = new TooltipLine(Mod, "Dedicated", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.DedTo", Language.GetTextValue("Mods.InfernalEclipseAPI.ItemTooltip.Dedicated.Pudding")));
            //dedTo.OverrideColor = new Color(196, 35, 44);
            dedTo.OverrideColor = new Color(50, 205, 50);
            CalamityUtils.HoldShiftTooltip(tooltips, new TooltipLine[] { dedTo });
        }
    }
}
