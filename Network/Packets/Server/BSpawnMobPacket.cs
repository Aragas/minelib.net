using CWrapped;
using MinecraftClient.Data;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SpawnMobPacket : IPacket
    {
        public int EntityID;
        public Mobs Type;
        public int X, Y, Z;
        public byte Pitch, HeadPitch, Yaw;
        public short VelocityX, VelocityY, VelocityZ;
        public MetadataDictionary Metadata;
    
        public const byte PacketId = 0x0F;
        public byte Id { get { return 0x0F; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            Type = (Mobs)stream.readVarInt();
            X = stream.readShort();
            Y = stream.readShort();
            Z = stream.readShort();
            Pitch = stream.readByte();
            HeadPitch = stream.readByte();
            Yaw = stream.readByte();
            VelocityX = stream.readShort();
            VelocityY = stream.readShort();
            VelocityZ = stream.readShort();
            //Metadata = MetadataDictionary.FromStream(stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeVarInt((byte)Type);
            stream.writeVarInt(X);
            stream.writeVarInt(Y);
            stream.writeVarInt(Z);
            stream.writeVarInt(Pitch);
            stream.writeVarInt(HeadPitch);
            stream.writeVarInt(Yaw);
            stream.writeShort(VelocityX);
            stream.writeShort(VelocityY);
            stream.writeShort(VelocityZ);
            //Metadata.WriteTo(stream);
            stream.Purge();
        }
    }
}