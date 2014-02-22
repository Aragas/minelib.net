using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SpawnObjectPacket : IPacket
    {
        public int EntityID;
        public Objects Type;
        public int X, Y, Z;
        public int Data; // Maybe new data-type ObjectData?
        public short? SpeedX, SpeedY, SpeedZ;
        public byte Yaw, Pitch;

        public const byte PacketId = 0x0E;
        public byte Id { get { return 0x0E; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            Type = (Objects)stream.readByte();
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
            Yaw = stream.readByte();
            Pitch = stream.readByte();
            Data = stream.readInt();
            if (Data != 0)
            {
                SpeedX = stream.readShort();
                SpeedY = stream.readShort();
                SpeedZ = stream.readShort();
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeByte((byte)Type);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.writeByte(Yaw);
            stream.writeByte(Pitch);
            stream.writeInt(Data);
            if (Data != 0)
            {
                stream.writeShort(SpeedX.Value);
                stream.writeShort(SpeedY.Value);
                stream.writeShort(SpeedZ.Value);
            }
            stream.Purge();
        }
    }
}