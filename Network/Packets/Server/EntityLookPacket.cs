using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityLookPacket : IPacket
    {
        public int EntityID;
        public byte Yaw, Pitch;

        public const byte PacketId = 0x16;
        public byte Id { get { return 0x16; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            Yaw = stream.readByte();
            Pitch = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeByte(Yaw);
            stream.writeByte(Pitch);
            stream.Purge();
        }
    }
}