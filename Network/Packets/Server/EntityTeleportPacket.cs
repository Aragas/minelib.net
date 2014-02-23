using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityTeleportPacket : IPacket
    {
        public int EntityID;
        public int X, Y, Z;
        public byte Yaw, Pitch;

        public const byte PacketId = 0x18;
        public byte Id { get { return 0x18; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.ReadInt();
            X = stream.ReadInt();
            Y = stream.ReadInt();
            Z = stream.ReadInt();
            Yaw = stream.ReadByte();
            Pitch = stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EntityID);
            stream.WriteInt(X);
            stream.WriteInt(Y);
            stream.WriteInt(Z);
            stream.WriteByte(Yaw);
            stream.WriteByte(Pitch);
            stream.Purge();
        }
    }
}