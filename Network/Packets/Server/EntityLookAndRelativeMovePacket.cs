using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityLookAndRelativeMovePacket : IPacket
    {
        public int EntityID;
        public sbyte DeltaX, DeltaY, DeltaZ;
        public byte Yaw, Pitch;

        public const byte PacketId = 0x17;
        public byte Id { get { return 0x17; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            DeltaX = stream.readSByte();
            DeltaY = stream.readSByte();
            DeltaZ = stream.readSByte();
            Yaw = stream.readByte();
            Pitch = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeSByte(DeltaX);
            stream.writeSByte(DeltaY);
            stream.writeSByte(DeltaZ);
            stream.writeByte(Yaw);
            stream.writeByte(Pitch);
            stream.Purge();
        }
    }
}