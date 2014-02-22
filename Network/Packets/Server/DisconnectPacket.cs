using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct DisconnectPacket : IPacket
    {
        public string Reason;

        public const byte PacketId = 0x40;
        public byte Id { get { return 0x40; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Reason = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(Reason);
            stream.Purge();
        }
    }
}