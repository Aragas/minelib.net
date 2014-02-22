using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityEffectPacket : IPacket
    {
        public int EntityID;
        public byte EffectID;
        public byte Amplifier;
        public short Duration;

        public const byte PacketId = 0x1D;
        public byte Id { get { return 0x1D; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            EffectID = stream.readByte();
            Amplifier = stream.readByte();
            Duration = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeByte(EffectID);
            stream.writeByte(Amplifier);
            stream.writeShort(Duration);
            stream.Purge();
        }
    }
}