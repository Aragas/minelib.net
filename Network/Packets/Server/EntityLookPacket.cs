using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityLookPacket : IPacket
    {
        public int EntityID;
        public byte Yaw, Pitch;

        public const byte PacketId = 0x16;
        public byte Id { get { return 0x16; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.ReadInt();
            Yaw = stream.ReadByte();
            Pitch = stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EntityID);
            stream.WriteByte(Yaw);
            stream.WriteByte(Pitch);
            stream.Purge();
        }
    }
}