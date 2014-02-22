using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityHeadLookPacket : IPacket
    {
        public int EntityID;
        public byte HeadYaw;

        public const byte PacketId = 0x19;
        public byte Id { get { return 0x19; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            HeadYaw = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeByte(HeadYaw);
            stream.Purge();
        }
    }
}