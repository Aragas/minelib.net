using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct UpdateSignPacket : IPacket
    {
        public int X;
        public short Y;
        public int Z;
        public string Line1, Line2, Line3, Line4;

        public const byte PacketId = 0x33;
        public byte Id { get { return 0x33; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readInt();
            Y = stream.readShort();
            Z = stream.readInt();
            Line1 = stream.readString();
            Line2 = stream.readString();
            Line3 = stream.readString();
            Line4 = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(X);
            stream.writeShort(Y);
            stream.writeInt(Z);
            stream.writeString(Line1);
            stream.writeString(Line2);
            stream.writeString(Line3);
            stream.writeString(Line4);
            stream.Purge();
        }
    }
}