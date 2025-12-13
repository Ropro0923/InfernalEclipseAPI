using CalamityMod.Systems;
using CalamityMod.World;
using InfernalEclipseAPI.Core.Netcode;
using InfernalEclipseAPI.Core.World;
using InfernumMode.Core.GlobalInstances.Systems;
using InfernumMode.Core.Netcode;
using InfernumMode.Core.Netcode.Packets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using static CalamityMod.Systems.DifficultyModeSystem;
using static Terraria.GameContent.Creative.CreativePowers;

namespace InfernalEclipseAPI.Content.UI
{
    public class RagnarokDifficulty : DifficultyMode
    {
        public override bool Enabled
        {
            get => InfernalWorld.RagnarokModeEnabled;
            set
            {
                InfernalWorld.RagnarokModeEnabled = value;

                if (value)
                {
                    WorldSaveSystem.InfernumModeEnabled = true;
                    CalamityWorld.revenge = true;

                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        if (Main.GameModeInfo.IsJourneyMode)
                        {
                            float journeyDiff = 1f;
                            var slider = CreativePowerManager.Instance.GetPower<DifficultySliderPower>();
                            typeof(DifficultySliderPower).GetMethod("SetValueKeyboardForced", LumUtils.UniversalBindingFlags).Invoke(slider, [journeyDiff]);
                        }
                        else if (Main.GameMode != GameModeID.Master)
                        {
                            Main.GameMode = GameModeID.Master;

                            Main.NewText(Language.GetTextValue("Mods.InfernalEclipseAPI.DifficultyUI.MasterToggle"), new Color(175, 75, 255));
                        }
                    }
                    else
                    {
                        var netMessage = InfernalEclipseAPI.Instance.GetPacket();
                        netMessage.Write((byte)InfernalEclipseMessageType.ToggleRagnarok);
                        netMessage.Write((byte)Main.LocalPlayer.whoAmI);
                        netMessage.Send();
                    }
                }

                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    var netMessage = InfernalEclipseAPI.Instance.GetPacket();
                    netMessage.Write((byte)InfernalEclipseMessageType.SyncRagnarokState);
                    netMessage.Write(InfernalWorld.RagnarokModeEnabled);
                    netMessage.Send();

                    PacketManager.SendPacket<InfernumModeActivityPacket>();

                    NetMessage.SendData(MessageID.WorldData); //extra safety
                }
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
            ChatTextColor = new Color(196, 62, 0);
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
