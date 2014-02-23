using MinecraftClient.Enums;
using MinecraftClient.Events;
using MinecraftClient.Network.Packets;

namespace MinecraftClient.Network
{
    public partial class NetworkHandler
    {
        public event PacketsHandler OnPacketHandled;

        private void RaisePacketHandled(object sender, IPacket packet, int id, ServerState state)
        {
            if (OnPacketHandled != null)
                OnPacketHandled(sender, packet, id, state);
        }
    }
}
