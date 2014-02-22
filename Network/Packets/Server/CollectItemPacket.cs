using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct CollectItemPacket : IPacket
    {
        public int CollectedEntityID;
        public int CollectorEntityID;

        public const byte PacketId = 0x0D;
        public byte Id { get { return 0x0D; } }

        public void ReadPacket(ref Wrapped stream)
        {
            CollectedEntityID = stream.readInt();
            CollectorEntityID = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(CollectedEntityID);
            stream.writeInt(CollectorEntityID);
            stream.Purge();
        }
    }
}