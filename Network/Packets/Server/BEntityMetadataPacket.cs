using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct BEntityMetadataPacket : IPacket
    {
        public int EntityID;
        public MetadataDictionary Metadata;
    
        public const byte PacketId = 0x1C;
        public byte Id { get { return 0x1C; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.ReadInt();
            Metadata = MetadataDictionary.FromStream(ref stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EntityID);
            Metadata.WriteTo(ref stream);
            stream.Purge();
        }
    }
}