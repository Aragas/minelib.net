using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct UseBedPacket : IPacket
    {
        public int EntityID;
        public int X;
        public byte Y;
        public int Z;

        public const byte PacketId = 0x0A;
        public byte Id { get { return 0x0A; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            X = stream.readInt();
            Y = stream.readByte();
            Z = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeInt(X);
            stream.writeVarInt(Y);
            stream.writeInt(Z);
            stream.Purge();
        }
    }
}