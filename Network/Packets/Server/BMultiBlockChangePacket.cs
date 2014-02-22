using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct MultiBlockChangePacket : IPacket
    {
        public int ChunkX, ChunkZ;
        public short RecordCount;
        public int[] Data;

        public const byte PacketId = 0x22;
        public byte Id { get { return 0x22; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ChunkX = stream.readShort();
            ChunkZ = stream.readShort();
            RecordCount = stream.readShort();
            stream.readShort();
            //Data = stream.ReadInt32Array(RecordCount);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(ChunkX);
            stream.writeVarInt(ChunkZ);
            stream.writeShort(RecordCount);
            stream.writeVarInt(RecordCount * 4);
            //stream.writeVarIntArray(Data);
            stream.Purge();
        }
    }
}