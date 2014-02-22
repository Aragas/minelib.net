using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct WindowPropertyPacket : IPacket
    {
        public byte WindowId;
        public short PropertyId;
        public short Value;

        public const byte PacketId = 0x31;
        public byte Id { get { return 0x31; } }

        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.readByte();
            PropertyId = stream.readShort();
            Value = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeByte(WindowId);
            stream.writeShort(PropertyId);
            stream.writeShort(Value);
            stream.Purge();
        }
    }
}