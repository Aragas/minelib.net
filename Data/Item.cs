using MinecraftClient.Enums;

namespace MinecraftClient.Data
{
    public class Item
    {
        public int itemID;
        public byte itemCount;
        public short itemDamage;
        public byte[] nbtData;

        public void ReadSlot(ref Minecraft mc)
        {
            int blockID = mc.nh.stream.ReadShort();

            if (blockID == -1)
            {
                itemID = 0;
                itemCount = 0;
                itemDamage = 0;
                return;
            }

            itemCount = mc.nh.stream.ReadByte();
            itemDamage = mc.nh.stream.ReadShort();
            int NBTLength = mc.nh.stream.ReadShort();

            if (NBTLength == -1)
            {
                return;
            }

            nbtData = mc.nh.stream.ReadByteArray(NBTLength);

            return;
        }
        public string FriendlyName()
        {
            // -- Return the friendly name for the item we represent

            return ((Blocks)itemID).ToString();
        }

        public static void WriteSlot(ref Minecraft mc, Item item)
        {
            if (item == null)
            {
                mc.nh.stream.WriteShort(-1);
                return;
            }

            mc.nh.stream.WriteShort((short)item.itemID);
            mc.nh.stream.WriteByte(item.itemCount);
            mc.nh.stream.WriteShort(item.itemDamage);
            mc.nh.stream.WriteShort(-1);
        }
    }
}
