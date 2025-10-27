using System.IO;
using InfernalEclipseAPI.Core.Systems;

namespace InfernalEclipseAPI.Common
{
    public class MusicNetcode
    {
        public enum InfernalEclipseMusicMessageType : byte
        {
            MusicEventSyncRequest,
            MusicEventSyncResponse
        }

        public static void HandlePacket(Mod mod, BinaryReader reader, int whoAmI)
        {
            try
            {
                InfernalEclipseMusicMessageType msgType = (InfernalEclipseMusicMessageType)reader.ReadByte();
                switch (msgType)
                {
                    case InfernalEclipseMusicMessageType.MusicEventSyncRequest:
                        {
                            MusicEventSystem.FulfillSyncRequest(whoAmI);
                            break;
                        }

                    case InfernalEclipseMusicMessageType.MusicEventSyncResponse:
                        {
                            MusicEventSystem.ReceiveSyncResponse(reader);
                            break;
                        }

                    default:
                        {
                            InfernalEclipseAPI.Instance.Logger.Error($"Failed to parse IEoR packet: No IEoR packet exists with ID {msgType}.");
                            throw new Exception("Failed to parse IEoR packet: Invalid IEoR packet ID.");
                        }
                }
            }
            catch (Exception e)
            {
                if (e is EndOfStreamException eose)
                {
                    InfernalEclipseAPI.Instance.Logger.Error("Failed to parse IEoR packet: Packet was too short, missing data, or otherwise corrupt.", eose);
                }
                else if (e is ObjectDisposedException ode)
                {
                    InfernalEclipseAPI.Instance.Logger.Error("Failed to parse IEoR packet: Packet reader disposed or destroyed.", ode);
                }
                else if (e is IOException ioe)
                {
                    InfernalEclipseAPI.Instance.Logger.Error("Failed to parse IEoR packet: An unknown I/O error occurred.", ioe);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
