using CWrapped;

namespace MinecraftClient.Data
{
    public class MetadataShort : MetadataEntry
    {
        public override byte Identifier { get { return 1; } }
        public override string FriendlyName { get { return "short"; } }

        public short Value;

        public static implicit operator MetadataShort(short value)
        {
            return new MetadataShort(value);
        }

        public MetadataShort()
        {
        }

        public MetadataShort(short value)
        {
            Value = value;
        }

        public override void FromStream(ref Wrapped stream)
        {
        //    Value = stream.readShort();
        }

        public override void WriteTo(ref Wrapped stream, byte index)
        {
        //    stream.writeVarInt(GetKey(index));
        //    stream.writeShort(Value);
        }
    }
}
