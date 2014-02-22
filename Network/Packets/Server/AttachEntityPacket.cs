using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct AttachEntityPacket : IPacket
    {
        public int EntityID, VehicleID;
        public bool Leash;

        public const byte PacketId = 0x1B;
        public byte Id { get { return 0x1B; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readInt();
            VehicleID = stream.readInt();
            Leash = stream.readBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeInt(EntityID);
            stream.writeInt(VehicleID);
            stream.writeBool(Leash);
            stream.Purge();
        }
    }
}