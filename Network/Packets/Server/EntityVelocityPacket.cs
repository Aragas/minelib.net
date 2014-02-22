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
            EntityID = stream.readInt();
            VelocityX = stream.readShort();
            VelocityY = stream.readShort();
            VelocityZ = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeShort(VelocityX);
            stream.writeShort(VelocityY);
            stream.writeShort(VelocityZ);
            stream.Purge();
        }
    }
}