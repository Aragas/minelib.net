using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct BlockActionPacket : IPacket
    {
        public int X;
        public short Y;
        public int Z;
        public byte Byte1;
        public byte Byte2;
        public int BlockType;

        public const byte PacketId = 0x24;
        public byte Id { get { return 0x24; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readInt();
            Y = stream.readShort();
            Z = stream.readInt();
            Byte1 = stream.readByte();
            Byte2 = stream.readByte();
            BlockType = stream.readVarInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(X);
            stream.writeShort(Y);
            stream.writeInt(Z);
            stream.writeByte(Byte1);
            stream.writeByte(Byte2);
            stream.writeVarInt(BlockType);
            stream.Purge();
        }
    }
}