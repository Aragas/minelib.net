using CWrapped;

namespace MinecraftClient.Data
{
    public class MetadataInt : MetadataEntry
    {
        public override byte Identifier { get { return 2; } }
        public override string FriendlyName { get { return "int"; } }

        public int Value;

        public static implicit operator MetadataInt(int value)
        {
            return new MetadataInt(value);
        }

        public MetadataInt()
        {
        }

        public MetadataInt(int value)
        {
            Value = value;
        }

        public override void FromStream(ref Wrapped stream)
        {
            Value = stream.ReadInt();
        }

        public override void WriteTo(ref Wrapped stream, byte index)
        {
            stream.WriteVarInt(GetKey(index));
            stream.WriteInt(Value);
        }
    }
}
