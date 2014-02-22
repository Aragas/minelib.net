using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct TabCompletePacket : IPacket
    {
        public int Count;
        public string Text;

        public const byte PacketId = 0x3A;
        public byte Id { get { return 0x3A; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Count = stream.readVarInt();
            Text = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(Count);
            stream.writeString(Text);
            stream.Purge();
        }
    }
}