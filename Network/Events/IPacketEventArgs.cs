using System;
using MinecraftClient.Network.Packets;

namespace MinecraftClient.Network.Events
{
    public class IPacketEventArgs : EventArgs
    {
        public IPacket Packet { get; set; }

        public IPacketEventArgs(IPacket packet)
        {
            Packet = packet;
        }

    }

}
