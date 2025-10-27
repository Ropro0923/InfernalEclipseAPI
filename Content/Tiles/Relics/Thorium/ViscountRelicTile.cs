using System;
using InfernalEclipseAPI.Content.Items.Placeables.Relics.Thorium;
using InfernumMode.Content.Tiles.Relics;

namespace InfernalEclipseAPI.Content.Tiles.Relics.Thorium
{
    public class ViscountRelicTile : BaseInfernumBossRelic
    {
        public override int DropItemID => ModContent.ItemType<ViscountRelic>();

        public override string RelicTextureName => "InfernalEclipseAPI/Content/Tiles/Relics/Thorium/ViscountRelicTile";
    }
}
