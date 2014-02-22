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
            ChunkColumnCount = stream.readShort();
            var length = stream.readShort();
            SkyLightSent = stream.readBool();
            //ChunkData = stream.ReadUInt8Array(length);

            MetaInformation = new Metadata[ChunkColumnCount];
            for (int i = 0; i < ChunkColumnCount; i++)
            {
                var metadata = new Metadata();
                metadata.ChunkX = stream.readShort();
                metadata.ChunkZ = stream.readShort();
                //metadata.PrimaryBitMap = stream.ReadUInt16();
                //metadata.AddBitMap = stream.ReadUInt16();
                MetaInformation[i] = metadata;
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeShort(ChunkColumnCount);
            stream.writeVarInt(ChunkData.Length);
            stream.writeBool(SkyLightSent);
            //stream.writeVarIntArray(ChunkData);

            for (int i = 0; i < ChunkColumnCount; i++)
            {
                stream.writeVarInt(MetaInformation[i].ChunkX);
                stream.writeVarInt(MetaInformation[i].ChunkZ);
                //stream.WriteUInt16(MetaInformation[i].PrimaryBitMap);
                //stream.WriteUInt16(MetaInformation[i].AddBitMap);
            }
            stream.Purge();
        }
    }
}