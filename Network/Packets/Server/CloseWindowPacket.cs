using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct CloseWindowPacket : IPacket
    {
        public byte WindowID;

        public const byte PacketId = 0x2E;
        public byte Id { get { return 0x2E; } }

        public void ReadPacket(ref Wrapped stream)
        {
            WindowID = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeByte(WindowID);
            stream.Purge();
        }
    }
}