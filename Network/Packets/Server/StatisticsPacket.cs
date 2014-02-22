using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct StatisticsPacket : IPacket
    {
        public int Count;
        public string StatisticsName;
        public int Value;

        public const byte PacketId = 0x37;
        public byte Id { get { return 0x37; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Count = stream.readVarInt();
            StatisticsName = stream.readString();
            Value = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(Count);
            stream.writeString(StatisticsName);
            stream.writeInt(Value);
            stream.Purge();
        }
    }
}