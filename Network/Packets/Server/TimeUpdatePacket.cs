using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct TimeUpdatePacket : IPacket
    {
        public long AgeOfTheWorld, TimeOfDay;

        public const byte PacketId = 0x03;
        public byte Id { get { return 0x03; } }

        public void ReadPacket(ref Wrapped stream)
        {
            AgeOfTheWorld = stream.readLong();
            TimeOfDay = stream.readLong();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeLong(AgeOfTheWorld);
            stream.writeLong(TimeOfDay);
            stream.Purge();
        }
    }
}