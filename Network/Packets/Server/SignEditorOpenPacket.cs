using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct SignEditorOpenPacket : IPacket
    {
        public int X, Y, Z;

        public const byte PacketId = 0x36;
        public byte Id { get { return 0x36; } }

        public void ReadPacket(ref Wrapped stream)
        {
            X = stream.readInt();
            Y = stream.readInt();
            Z = stream.readInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(X);
            stream.writeInt(Y);
            stream.writeInt(Z);
            stream.Purge();
        }
    }
}