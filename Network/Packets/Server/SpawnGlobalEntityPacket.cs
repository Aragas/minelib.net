using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SpawnGlobalEntityPacket : IPacket
    {
        public int EntityID;
        public sbyte Type;
        public int X, Y, Z;

        public const byte PacketId = 0x2C;
        public byte Id { get { return 0x2C; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            Type = stream.readSByte();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeSByte(Type);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.Purge();
        }
    }
}