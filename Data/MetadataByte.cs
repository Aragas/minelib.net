using CWrapped;

namespace MinecraftClient.Data
{
    public class MetadataByte : MetadataEntry
    {
        public override byte Identifier { get { return 0; } }
        public override string FriendlyName { get { return "byte"; } }

        public byte Value;

        public static implicit operator MetadataByte(byte value)
        {
            return new MetadataByte(value);
        }

        public MetadataByte()
        {
        }

        public MetadataByte(byte value)
        {
            Value = value;
        }

        public override void FromStream(ref Wrapped stream)
        {
            Value = stream.ReadByte();
        }

        public override void WriteTo(ref Wrapped stream, byte index)
        {
            stream.WriteVarInt(GetKey(index));
            stream.WriteByte(Value);
        }
    }
}
