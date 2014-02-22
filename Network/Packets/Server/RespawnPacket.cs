using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct RespawnPacket : IPacket
    {
        public Dimension Dimension;
        public Difficulty Difficulty;
        public GameMode GameMode;
        public string LevelType;
    
        public const byte PacketId = 0x07;
        public byte Id { get { return 0x07; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            Dimension = (Dimension)stream.readInt();
            Difficulty = (Difficulty)stream.readByte();
            GameMode = (GameMode)stream.readByte();
            LevelType = stream.readString();
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt((int)Dimension);
            stream.writeByte((byte)Difficulty);
            stream.writeByte((byte)GameMode);
            stream.writeString(LevelType);
            stream.Purge();
        }
    }
}