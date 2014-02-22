using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ConfirmTransactionPacket : IPacket
    {
        public byte WindowId;
        public short ActionNumber;
        public bool Accepted;

        public const byte PacketId = 0x32;
        public byte Id { get { return 0x32; } }

        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.readByte();
            ActionNumber = stream.readShort();
            Accepted = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeByte(WindowId);
            stream.writeShort(ActionNumber);
            stream.writeBool(Accepted);
            stream.Purge();
        }
    }
}