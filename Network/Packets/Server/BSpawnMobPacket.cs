using CWrapped;
using MinecraftClient.Data;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct BSpawnMobPacket : IPacket
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
            EntityID = stream.ReadShort();
            Type = (Mobs)stream.ReadByte();
            X = stream.ReadInt();
            Y = stream.ReadInt();
            Z = stream.ReadInt();
            Pitch = stream.ReadByte();
            HeadPitch = stream.ReadByte();
            Yaw = stream.ReadByte();
            VelocityX = stream.ReadShort();
            VelocityY = stream.ReadShort();
            VelocityZ = stream.ReadShort();
            Metadata = MetadataDictionary.FromStream(ref stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteVarInt(EntityID);
            stream.WriteByte((byte)Type);
            stream.WriteInt(X);
            stream.WriteInt(Y);
            stream.WriteInt(Z);
            stream.WriteByte(Pitch);
            stream.WriteByte(HeadPitch);
            stream.WriteByte(Yaw);
            stream.WriteShort(VelocityX);
            stream.WriteShort(VelocityY);
            stream.WriteShort(VelocityZ);
            Metadata.WriteTo(ref stream);
            stream.Purge();
        }
    }
}