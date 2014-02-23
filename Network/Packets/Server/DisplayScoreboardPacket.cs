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
            Position = (ScoreboardPosition)stream.ReadByte();
            ScoreName = stream.ReadString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteByte((byte)Position);
            stream.WriteString(ScoreName);
            stream.Purge();
        }
    }
}