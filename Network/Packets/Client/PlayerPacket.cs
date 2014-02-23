using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct PlayerPacket : IPacket
    {
        public bool OnGround;

        public const byte PacketId = 0x0A;
        public byte Id { get { return 0x0A; } }

        public void ReadPacket(ref Wrapped stream)
        {
            OnGround = stream.ReadBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteBool(OnGround);
            stream.Purge();
        }
    }
}