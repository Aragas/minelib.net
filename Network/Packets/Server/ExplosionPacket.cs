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
            X = stream.ReadDouble();
            Y = stream.ReadDouble();
            Z = stream.ReadDouble();
            Radius = stream.ReadFloat();
            RecordCount = stream.ReadInt();
            Records = stream.ReadByteArray(RecordCount * 3);
            PlayerMotionX = stream.ReadFloat();
            PlayerMotionY = stream.ReadFloat();
            PlayerMotionZ = stream.ReadFloat();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteDouble(X);
            stream.WriteDouble(Y);
            stream.WriteDouble(Z);
            stream.WriteFloat(Radius);
            stream.WriteInt(RecordCount);
            stream.WriteByteArray(Records);
            stream.WriteFloat(PlayerMotionX);
            stream.WriteFloat(PlayerMotionY);
            stream.WriteFloat(PlayerMotionZ);
            stream.Purge();
        }
    }
}