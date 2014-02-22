using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct PlayerLookPacket : IPacket
    {
        public float Yaw, Pitch;
        public bool OnGround;

        public const byte PacketId = 0x0C;
        public byte Id { get { return 0x0C; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Yaw = stream.readFloat();
            Pitch = stream.readFloat();
            OnGround = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeFloat(Yaw);
            stream.writeFloat(Pitch);
            stream.writeBool(OnGround);
            stream.Purge();
        }
    }
}