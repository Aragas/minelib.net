using System;
using System.Net;
using System.Net.Sockets;

namespace MinecraftClient.Network
{
    public class Player
    {

        //TcpListener --> Socket --> NetworkStream

        public static event ConnnectedDelegate Connected;
        public delegate void ConnnectedDelegate(Socket socket);
        private static bool enabled = true;
        static IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];



        public Player(ref Minecraft mc)
        {
            mc.nh.wSock.writeVarInt(3);
            mc.nh.wSock.writeBool(true);
            mc.nh.wSock.Purge();
        }
    }
}