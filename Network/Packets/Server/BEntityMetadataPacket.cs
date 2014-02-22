using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityMetadataPacket : IPacket
    {
        public int EntityID;
        public MetadataDictionary Metadata;
    
        public const byte PacketId = 0x1C;
        public byte Id { get { return 0x1C; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            //Metadata = MetadataDictionary.FromStream(stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            //Metadata.WriteTo(stream);
            stream.Purge();
        }
    }
}