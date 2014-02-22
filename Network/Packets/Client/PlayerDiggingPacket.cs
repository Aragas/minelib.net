using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Client
{
    public struct PlayerDiggingPacket : IPacket
    {
        public DigStatus Action;
        public int X;
        public byte Y;
        public int Z;
        public byte Face;

        public const byte PacketId = 0x0E;
        public byte Id { get { return 0x0E; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Action = (DigStatus)stream.readVarInt();
            X = stream.readShort();
            Y = stream.readByte();
            Z = stream.readShort();
            Face = stream.readByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt((byte)Action);
            stream.writeVarInt(X);
            stream.writeVarInt(Y);
            stream.writeVarInt(Z);
            stream.writeVarInt(Face);
            stream.Purge();
        }
    }
}