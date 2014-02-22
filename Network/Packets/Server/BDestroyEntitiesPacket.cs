using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct DestroyEntitiesPacket : IPacket
    {
        public int[] EntityIDs;

        public const byte PacketId = 0x13;
        public byte Id { get { return 0x13; } }

        public void ReadPacket(ref Wrapped stream)
        {
            var length = stream.readVarInt();
            //EntityIDs = stream.ReadInt32Array(length);
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt((byte)EntityIDs.Length);
            //stream.writeVarIntArray(EntityIDs);
            stream.Purge();
        }
    }
}