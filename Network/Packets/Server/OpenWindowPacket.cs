using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct OpenWindowPacket : IPacket
    {
        public byte WindowID;
        public byte InventoryType;
        public string WindowTitle;
        public byte NumberOfSlots;
        public bool UseProvidedTitle;
        public int? EntityID;

        public const byte PacketId = 0x2D;
        public byte Id { get { return 0x2D; } }

        public void ReadPacket(ref Wrapped stream)
        {
            WindowID = stream.readByte();
            InventoryType = stream.readByte();
            WindowTitle = stream.readString();
            NumberOfSlots = stream.readByte();
            UseProvidedTitle = stream.readBool();
            if (InventoryType == 11)
                EntityID = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeByte(WindowID);
            stream.writeByte(InventoryType);
            stream.writeString(WindowTitle);
            stream.writeByte(NumberOfSlots);
            stream.writeBool(UseProvidedTitle);
            if (InventoryType == 11)
                stream.writeInt(EntityID.GetValueOrDefault());
            stream.Purge();
        }
    }
}