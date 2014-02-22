using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ParticlePacket : IPacket
    {
        public string ParticleName;
        public float X, Y, Z;
        public float OffsetX, OffsetY, OffsetZ;
        public float ParticleData;
        public int NumberOfParticles;

        public const byte PacketId = 0x2A;
        public byte Id { get { return 0x2A; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ParticleName = stream.readString();
            X = stream.readFloat();
            Y = stream.readFloat();
            Z = stream.readFloat();
            OffsetX = stream.readFloat();
            OffsetY = stream.readFloat();
            OffsetZ = stream.readFloat();
            ParticleData = stream.readFloat();
            NumberOfParticles = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(ParticleName);
            stream.writeFloat(X);
            stream.writeFloat(Y);
            stream.writeFloat(Z);
            stream.writeFloat(OffsetX);
            stream.writeFloat(OffsetY);
            stream.writeFloat(OffsetZ);
            stream.writeFloat(ParticleData);
            stream.writeInt(NumberOfParticles);
        }
    }
}