using System.IO;
using InfernalEclipseAPI.Core.World;
using InfernumMode.Core.Netcode.Packets;

namespace InfernalEclipseAPI.Core.Netcode
{
    public class RagnarokModeActivityPacket : BaseInfernumPacket
    {
        public override void Write(ModPacket packet, params object[] context)
        {
            BitsByte flags = new()
            {
                [0] = InfernalWorld.RagnarokModeEnabled
            };

            packet.Write(flags);
        }

        public override void Read(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            InfernalWorld.RagnarokModeEnabled = flags[0];
        }
    }
}
