using CalamityMod.Systems;
using CalamityMod.World;
using InfernumMode.Core.GlobalInstances.Systems;
using InfernumMode.Core.Netcode;
using InfernumMode.Core.Netcode.Packets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Localization;
using static CalamityMod.Systems.DifficultyModeSystem;

namespace InfernalEclipseAPI.Content.UI
{
    public class RagnarokDifficulty : DifficultyMode
    {
        public override bool Enabled
        {
            get => WorldSaveSystem.InfernumModeEnabled && Main.masterMode;
            set
            {
                if (value)
                {
                    CalamityWorld.revenge = true;
                    Main.GameMode = GameModeID.Master;
                }
                if (Main.netMode != NetmodeID.SinglePlayer)
                    PacketManager.SendPacket<InfernumModeActivityPacket>();
            }
        }

        private Asset<Texture2D> _texture;
        public override Asset<Texture2D> Texture
        {
            get
            {
                _texture ??= ModContent.Request<Texture2D>("InfernalEclipseAPI/Assets/RagnarokIcon");

                return _texture;
            }
        }

        public override LocalizedText ExpandedDescription => Language.GetText("Mods.InfernalEclipseAPI.DifficultyUI.ExpandedDescription");

        public RagnarokDifficulty()
        {
            DifficultyScale = 999999999f;
            Name = Language.GetText("Mods.InfernalEclipseAPI.DifficultyUI.Name");
            ShortDescription = Language.GetText("Mods.InfernalEclipseAPI.DifficultyUI.ShortDescription");

            ActivationTextKey = "Mods.InfernalEclipseAPI.DifficultyUI.InfernumText";
            DeactivationTextKey = "Mods.InfernalEclipseAPI.DifficultyUI.InfernumText2";

            ActivationSound = new("InfernalEclipseAPI/Assets/Sounds/NamelessDeityRageFail");
            ChatTextColor = Color.Lerp(Color.White, new Color(255, 80, 0), (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 2.0) * 0.5 + 0.5));
        }

        public override int FavoredDifficultyAtTier(int tier)
        {
            DifficultyMode[] tierList = DifficultyTiers[tier];

            for (int i = 0; i < tierList.Length; i++)
            {
                if (tierList[i].Name.Value == "Death")
                    return i;
            }

            return 0;
        }
    }
}
