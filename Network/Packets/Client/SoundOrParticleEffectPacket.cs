using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct SoundOrParticleEffectPacket : IPacket
    {
        public int EntityID;
        public int X;
        public byte Y;
        public int Z;
        public int Data;
        public bool DisableRelativeVolume;

        public const byte PacketId = 0x3D;
        public byte Id { get { return 0x3D; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            X = stream.readShort();
            Y = stream.readByte();
            Z = stream.readShort();
            Data = stream.readShort();
            DisableRelativeVolume = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeVarInt(X);
            stream.writeVarInt(Y);
            stream.writeVarInt(Z);
            stream.writeVarInt(Data);
            stream.writeBool(DisableRelativeVolume);
            stream.Purge();
        }
    }
}