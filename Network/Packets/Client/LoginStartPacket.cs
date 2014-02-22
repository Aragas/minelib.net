using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct LoginStartPacket : IPacket
    {
        public string Name;

        public const byte PacketId = 0x00;
        public byte Id { get { return 0x00; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Name = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(Name);
            stream.Purge();
        }
    }
}