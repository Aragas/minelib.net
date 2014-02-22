using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct SteerVehiclePacket : IPacket
    {
        public float Strafe;
        public float Forward;
        public bool Jump;
        public bool Unmount;

        public const byte PacketId = 0x1B;
        public byte Id { get { return 0x1B; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Strafe = stream.readFloat();
            Forward = stream.readFloat();
            Jump = stream.readBool();
            Unmount = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeFloat(Strafe);
            stream.writeFloat(Forward);
            stream.writeBool(Jump);
            stream.writeBool(Unmount);
            stream.Purge();
        }
    }
}