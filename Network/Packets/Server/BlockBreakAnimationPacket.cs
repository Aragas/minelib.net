using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct BlockBreakAnimationPacket : IPacket
    {
        public int EntityID;
        public int X, Y, Z;
        public sbyte DestroyStage;

        public const byte PacketId = 0x25;
        public byte Id { get { return 0x25; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readVarInt();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
            DestroyStage = stream.readSByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.writeSByte(DestroyStage);
            stream.Purge();
        }
    }
}