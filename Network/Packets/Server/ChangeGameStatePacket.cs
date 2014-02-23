using CWrapped;
using MinecraftClient.Enums;

namespace MinecraftClient.Network.Packets.Server
{
    public struct ChangeGameStatePacket : IPacket
    {
        public GameState Reason;
        public float Value; // Was GameMode
    
        public const byte PacketId = 0x2B;
        public byte Id { get { return 0x2B; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            Reason = (GameState)stream.ReadByte();
            Value = stream.ReadFloat();
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteByte((byte)Reason);
            stream.WriteFloat(Value);
            stream.Purge();
        }
    }
}