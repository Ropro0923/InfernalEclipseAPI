using System.Collections.Generic;
using InfernalEclipseAPI.Core.Systems;
using Microsoft.Xna.Framework;
using SOTS.WorldgenHelpers;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace InfernalEclipseAPI.Core.World
{
    [ExtendsFromMod(InfernalCrossmod.SOTS.Name)]
    [JITWhenModsEnabled(InfernalCrossmod.SOTS.Name)]
    public class AddImportantStructureBarriers : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            base.ModifyWorldGenTasks(tasks, ref totalWeight);

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

        public static Rectangle ToWorldCoords(Rectangle rectangle)
        {
            return new Rectangle(rectangle.X * 16, rectangle.Y * 16, rectangle.Width * 16, rectangle.Height * 16);
        }
    }
}
