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
            EffectID = stream.ReadInt();
            X = stream.ReadInt();
            Y = stream.ReadByte();
            Z = stream.ReadInt();
            Data = stream.ReadInt();
            DisableRelativeVolume = stream.ReadBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EffectID);
            stream.WriteInt(X);
            stream.WriteByte(Y);
            stream.WriteInt(Z);
            stream.WriteInt(Data);
            stream.WriteBool(DisableRelativeVolume);
            stream.Purge();
        }
    }
}