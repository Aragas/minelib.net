using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityStatusPacket : IPacket
    {
        public int EntityID;
        public EntityStatus Status;

        public const byte PacketId = 0x1A;
        public byte Id { get { return 0x1A; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            Status = (EntityStatus)stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeByte((byte)Status);
            stream.Purge();
        }
    }
}