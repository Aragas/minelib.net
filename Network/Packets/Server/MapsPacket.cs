using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct MapsPacket : IPacket
    {
        public int ItemDamage;
        public byte[] Data;

        public const byte PacketId = 0x34;
        public byte Id { get { return 0x34; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ItemDamage = stream.readInt();
            var length = stream.readShort();
            Data = stream.readByteArray(length);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(ItemDamage);
            stream.writeShort((short)Data.Length);
            stream.writeByteArray(Data);
            stream.Purge();
        }
    }
}