using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct PlayerPositionAndLookPacket : IPacket
    {
        public double X, Y, Z;
        public float Yaw, Pitch;
        public bool OnGround;

        public const byte PacketId = 0x08;
        public byte Id { get { return 0x08; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readDouble();
            Y = stream.readDouble();
            Z = stream.readDouble();
            Yaw = stream.readFloat();
            Pitch = stream.readFloat();
            OnGround = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeDouble(X);
            stream.writeDouble(Y);
            stream.writeDouble(Z);
            stream.writeFloat(Yaw);
            stream.writeFloat(Pitch);
            stream.writeBool(OnGround);
            stream.Purge();
        }
    }
}