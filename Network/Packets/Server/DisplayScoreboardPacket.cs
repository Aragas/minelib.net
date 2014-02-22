using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct DisplayScoreboardPacket : IPacket
    {
        public ScoreboardPosition Position;
        public string ScoreName;

        public const byte PacketId = 0x3D;
        public byte Id { get { return 0x3D; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Position = (ScoreboardPosition)stream.readByte();
            ScoreName = stream.readString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeByte((byte)Position);
            stream.writeString(ScoreName);
            stream.Purge();
        }
    }
}