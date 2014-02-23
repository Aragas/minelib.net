using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ChunkDataPacket : IPacket
    {
        public int X, Z;
        public bool GroundUpContinuous;
        public short PrimaryBitMap;
        public short AddBitMap;
        public byte[] Data; // Maybe NbtByteArray?

        public const byte PacketId = 0x21;
        public byte Id { get { return 0x21; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.ReadShort();
            Z = stream.ReadShort();
            GroundUpContinuous = stream.ReadBool();
            PrimaryBitMap = stream.ReadShort();
            AddBitMap = stream.ReadShort();
            var length = stream.ReadShort();
            Data = stream.ReadByteArray(length);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteVarInt(X);
            stream.WriteVarInt(Z);
            stream.WriteBool(GroundUpContinuous);
            stream.WriteShort(PrimaryBitMap);
            stream.WriteShort(AddBitMap);
            stream.WriteVarInt(Data.Length);
            stream.WriteByteArray(Data);
            stream.Purge();
        }
    }
}