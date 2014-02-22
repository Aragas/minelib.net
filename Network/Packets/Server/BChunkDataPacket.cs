using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ChunkDataPacket : IPacket
    {
        public int X, Z;
        public bool GroundUpContinuous;
        public ushort PrimaryBitMap;
        public ushort AddBitMap;
        public byte[] Data; // Maybe NbtByteArray?

        public const byte PacketId = 0x21;
        public byte Id { get { return 0x21; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readShort();
            Z = stream.readShort();
            GroundUpContinuous = stream.readBool();
            //PrimaryBitMap = stream.ReadUInt16();
            //AddBitMap = stream.ReadUInt16();
            var length = stream.readShort();
            //Data = stream.ReadUInt8Array(length);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(X);
            stream.writeVarInt(Z);
            stream.writeBool(GroundUpContinuous);
            //stream.WriteUInt16(PrimaryBitMap);
            //stream.WriteUInt16(AddBitMap);
            stream.writeVarInt(Data.Length);
            //stream.writeVarIntArray(Data);
            stream.Purge();
        }
    }
}