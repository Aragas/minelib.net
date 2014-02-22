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
            EntityID = stream.readInt();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
            Yaw = stream.readByte();
            Pitch = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.writeByte(Yaw);
            stream.writeByte(Pitch);
            stream.Purge();
        }
    }
}