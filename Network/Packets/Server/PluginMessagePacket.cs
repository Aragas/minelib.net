using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct PluginMessagePacket : IPacket
    {
        public string Channel;
        public byte[] Data;

        public const byte PacketId = 0x3F;
        public byte Id { get { return 0x3F; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Channel = stream.readString();
            var length = stream.readShort();
            Data = stream.readByteArray(length);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeString(Channel);
            stream.writeShort((short)Data.Length);
            stream.writeByteArray(Data);
            stream.Purge();
        }
    }
}