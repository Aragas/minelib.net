using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct PlayerPositionPacket : IPacket
    {
        public double X, Y, Stance, Z;
        public bool OnGround;

        public const byte PacketId = 0x0B;
        public byte Id { get { return 0x0B; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readDouble();
            Y = stream.readDouble();
            Stance = stream.readDouble();
            Z = stream.readDouble();
            OnGround = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeDouble(X);
            stream.writeDouble(Y);
            stream.writeDouble(Stance);
            stream.writeDouble(Z);
            stream.writeBool(OnGround);
            stream.Purge();
        }
    }
}