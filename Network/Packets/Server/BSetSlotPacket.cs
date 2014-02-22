using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SetSlotPacket : IPacket
    {
        public byte WindowId;
        public short Slot;
        public ItemStack SlotData;
    
        public const byte PacketId = 0x2F;
        public byte Id { get { return 0x2F; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.readByte();
            Slot = stream.readShort();
            //SlotData = ItemStack.FromStream(stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(WindowId);
            stream.writeShort(Slot);
            //SlotData.WriteTo(stream);
            stream.Purge();
        }
    }
}