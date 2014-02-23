using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SoundEffectPacket : IPacket
    {
        public string SoundName;
        public int X, Y, Z;
        public float Volume;
        public byte Pitch;

        public const byte PacketId = 0x29;
        public byte Id { get { return 0x29; } }

        public void ReadPacket(ref Wrapped stream)
        {
            SoundName = stream.ReadString();
            X = stream.ReadInt();
            Y = stream.ReadInt();
            Z = stream.ReadInt();
            Volume = stream.ReadFloat();
            Pitch = stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteString(SoundName);
            stream.WriteInt(X);
            stream.WriteInt(Y);
            stream.WriteInt(Z);
            stream.WriteFloat(Volume);
            stream.WriteByte(Pitch);
            stream.Purge();
        }
    }
}