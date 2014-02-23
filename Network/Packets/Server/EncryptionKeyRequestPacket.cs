using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EncryptionKeyRequestPacket : IPacket
    {
        public string ServerId;
        public byte[] PublicKey;
        public byte[] VerificationToken;

        public const byte PacketId = 0x01;
        public byte Id { get { return 0x01; } }

        public void ReadPacket(ref Wrapped stream)
        {
            ServerId = stream.ReadString();
            var pkLength = stream.ReadShort();
            PublicKey = stream.ReadByteArray(pkLength);
            var vtLength = stream.ReadShort();
            VerificationToken = stream.ReadByteArray(vtLength);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteString(ServerId);
            stream.WriteShort((short)PublicKey.Length);
            stream.WriteByteArray(PublicKey);
            stream.WriteShort((short)VerificationToken.Length);
            stream.WriteByteArray(VerificationToken);
            stream.Purge();
        }
    }
}