using CWrapped;
using MinecraftClient.BigData;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ChunkDataPacket : IPacket
    {
        public int X, Z;
        public bool GroundUpContinuous;
        public short PrimaryBitMap;
        public short AddBitMap;
        public byte[] Data; // Maybe NbtByteArray?
        public byte[] Trim;

        public const byte PacketId = 0x21;
        public byte Id { get { return 0x21; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.ReadInt();
            Z = stream.ReadInt();
            GroundUpContinuous = stream.ReadBool();
            PrimaryBitMap = stream.ReadShort();
            AddBitMap = stream.ReadShort();
            var length = stream.ReadInt(); // was short.
            Data = stream.ReadByteArray(length);

            Trim = new byte[length - 2];  
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(X);
            stream.WriteInt(Z);
            stream.WriteBool(GroundUpContinuous);
            stream.WriteShort(PrimaryBitMap);
            stream.WriteShort(AddBitMap);
            stream.WriteVarInt(Data.Length);
            stream.WriteByteArray(Data);
            stream.Purge();
        }
    }
}