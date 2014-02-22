using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct WindowItemsPacket : IPacket
    {
        public byte WindowId;
        public ItemStack[] SlotData;
    
        public const byte PacketId = 0x30;
        public byte Id { get { return 0x30; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.readByte();
            short count = stream.readShort();
            SlotData = new ItemStack[count];
            //for (int i = 0; i < count; i++)
            //SlotData[i] = ItemStack.FromStream(stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(WindowId);
            stream.writeShort((short)SlotData.Length);
            //for (int i = 0; i < SlotData.Length; i++)
            //SlotData[i].WriteTo(stream);
            stream.Purge();
        }
    }
}