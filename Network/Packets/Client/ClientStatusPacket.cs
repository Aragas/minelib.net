using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Client
{
    public struct ClientStatusPacket : IPacket
    {
        public ClientStatus Status;

        public const byte PacketId = 0xCD;
        public byte Id { get { return 0xCD; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Status = (ClientStatus)stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt((byte)Status);
            stream.Purge();
        }
    }
}