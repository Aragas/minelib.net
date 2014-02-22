using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct LoginSuccessPacket : IPacket
    {
        public string UUID, Username;

        public const byte PacketId = 0x02;
        public byte Id { get { return 0x02; } }

        public void ReadPacket(ref Wrapped stream)
        {
            UUID = stream.readString();
            Username = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(UUID);
            stream.writeString(Username);
            stream.Purge();
        }
    }
}