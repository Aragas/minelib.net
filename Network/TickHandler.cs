using CWrapped;

namespace MinecraftClient.Network
{
    public class TickHandler
    {
        public Wrapped ThisMc;

        public TickHandler(ref Wrapped mc)
        {
            ThisMc = mc;
        }
        public void DoTick()
        {
            var Player = new Player(ref ThisMc); // -- Send a player packet.
        }
    }
}