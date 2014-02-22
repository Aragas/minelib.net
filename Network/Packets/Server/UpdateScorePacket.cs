using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct UpdateScorePacket : IPacket
    {
        public string ItemName;
        public bool RemoveItem; // Will be converted to byte 0-1
        public string ScoreName;
        public int? Value;

        public const byte PacketId = 0x3C;
        public byte Id { get { return 0x3C; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ItemName = stream.readString();
            RemoveItem = stream.readBool();
            if (!RemoveItem)
            {
                ScoreName = stream.readString();
                Value = stream.readInt();
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(ItemName);
            stream.writeBool(RemoveItem);
            if (!RemoveItem)
            {
                stream.writeString(ScoreName);
                stream.writeInt(Value.Value);
            }
            stream.Purge();
        }
    }
}