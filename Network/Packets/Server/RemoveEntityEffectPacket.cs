using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct RemoveEntityEffectPacket : IPacket
    {
        public int EntityID;
        public sbyte EffectID;

        public const byte PacketId = 0x1E;
        public byte Id { get { return 0x1E; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            EffectID = stream.readSByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeSByte(EffectID);
            stream.Purge();
        }
    }
}