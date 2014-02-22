using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct PlayerAbilitiesPacket : IPacket
    {
        public sbyte Flags;
        public float FlyingSpeed, WalkingSpeed;

        public const byte PacketId = 0x39;
        public byte Id { get { return 0x39; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Flags = stream.readSByte();
            FlyingSpeed = stream.readFloat();
            WalkingSpeed = stream.readFloat();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeSByte(Flags);
            stream.writeFloat(FlyingSpeed);
            stream.writeFloat(WalkingSpeed);
            stream.Purge();
        }
    }
}