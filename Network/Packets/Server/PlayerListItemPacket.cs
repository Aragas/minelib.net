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
            PlayerName = stream.ReadString();
            Online = stream.ReadBool();
            Ping = stream.ReadShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteString(PlayerName);
            stream.WriteBool(Online);
            stream.WriteShort(Ping);
            stream.Purge();
        }
    }
}