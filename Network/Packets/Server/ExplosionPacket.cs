using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ExplosionPacket : IPacket
    {
        public double X, Y, Z;
        public float Radius;
        public int RecordCount;
        public byte[] Records;
        public float PlayerMotionX, PlayerMotionY, PlayerMotionZ;

        public const byte PacketId = 0x27;
        public byte Id { get { return 0x27; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readDouble();
            Y = stream.readDouble();
            Z = stream.readDouble();
            Radius = stream.readFloat();
            RecordCount = stream.readInt();
            Records = stream.readByteArray(RecordCount * 3);
            PlayerMotionX = stream.readFloat();
            PlayerMotionY = stream.readFloat();
            PlayerMotionZ = stream.readFloat();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeDouble(X);
            stream.writeDouble(Y);
            stream.writeDouble(Z);
            stream.writeFloat(Radius);
            stream.writeInt(RecordCount);
            stream.writeByteArray(Records);
            stream.writeFloat(PlayerMotionX);
            stream.writeFloat(PlayerMotionY);
            stream.writeFloat(PlayerMotionZ);
            stream.Purge();
        }
    }
}