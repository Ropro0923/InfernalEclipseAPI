using System.Collections.Generic;
using InfernalEclipseAPI.Core.Systems;
using Microsoft.Xna.Framework;
using SOTS.WorldgenHelpers;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace InfernalEclipseAPI.Core.World
{
    public class WorldgenManagementSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            base.ModifyWorldGenTasks(tasks, ref totalWeight);

            if (InfernalCrossmod.SOTS.Loaded)
                SOTSWorldGenModifications.RunSOTSWorldGenMods(tasks);
        }

        public override void PostWorldGen()
        {
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    bool isContainer1 = Main.tile[chest.x, chest.y].TileType == TileID.Containers;
                    bool isGoldChest = isContainer1 && (Main.tile[chest.x, chest.y].TileFrameX == 36 || Main.tile[chest.x, chest.y].TileFrameX == 2 * 36); // Includes Locked Gold Chests

                    // Fix vanilla's stupidity with Gold Chests being able to have Meteorite Bars in them near the Underworld
                    if (isGoldChest)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == ItemID.MeteoriteBar)
                            {
                                int oldStack = chest.item[inventoryIndex].stack;
                                chest.item[inventoryIndex].SetDefaults(WorldGen.genRand.NextBool() ? ItemID.PlatinumBar : ItemID.GoldBar);
                                chest.item[inventoryIndex].stack = oldStack;
                            }
                        }
                    }
                }
            }
        }
    }

    [ExtendsFromMod(InfernalCrossmod.SOTS.Name)]
    [JITWhenModsEnabled(InfernalCrossmod.SOTS.Name)]
    public static class SOTSWorldGenModifications
    {
        public static void RunSOTSWorldGenMods(List<GenPass> tasks)
        {
            AddMutantModBarier(tasks);
        }

        private static void AddMutantModBarier(List<GenPass> tasks)
        {
            if (ModLoader.HasMod("SecretsOfTheSouls") || !InfernalCrossmod.FargosMutant.Loaded)
                return;

            int sanctIdx = tasks.FindIndex(p => p.Name == "SOTS: Sanctuary");
            if (sanctIdx == -1) return;

            tasks.Insert(sanctIdx + 1, new PassLegacy(
                "Add Sanctuary Indestructible Zone",
                (progress, config) =>
                {
                    progress.Message = "Protecting the Sanctuary";

                    Rectangle worldRect = SanctuaryWorldgenHelper.Rectangle.Modified(-2, -2, 4, 4);

                    if (worldRect.Width > 0 && worldRect.Height > 0)
                    {
                        string command = "AddIndestructibleRectangle";
                        InfernalCrossmod.FargosMutant.Mod.Call(command, ToWorldCoords(worldRect));
                    }
                }
            ));
        }

        private static Rectangle ToWorldCoords(Rectangle rectangle)
        {
            return new Rectangle(rectangle.X * 16, rectangle.Y * 16, rectangle.Width * 16, rectangle.Height * 16);
        }
    }
}
