using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct RemoveEntityEffectPacket : IPacket
    {
        public int EntityID;
        public byte EffectID;

        public const byte PacketId = 0x1E;
        public byte Id { get { return 0x1E; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.ReadInt();
            EffectID = stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EntityID);
            stream.WriteByte(EffectID);
            stream.Purge();
        }
    }
}