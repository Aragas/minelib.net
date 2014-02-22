using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct KeepAlivePacket : IPacket
    {
        public int KeepAlive;

        public const byte PacketId = 0x00;
        public byte Id { get { return 0x00; } }

        public void ReadPacket(ref Wrapped stream)
        {
            KeepAlive = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(KeepAlive);
            stream.Purge();
        }
    }
}