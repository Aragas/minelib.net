using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityPacket : IPacket
    {
        public int EntityID;

        public const byte PacketId = 0x14;
        public byte Id { get { return 0x14; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.Purge();
        }
    }
}