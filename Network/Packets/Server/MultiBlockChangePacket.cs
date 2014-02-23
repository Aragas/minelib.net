using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct MultiBlockChangePacket : IPacket
    {
        public int ChunkX, ChunkZ;
        public short RecordCount;
        public byte[] Data;

        public const byte PacketId = 0x22;
        public byte Id { get { return 0x22; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ChunkX = stream.ReadInt();
            ChunkZ = stream.ReadInt();
            RecordCount = stream.ReadShort();
            int length = stream.ReadInt();
            Data = stream.ReadByteArray(length);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(ChunkX);
            stream.WriteInt(ChunkZ);
            stream.WriteShort(RecordCount);
            stream.WriteInt(RecordCount * 4);
            stream.WriteByteArray(Data);
            stream.Purge();
        }
    }
}