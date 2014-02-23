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
            EntityID = stream.ReadInt();
            Slot = (EntityEquipmentSlot)stream.ReadShort();
            Item = ItemStack.FromStream(ref stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(EntityID);
            stream.WriteShort((short)Slot);
            Item.WriteTo(ref stream);
            stream.Purge();
        }
    }
}