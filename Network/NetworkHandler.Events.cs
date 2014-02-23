using MinecraftClient.Network.Packets;

namespace MinecraftClient.Network
{
    public partial class NetworkHandler
    {
        public event PacketHandler OnPacketHandled;

        public void RaisePacketHandled(object sender, IPacket packet, int id)
        {
            if (OnPacketHandled != null)
                OnPacketHandled(sender, packet, id);
        }
    }
}
