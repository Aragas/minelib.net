using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct JoinGamePacket : IPacket
    {
        public int EntityID;
        public GameMode GameMode;
        public Dimension Dimension;
        public Difficulty Difficulty;
        public byte MaxPlayers;
        public string LevelType;
    
        public const byte PacketId = 0x01;
        public byte Id { get { return 0x01; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            GameMode = (GameMode)stream.readByte();
            Dimension = (Dimension)stream.readSByte();
            Difficulty = (Difficulty)stream.readByte();
            MaxPlayers = stream.readByte();
            LevelType = stream.readString();
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeVarInt((byte)GameMode);
            stream.writeSByte((sbyte)Dimension);
            stream.writeVarInt((byte)Difficulty);
            stream.writeVarInt(MaxPlayers);
            stream.writeString(LevelType);
            stream.Purge();
        }
    }
}