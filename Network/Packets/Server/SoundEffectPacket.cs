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
            SoundName = stream.readString();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
            Volume = stream.readFloat();
            Pitch = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(SoundName);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.writeFloat(Volume);
            stream.writeByte(Pitch);
            stream.Purge();
        }
    }
}