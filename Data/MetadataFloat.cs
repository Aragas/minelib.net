using CWrapped;

namespace MinecraftClient.Data
{
    public class MetadataFloat : MetadataEntry
    {
        public override byte Identifier { get { return 3; } }
        public override string FriendlyName { get { return "float"; } }

        public float Value;

        public static implicit operator MetadataFloat(float value)
        {
            return new MetadataFloat(value);
        }

        public MetadataFloat()
        {
        }

        public MetadataFloat(float value)
        {
            Value = value;
        }

        public override void FromStream(ref Wrapped stream)
        {
            Value = stream.ReadFloat();
        }

        public override void WriteTo(ref Wrapped stream, byte index)
        {
            stream.WriteVarInt(GetKey(index));
            stream.WriteFloat(Value);
        }
    }
}
