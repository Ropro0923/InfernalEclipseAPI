using InfernalEclipseAPI.Content.Items.Placeables.Relics.CalamityAddons;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.CalamityAddons
{
    public class AstrageldonRelicTile : BaseInfernumBossRelic
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return !ModLoader.TryGetMod("CnI", out _);
        }
        public override int DropItemID => ModContent.ItemType<AstrageldonRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/CalamityAddons/AstrageldonRelicTile";
    }
}
