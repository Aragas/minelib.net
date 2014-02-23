using System;
using System.Net;
using System.Net.Sockets;
using CWrapped;

namespace MinecraftClient.Network
{
    public class Player
    {

        //TcpListener --> Socket --> NetworkStream

        public static event ConnnectedDelegate Connected;
        public delegate void ConnnectedDelegate(Socket socket);
        private static bool enabled = true;
        static IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];



        public Player(ref Wrapped stream)
        {
            stream.WriteVarInt(3);
            stream.WriteBool(true);
            stream.Purge();
        }
    }
}