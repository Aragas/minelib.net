using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct IncrementStatisticPacket : IPacket
    {
        public int StatisticId;
        public int Amount;

        public const byte PacketId = 0xC8;
        public byte Id { get { return 0xC8; } }

        public void ReadPacket(ref Wrapped stream)
        {
            StatisticId = stream.readShort();
            Amount = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(StatisticId);
            stream.writeVarInt(Amount);
            stream.Purge();
        }
    }
}