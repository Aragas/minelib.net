using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Client
{
    public struct ClientStatusPacket : IPacket
    {
        public ClientStatus Status;

        public const byte PacketId = 0x16;
        public byte Id { get { return 0x16; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Status = (ClientStatus)stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteByte((byte)Status);
            stream.Purge();
        }
    }
}