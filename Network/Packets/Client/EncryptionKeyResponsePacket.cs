using CWrapped;

namespace MinecraftClient.Network.Packets.Client
{
    public struct EncryptionKeyResponsePacket : IPacket
    {
        public byte[] SharedSecret;
        public byte[] VerificationToken;

        public const byte PacketId = 0xFC;
        public byte Id { get { return 0xFC; } }

        public void ReadPacket(ref Wrapped stream)
        {
            var ssLength = stream.readShort();
            //SharedSecret = stream.ReadUInt8Array(ssLength);
            var vtLength = stream.readShort();
            //VerificationToken = stream.ReadUInt8Array(vtLength);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeShort((short)SharedSecret.Length);
            //stream.writeVarIntArray(SharedSecret);
            stream.writeShort((short)VerificationToken.Length);
            //stream.writeVarIntArray(VerificationToken);
            stream.Purge();
        }
    }
}