using System.Text;
using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct ItemDataPacket : IPacket
    {
        public short ItemType, ItemId;
        public string Text;

        public const byte PacketId = 0x83;
        public byte Id { get { return 0x83; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ItemType = stream.readShort();
            ItemId = stream.readShort();
            var length = stream.readShort();
            Text = Encoding.ASCII.GetString(stream.readByteArray(length));
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeShort(ItemType);
            stream.writeShort(ItemId);
            stream.writeShort((short)Text.Length);
            stream.writeByteArray(Encoding.ASCII.GetBytes(Text));
            stream.Purge();
        }
    }
}