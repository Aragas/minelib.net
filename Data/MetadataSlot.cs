using CWrapped;
using fNbt;

namespace MinecraftClient.Data
{
    public class MetadataSlot : MetadataEntry
    {
        public override byte Identifier { get { return 5; } }
        public override string FriendlyName { get { return "slot"; } }

        public ItemStack Value;

        public static implicit operator MetadataSlot(ItemStack value)
        {
            return new MetadataSlot(value);
        }

        public MetadataSlot()
        {
        }

        public MetadataSlot(ItemStack value)
        {
            Value = value;
        }

        public override void FromStream(ref Wrapped stream)
        {
            //Value = ItemStack.FromStream(stream);
        }

        public override void WriteTo(ref Wrapped stream, byte index)
        {
            stream.writeVarInt(GetKey(index));
            stream.writeShort(Value.Id);
            if (Value.Id != -1)
            {
                stream.writeSByte(Value.Count);
                stream.writeShort(Value.Metadata);
                if (Value.Nbt != null)
                {
                    var file = new NbtFile(Value.Nbt);
                    var data = file.SaveToBuffer(NbtCompression.GZip);
                    stream.writeShort((short)data.Length);
                    //stream.writeVarIntArray(data);
                }
                else
                    stream.writeShort(-1);
            }
        }
    }
}
