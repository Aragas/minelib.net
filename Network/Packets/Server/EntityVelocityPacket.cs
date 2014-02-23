using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityVelocityPacket : IPacket
    {
        public int EntityID;
        public short VelocityX, VelocityY, VelocityZ;

        public const byte PacketId = 0x12;
        public byte Id { get { return 0x12; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.ReadInt();
            VelocityX = stream.ReadShort();
            VelocityY = stream.ReadShort();
            VelocityZ = stream.ReadShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EntityID);
            stream.WriteShort(VelocityX);
            stream.WriteShort(VelocityY);
            stream.WriteShort(VelocityZ);
            stream.Purge();
        }
    }
}