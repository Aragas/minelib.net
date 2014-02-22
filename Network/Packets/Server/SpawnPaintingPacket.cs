using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SpawnPaintingPacket : IPacket
    {
        public int EntityID;
        public string Title;
        public int X, Y, Z;
        public int Direction;

        public const byte PacketId = 0x10;
        public byte Id { get { return 0x10; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            Title = stream.readString();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
            Direction = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeString(Title);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.writeInt(Direction);
            stream.Purge();
        }
    }
}