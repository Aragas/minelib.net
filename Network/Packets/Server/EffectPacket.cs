using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EffectPacket : IPacket
    {
        public int EffectID;
        public int X;
        public byte Y;
        public int Z;
        public int Data;
        public bool DisableRelativeVolume;

        public const byte PacketId = 0x28;
        public byte Id { get { return 0x28; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EffectID = stream.readInt();
            X = stream.readInt();
            Y = stream.readByte();
            Z = stream.readInt();
            Data = stream.readInt();
            DisableRelativeVolume = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EffectID);
            stream.writeInt(X);
            stream.writeByte(Y);
            stream.writeInt(Z);
            stream.writeInt(Data);
            stream.writeBool(DisableRelativeVolume);
            stream.Purge();
        }
    }
}