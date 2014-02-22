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
            EntityID = stream.readShort();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
            Count = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.writeShort(Count);
            stream.Purge();
        }
    }
}