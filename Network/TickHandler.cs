namespace MinecraftClient.Network
{
    public class TickHandler
    {
        public Minecraft ThisMc;

        public TickHandler(ref Minecraft mc)
        {
            ThisMc = mc;
        }
        public void DoTick()
        {
            var Player = new Player(ref ThisMc); // -- Send a player packet.
        }
    }
}