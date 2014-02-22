using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SpawnPlayerPacket : IPacket
    {
        public int EntityID;
        public string PlayerUUID, PlayerName;
        public int X, Y, Z;
        public byte Yaw, Pitch;
        public short CurrentItem;
        public MetadataDictionary Metadata;
    
        public const byte PacketId = 0x0C;
        public byte Id { get { return 0x0C; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            PlayerUUID = stream.readString();
            PlayerName = stream.readString();
            X = stream.readShort();
            Y = stream.readShort();
            Z = stream.readShort();
            Yaw = stream.readByte();
            Pitch = stream.readByte();
            CurrentItem = stream.readShort();
            //Metadata = MetadataDictionary.FromStream(stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeString(PlayerUUID);
            stream.writeString(PlayerName);
            stream.writeVarInt(X);
            stream.writeVarInt(Y);
            stream.writeVarInt(Z);
            stream.writeVarInt(Yaw);
            stream.writeVarInt(Pitch);
            stream.writeShort(CurrentItem);
            //Metadata.WriteTo(stream);
            stream.Purge();
        }
    }
}