using CWrapped;
using MinecraftClient.Data;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityEquipmentPacket : IPacket
    {
        public int EntityID;
        public EntityEquipmentSlot Slot;
        public ItemStack Item;
    
        public const byte PacketId = 0x04;
        public byte Id { get { return 0x04; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            Slot = (EntityEquipmentSlot)stream.readShort();
            //Item = ItemStack.FromStream(stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeShort((short)Slot);
            //Item.WriteTo(stream);
            stream.Purge();
        }
    }
}