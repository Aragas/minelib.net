using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ChatMessagePacket : IPacket
    {
        public string Message;

        public const byte PacketId = 0x02;
        public byte Id { get { return 0x02; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Message = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(Message);
            stream.Purge();
        }
    }
}