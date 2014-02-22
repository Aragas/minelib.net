using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct HeldItemChangePacket : IPacket
    {
        public short Slot;

        public const byte PacketId = 0x09;
        public byte Id { get { return 0x09; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Slot = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeShort(Slot);
            stream.Purge();
        }
    }
}