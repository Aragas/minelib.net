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
            int blockID = mc.nh.wSock.ReadShort();

            if (blockID == -1)
            {
                itemID = 0;
                itemCount = 0;
                itemDamage = 0;
                return;
            }

            itemCount = mc.nh.wSock.ReadByte();
            itemDamage = mc.nh.wSock.ReadShort();
            int NBTLength = mc.nh.wSock.ReadShort();

            if (NBTLength == -1)
            {
                return;
            }

            nbtData = mc.nh.wSock.ReadByteArray(NBTLength);

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
                mc.nh.wSock.WriteShort(-1);
                return;
            }

            mc.nh.wSock.WriteShort((short)item.itemID);
            mc.nh.wSock.WriteByte(item.itemCount);
            mc.nh.wSock.WriteShort(item.itemDamage);
            mc.nh.wSock.WriteShort(-1);
        }
    }
}
