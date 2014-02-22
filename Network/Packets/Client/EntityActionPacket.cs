using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Client
{
    public struct EntityActionPacket : IPacket
    {
        public int EntityID;
        public EntityAction Action;
        public int Unknown;

        public const byte PacketId = 0x13;
        public byte Id { get { return 0x13; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            Action = (EntityAction)stream.readVarInt();
            Unknown = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeVarInt((byte)Action);
            stream.writeVarInt(Unknown);
            stream.Purge();
        }
    }
}