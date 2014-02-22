using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ScoreboardObjectivePacket : IPacket
    {
        public string ObjectiveName;
        public string ObjectiveValue;
        public sbyte CreateRemove;

        public const byte PacketId = 0x3B;
        public byte Id { get { return 0x3B; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ObjectiveName = stream.readString();
            ObjectiveValue = stream.readString();
            CreateRemove = stream.readSByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(ObjectiveName);
            stream.writeString(ObjectiveValue);
            stream.writeSByte(CreateRemove);
            stream.Purge();
        }
    }
}