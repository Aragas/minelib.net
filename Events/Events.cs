using MinecraftClient.Enums;
using MinecraftClient.Network.Packets;

namespace MinecraftClient.Events
{
    public delegate void PacketsHandler(object sender, IPacket packet, int id, ServerState state);
    public delegate void PacketHandler(IPacket packet);

}
