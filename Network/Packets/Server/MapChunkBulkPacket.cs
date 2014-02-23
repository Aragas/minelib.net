using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct MapChunkBulkPacket : IPacket
    {
        public short ChunkColumnCount;
        public bool SkyLightSent;
        public byte[] ChunkData;
        public Metadata[] MetaInformation;

        public const byte PacketId = 0x26;
        public byte Id { get { return 0x26; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ChunkColumnCount = stream.ReadShort();
            var length = stream.ReadShort();
            SkyLightSent = stream.ReadBool();
            ChunkData = stream.ReadByteArray(length);

            MetaInformation = new Metadata[ChunkColumnCount];
            for (int i = 0; i < ChunkColumnCount; i++)
            {
                var metadata = new Metadata();
                metadata.ChunkX = stream.ReadInt();
                metadata.ChunkZ = stream.ReadInt();
                metadata.PrimaryBitMap = stream.ReadShort();
                metadata.AddBitMap = stream.ReadShort();
                MetaInformation[i] = metadata;
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteShort(ChunkColumnCount);
            stream.WriteVarInt(ChunkData.Length);
            stream.WriteBool(SkyLightSent);
            stream.WriteByteArray(ChunkData);

            for (int i = 0; i < ChunkColumnCount; i++)
            {
                stream.WriteInt(MetaInformation[i].ChunkX);
                stream.WriteInt(MetaInformation[i].ChunkZ);
                stream.WriteShort(MetaInformation[i].PrimaryBitMap);
                stream.WriteShort(MetaInformation[i].AddBitMap);
            }
            stream.Purge();
        }
    }
}