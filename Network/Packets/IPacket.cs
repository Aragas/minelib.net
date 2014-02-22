using CWrapped;

namespace MinecraftClient.Network.Packets
{
    public interface IPacket
    {
        byte Id { get; }
        void ReadPacket(ref Wrapped stream);
        void WritePacket(ref Wrapped stream);
    }
}
