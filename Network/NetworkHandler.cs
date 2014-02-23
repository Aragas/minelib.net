﻿using System;
﻿using System.IO;
﻿using System.Net.Sockets;
using System.Threading;
using CWrapped;
﻿using MinecraftClient.Enums;
﻿using MinecraftClient.Network.Packets;
﻿using MinecraftClient.Network.Packets.Client;

namespace MinecraftClient.Network
{
    public partial class NetworkHandler : IDisposable
    {
        #region Variables

        Thread handler;
        Minecraft mainMC;
        TcpClient baseSock;
        NetworkStream baseStream;
        public Wrapped wSock;
        public TickHandler WorldTick;

        #endregion

        public NetworkHandler(Minecraft mc)
        {
            mainMC = mc;
        }

        /// <summary>
        /// Starts the network handler.
        /// </summary>
        public void Start()
        {
            try
            {
                baseSock = new TcpClient();
                IAsyncResult AR = baseSock.BeginConnect(mainMC.ServerIP, mainMC.ServerPort, null, null);
                WaitHandle wh = AR.AsyncWaitHandle;

                try
                {
                    if (!AR.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5), false))
                    {
                        baseSock.Close();
                        //RaiseSocketError(this, "Failed to connect: Connection Timeout");
                        return;
                    }

                    baseSock.EndConnect(AR);
                }
                finally
                {
                    wh.Close();
                }

            }
            catch (Exception e)
            {
                //RaiseSocketError(this, "Failed to connect: " + e.Message);
                return;
            }

            mainMC.Running = true;

            //RaiseSocketInfo(this, "Connected to server.");
            //RaiseSocketDebug(this, string.Format("IP: {0} Port: {1}", mainMC.ServerIP, mainMC.ServerPort.ToString()));

            // -- Create our Wrapped socket.
            baseStream = baseSock.GetStream();
            wSock = new Wrapped(baseStream);

            //RaiseSocketDebug(this, "Socket Created");

            // -- Start network parsing.
            handler = new Thread(Updater);
            handler.Start();
            //RaiseSocketDebug(this, "Handler thread started");
        }

        /// <summary>
        /// Stops and dispose the network handler.
        /// </summary>
        public void Stop()
        {
            Dispose();
        }

        private void Updater()
        {
            try
            {
                do
                {
                    Thread.Sleep(100);
                } while (PacketHandler());
            }
            catch (IOException) { }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }

            //do
            //{
            //
            //} while (FindNextPacket());

            //if (!handler.HasBeenKicked)
            //{
            //    ConsoleIO.WriteLine("Connection has been lost.");
            //    if (!handler.OnConnectionLost() && !Program.ReadLineReconnect()) { t_sender.Abort(); }
            //}
            //else if (Program.ReadLineReconnect()) { t_sender.Abort(); }
        }

        /// <summary>
        /// Creates an instance of each new packet, so it can be parsed.
        /// </summary>
        bool PacketHandler()
        {
            try
            {
                if (baseSock.Client == null || !baseSock.Connected)
                    return false;
                
                while (baseSock.Client.Available > 0)
                {
                    Console.WriteLine("In While");

                    int length = wSock.ReadVarInt();
                    Console.WriteLine("Lenght: " + length);
                    int packetID = wSock.ReadVarInt();

                    Console.WriteLine("ID : 0x" + String.Format("{0:X}", packetID));

                    switch (mainMC.ServerState)
                    {
                        case (int) ServerState.Status:
                            if (ServerResponse.ServerStatusResponse[packetID] == null)
                            {
                                wSock.ReadByteArray(length - 1); // -- bypass the packet
                                continue;
                            }

                            var packets = ServerResponse.ServerStatusResponse[packetID]();
                            RaisePacketHandled(this, packets, packetID);

                            break;

                        case (int) ServerState.Login:
                            if (ServerResponse.ServerLoginResponse[packetID] == null)
                            {
                                wSock.ReadByteArray(length - 1); // -- bypass the packet
                                continue;
                            }

                            var packetl = ServerResponse.ServerLoginResponse[packetID]();
                            packetl.ReadPacket(ref wSock);
                            RaisePacketHandled(this, packetl, packetID);

                            if (packetID == 2)
                                mainMC.ServerState = 1;

                            break;

                        case (int) ServerState.Play:
                            if (ServerResponse.ServerPlayResponse[packetID] == null)
                            {
                                wSock.ReadByteArray(length - 1); // -- bypass the packet
                                continue;
                            }

                            var packetp = ServerResponse.ServerPlayResponse[packetID]();
                            packetp.ReadPacket(ref wSock);
                            RaisePacketHandled(this, packetp, packetID);

                            break;
                    }
                    //Send(new PlayerPacket {OnGround = true});
                    //if (WorldTick != null)
                    //    WorldTick.DoTick();
                    Console.WriteLine("Ololo");
                    Console.WriteLine(" ");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Error");
                //Stop();
                return false;
            }
            return true;
        }

        bool FindNextPacket()
        {
            try
            {
                if (baseSock.Client == null || !baseSock.Connected) { return false; }
                while (baseSock.Client.Available > 0)
                {
                    Console.WriteLine("In While");

                    int length = wSock.ReadVarInt();
                    Console.WriteLine("Got Lenght");
                    int packetID = wSock.ReadVarInt();

                    Console.WriteLine("ID: " + packetID);

                    switch (mainMC.ServerState)
                    {
                        case (int)ServerState.Status:
                            if (ServerResponse.ServerStatusResponse[packetID] == null)
                            {
                                wSock.ReadByteArray(length - 1); // -- bypass the packet
                                continue;
                            }

                            var packets = ServerResponse.ServerStatusResponse[packetID]();
                            RaisePacketHandled(this, packets, packetID);

                            break;

                        case (int)ServerState.Login:
                            if (ServerResponse.ServerLoginResponse[packetID] == null)
                            {
                                wSock.ReadByteArray(length - 1); // -- bypass the packet
                                continue;
                            }

                            var packetl = ServerResponse.ServerLoginResponse[packetID]();
                            packetl.ReadPacket(ref wSock);
                            RaisePacketHandled(this, packetl, packetID);

                            if (packetID == 2)
                                mainMC.ServerState = 1;

                            break;

                        case (int)ServerState.Play:
                            if (ServerResponse.ServerPlayResponse[packetID] == null)
                            {
                                wSock.ReadByteArray(length - 1); // -- bypass the packet
                                continue;
                            }

                            var packetp = ServerResponse.ServerPlayResponse[packetID]();
                            packetp.ReadPacket(ref wSock);
                            RaisePacketHandled(this, packetp, packetID);

                            break;
                    }
                    //Send(new PlayerPacket {OnGround = true});
                    //if (WorldTick != null)
                    //    WorldTick.DoTick();
                    Console.WriteLine("Ololo");
                }
                Console.Write("Shit");
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(ThreadAbortException))
                {
                    Console.WriteLine("Error");
                    Stop();
                    return false;
                }
            }
            return true;
        }

        public void Send(IPacket packet)
        {
            packet.WritePacket(ref wSock);
        }

        public void Dispose()
        {
            if (handler.IsAlive)
                handler.Abort();

            if (baseSock != null)
                baseSock.Close();

            if (baseStream != null)
                baseStream.Dispose();

            if (wSock != null)
                wSock.Dispose();

            if (mainMC != null)
                mainMC = null;
        }
    }
}