using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityRelativeMovePacket : IPacket
    {
        public int EntityID;
        public sbyte DeltaX, DeltaY, DeltaZ;

        public const byte PacketId = 0x15;
        public byte Id { get { return 0x15; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            DeltaX = stream.readSByte();
            DeltaY = stream.readSByte();
            DeltaZ = stream.readSByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeSByte(DeltaX);
            stream.writeSByte(DeltaY);
            stream.writeSByte(DeltaZ);
            stream.Purge();
        }
    }
}