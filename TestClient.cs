﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MinecraftClient.Enums;
using MinecraftClient.Network.Packets;
using MinecraftClient.Network.Packets.Client;
using MinecraftClient.Network.Packets.Server;

namespace MinecraftClient.Network
{
    static class TestClient
    {
        static Minecraft Client;
        static List<IPacket> list = new List<IPacket>();
        static NetworkStream nStream;

        static void Main(string[] args)
        {
            Client = new Minecraft("TestBot", "", false);

            Client.PacketHandled += Client_PacketHandled;
            Client.LoginFailure += (sender, reason) => Console.Write(reason + "1243");

            Client.Login();
            Client.RefreshSession();
            

            Client.Connect("127.0.0.1", 25565);

            Client.SendPacket(new HandshakePacket
            {
                ProtocolVersion = 4,
                ServerAddress = "127.0.0.1",
                ServerPort = 25565,
                NextState = NextState.Login,
            });

            Client.SendPacket(new LoginStartPacket { Name = "Aragasas" });



            while (true)
            {
                
            }
            Console.Read();
        }

        private static void Client_PacketHandled(object sender, object packet, int id)
        {
            list.Add(packet as IPacket);
        }
    }
}