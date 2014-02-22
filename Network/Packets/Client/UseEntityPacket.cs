using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct UseEntityPacket : IPacket
    {
        public int User, Target;
        public bool LeftClick;

        public const byte PacketId = 0x07;
        public byte Id { get { return 0x07; } }

        public void ReadPacket(ref Wrapped stream)
        {
            User = stream.readShort();
            Target = stream.readShort();
            LeftClick = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(User);
            stream.writeVarInt(Target);
            stream.writeBool(LeftClick);
            stream.Purge();
        }
    }
}