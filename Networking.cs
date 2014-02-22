using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CWrapped;
using MinecraftClient.Enums;
using MinecraftClient.Network.Packets;

namespace MinecraftClient
{
    class Networking
    {
        public delegate void IPacketHandler(object sender, IPacketWrapped packet);

        public event IPacketHandler PacketReceived;

        TcpClient client;
        Wrapped wrapped;
        IPacketWrapped packet;
        bool SendPacket;
        ServerState state;


        static void Main(string[] args)
        {
            new Networking().Start();
        }

        private void Start()
        {
            state = ServerState.Login;
            string ServerIP = "127.0.0.1";
            int ServerPort = 25565;

            client = new TcpClient(ServerIP, ServerPort);
            client.ReceiveBufferSize = 1024 * 1024;

            new Thread(Updater).Start();



            new Handshake
            {
                ServerAddress = "127.0.0.1",
                ServerPort = 25565,
                ProtocolVersion = 4,
                NextState = NextState.Login
            };
            //.WritePacket(client);

            new LoginStart
            {
                Name = "TestBot"
            };
            //.WritePacket(client);
        }

        private void Updater()
        {
            try
            {
                do
                {
                    Thread.Sleep(100);
                } while (Update());
            }
            catch (IOException) { }
            catch (SocketException) { }
            catch (ObjectDisposedException) { }

            //if (!handler.HasBeenKicked)
            //{
            //    ConsoleIO.WriteLine("Connection has been lost.");
            //    if (!handler.OnConnectionLost() && !Program.ReadLineReconnect()) { t_sender.Abort(); }
            //}
            //else if (Program.ReadLineReconnect()) { t_sender.Abort(); }
        }


        public bool Update()
        {
            if (client.Client == null || !client.Connected) { return false; }
            int id = 0, size = 0;
            try
            {
                Console.Write("ololo");

                while (client.Client.Available > 0)
                {
                    size = wrapped.ByteRead();
                    id = wrapped.ByteRead();
                    Console.Write(id);

                    switch (state)
                    {
                        case ServerState.Status:
                            if (Response.ServerStatusResponse[id] == null)
                            {
                                Console.Write("Unknown Packet ID. State: 1, Packet: " + id);
                                wrapped.readByteArray(size - 1); // -- bypass the packet
                                continue;
                            }

                            var packets = Response.ServerStatusResponse[id]();
                            PacketReceived(this, packets);

                            break;

                        case ServerState.Login:
                            if (Response.ServerLoginResponse[id] == null)
                            {
                                Console.Write("Unknown Packet ID. State: 2, Packet: " + id);
                                wrapped.readByteArray(size - 1); // -- bypass the packet
                                continue;
                            }

                            var packetl = Response.ServerLoginResponse[id]();
                            PacketReceived(this, packetl);

                            break;

                        case ServerState.Play:
                            if (Response.ServerPlayResponse[id] == null)
                            {
                                Console.Write("Unknown Packet ID. State: 3, Packet: " + id);
                                wrapped.readByteArray(size - 1); // -- bypass the packet
                                continue;
                            }

                            var packetp = Response.ServerPlayResponse[id]();
                            PacketReceived(this, packetp);

                            break;
                    }
                }
            }
            catch (SocketException) { return false; }
            return true;
        }

        enum ServerState
        {
            Play = 0,
            Status = 2,
            Login = 3,
        }
    }

    public static class Response
    {
        public delegate IPacketWrapped CreatePacketInstance();

        #region Server Login Response
        public static readonly CreatePacketInstance[] ServerLoginResponse =
        {
            null,//() => new LoginDisconnect(), // 0x00
            null,//() => new EncryptionKeyRequest(), // 0x01
            () => new LoginSuccess(), // 0x02
        };
        #endregion

        #region Server Status Response
        public static readonly CreatePacketInstance[] ServerStatusResponse =
        {
            null,//() => new ResponsePacket(), // 0x00
            null,//() => new ServerListPingPacket(), // 0x01
        };
        #endregion

        #region Server Play Response
        public static readonly CreatePacketInstance[] ServerPlayResponse =
        {
            null,//() => new KeepAlivePacket(), // 0x00
            
        };
        #endregion
    }

    public interface IPacketWrapped
    {
        byte Id { get; }
        void ReadPacket(Wrapped client);
        void WritePacket(Wrapped client);
    }

    public struct Handshake : IPacketWrapped
    {
        public byte ProtocolVersion;
        public string ServerAddress;
        public short ServerPort;
        public NextState NextState;

        public const byte PacketId = 0x00;
        public byte Id { get { return 0x00; } }

        public void ReadPacket(Wrapped stream)
        {
            ProtocolVersion = stream.ByteRead();
            ServerAddress = stream.StringRead();
            ServerPort = stream.ShortRead();
            NextState = (NextState)stream.IntRead();
        }

        public void WritePacket(Wrapped stream)
        {
            stream.ByteWrite(Id);
            stream.ByteWrite(ProtocolVersion);
            stream.StringWrite(ServerAddress);
            stream.ShortWrite(ServerPort);
            stream.IntWrite((byte)NextState);
            stream.Purge();
        }
    }

    public struct LoginStart : IPacketWrapped
    {
        public string Name;

        public const byte PacketId = 0x00;
        public byte Id { get { return 0x00; } }

        public void ReadPacket(Wrapped stream)
        {
            Name = stream.StringRead();
        }

        public void WritePacket(Wrapped stream)
        {
            stream.ByteWrite(Id);
            stream.StringWrite(Name);
            stream.Purge();
        }
    }

    public struct LoginSuccess : IPacketWrapped
    {
        public string UUID, Username;

        public const byte PacketId = 0x02;
        public byte Id { get { return 0x02; } }

        public void ReadPacket(Wrapped stream)
        {
            UUID = stream.StringRead();
            Username = stream.StringRead();
        }

        public void WritePacket(Wrapped stream)
        {
            stream.ByteWrite(Id);
            stream.StringWrite(UUID);
            stream.StringWrite(Username);
            stream.Purge();
        }
    }
}
