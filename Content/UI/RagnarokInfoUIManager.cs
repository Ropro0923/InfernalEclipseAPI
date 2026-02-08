using System.Collections.Generic;
using InfernalEclipseAPI.Core.World;
using Luminance.Core.MenuInfoUI;
using Terraria.ModLoader.IO;

namespace InfernalEclipseAPI.Content.UI
{
    public class RagnarokWorldIconManager: ModSystem
    {
        public override void SaveWorldHeader(TagCompound tag)
        {
            tag["RagnarokWorld"] = InfernalWorld.RagnarokModeEnabled;
        }
    }

    public class RagnarokInfoUIManager : InfoUIManager
    {
        public static bool RagnarokWorld(TagCompound tag) => tag.ContainsKey("RagnarokWorld") && tag.GetBool("RagnarokWorld");
        public override IEnumerable<WorldInfoIcon> GetWorldInfoIcons()
        {
            yield return new WorldInfoIcon(
                RagnarokIconPath,
                "Mods.InfernalEclipseAPI.UI.RagnarokIconText",
                worldFileData =>
                {
                    if (worldFileData.TryGetHeaderData<RagnarokWorldIconManager>(out TagCompound tag))
                        if (RagnarokWorld(tag))
                            return true;
                    return false;
                },
                byte.MaxValue);
        }

        internal static string RagnarokIconPath => "InfernalEclipseAPI/Assets/ExtraTextures/UI/RagnarokIcon";
    }
}
