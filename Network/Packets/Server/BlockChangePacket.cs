using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct BlockChangePacket : IPacket
    {
        public int X;
        public byte Y;
        public int Z;
        public int BlockID;
        public byte BlockMetadata;

        public const byte PacketId = 0x23;
        public byte Id { get { return 0x23; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readInt();
            Y = stream.readByte();
            Z = stream.readInt();
            BlockID = stream.readVarInt();
            BlockMetadata = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(X);
            stream.writeByte(Y);
            stream.writeInt(Z);
            stream.writeVarInt(BlockID);
            stream.writeByte(BlockMetadata);
            stream.Purge();
        }
    }
}