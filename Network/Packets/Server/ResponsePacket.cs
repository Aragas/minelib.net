using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ResponsePacket : IPacket
    {
        public string Response;

        public const byte PacketId = 0x00;
        public byte Id { get { return 0x00; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Response = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(Response);
            stream.Purge();
        }
    }
}