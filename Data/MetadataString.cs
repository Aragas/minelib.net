using System;
using CWrapped;

namespace MinecraftClient.Data
{
    public class MetadataString : MetadataEntry
    {
        public override byte Identifier { get { return 4; } }
        public override string FriendlyName { get { return "string"; } }

        public string Value;

        public static implicit operator MetadataString(string value)
        {
            return new MetadataString(value);
        }

        public MetadataString()
        {
        }

        public MetadataString(string value)
        {
            if (value.Length > 16)
                throw new ArgumentOutOfRangeException("value", "Maximum string length is 16 characters");
            while (value.Length < 16)
                value = value + "\0";
            Value = value;
        }

        public override void FromStream(ref Wrapped stream)
        {
            Value = stream.ReadString();
        }

        public override void WriteTo(ref Wrapped stream, byte index)
        {
            stream.WriteVarInt(GetKey(index));
            stream.WriteString(Value);
        }
    }
}
