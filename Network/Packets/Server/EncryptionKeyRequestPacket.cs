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
            ServerId = stream.readString();
            var pkLength = stream.readShort();
            PublicKey = stream.readByteArray(pkLength);
            var vtLength = stream.readShort();
            VerificationToken = stream.readByteArray(vtLength);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(ServerId);
            stream.writeShort((short)PublicKey.Length);
            stream.writeByteArray(PublicKey);
            stream.writeShort((short)VerificationToken.Length);
            stream.writeByteArray(VerificationToken);
            stream.Purge();
        }
    }
}