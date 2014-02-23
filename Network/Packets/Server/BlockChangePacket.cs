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
            X = stream.ReadInt();
            Y = stream.ReadByte();
            Z = stream.ReadInt();
            BlockID = stream.ReadVarInt();
            BlockMetadata = stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(X);
            stream.WriteByte(Y);
            stream.WriteInt(Z);
            stream.WriteVarInt(BlockID);
            stream.WriteByte(BlockMetadata);
            stream.Purge();
        }
    }
}