using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct PlayerListItemPacket : IPacket
    {
        public string PlayerName;
        public bool Online;
        public short Ping;

        public const byte PacketId = 0x38;
        public byte Id { get { return 0x38; } }

        public void ReadPacket(ref Wrapped stream)
        {
            PlayerName = stream.readString();
            Online = stream.readBool();
            Ping = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(PlayerName);
            stream.writeBool(Online);
            stream.writeShort(Ping);
            stream.Purge();
        }
    }
}