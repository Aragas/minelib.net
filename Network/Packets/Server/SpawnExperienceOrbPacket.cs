using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SpawnExperienceOrbPacket : IPacket
    {
        public int EntityID;
        public int X, Y, Z;
        public short Count;

        public const byte PacketId = 0x11;
        public byte Id { get { return 0x11; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.ReadVarInt();
            X = stream.ReadInt();
            Y = stream.ReadInt();
            Z = stream.ReadInt();
            Count = stream.ReadShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteVarInt(EntityID);
            stream.WriteInt(X);
            stream.WriteInt(Y);
            stream.WriteInt(Z);
            stream.WriteShort(Count);
            stream.Purge();
        }
    }
}