using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct EnchantItemPacket : IPacket
    {
        public byte WindowId;
        public byte Enchantment;

        public const byte PacketId = 0x6C;
        public byte Id { get { return 0x6C; } }

        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.readByte();
            Enchantment = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(WindowId);
            stream.writeVarInt(Enchantment);
            stream.Purge();
        }
    }
}