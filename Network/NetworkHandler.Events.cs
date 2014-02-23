using MinecraftClient.Enums;
using MinecraftClient.Network.Packets;

namespace MinecraftClient.Network
{
    public partial class NetworkHandler
    {
        public event PacketHandler OnPacketHandled;

        private void RaisePacketHandled(object sender, IPacket packet, int id, ServerState state)
        {
            if (OnPacketHandled != null)
                OnPacketHandled(sender, packet, id, state);
        }
    }
}
