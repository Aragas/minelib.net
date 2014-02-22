using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct AnimationPacket : IPacket
    {
        public int EntityID;
        public EntityAnimation Animation;

        public const byte PacketId = 0x0B;
        public byte Id { get { return 0x0B; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readVarInt();
            Animation = (EntityAnimation)stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeByte((byte)Animation);
            stream.Purge();
        }
    }
}