using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SetExperiencePacket : IPacket
    {
        public float ExperienceBar;
        public short Level;
        public short TotalExperience;

        public const byte PacketId = 0x1F;
        public byte Id { get { return 0x1F; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ExperienceBar = stream.readFloat();
            Level = stream.readShort();
            TotalExperience = stream.readShort();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeFloat(ExperienceBar);
            stream.writeShort(Level);
            stream.writeShort(TotalExperience);
            stream.Purge();
        }
    }
}