using System;
using System.Collections.Generic;
using System.Net;
using MinecraftClient.Network.Packets;

//using libMC.NET.Common;
//using libMC.NET.World;
//using libMC.NET.Entities;

// TODO: Comment more things
// TODO: Speed things up, optimize code.

// [Low]: Refactor packets to be universal for Server/Client, and be usable with proxies

namespace MinecraftClient.Network
{
    /// <summary>
    /// Main class for libMC.Net, a Minecraft interaction library for .net languages.
    /// </summary>
    public partial class Minecraft
    {
        #region Variables
        public string ServerIP, ClientName, ClientPassword, AccessToken, ClientToken, SelectedProfile, ClientBrand;
        public int ServerPort, ServerState;
        public bool VerifyNames, Running;
        public NetworkHandler nh;

        #region Trackers
        //public WorldClass MinecraftWorld; // -- Holds all of the world information. Time, chunks, players, ect.
        public Player ThisPlayer; // -- Holds all user information, location, inventory and so on.
        public Dictionary<string, short> Players;
        #endregion
        #endregion

        /// <summary>
        /// Create a new Minecraft Instance
        /// </summary>
        /// <param name="username">The username to use when connecting to Minecraft</param>
        /// <param name="password">The password to use when connecting to Minecraft (Ignore if you are providing credentials)</param>
        /// <param name="nameVerification">To connect using Name Verification or not</param>
        public Minecraft(string username, string password, bool nameVerification = false)
        {
            ClientName = username;
            ClientPassword = password;
            VerifyNames = nameVerification;
            ClientBrand = "libMC.NET"; // -- Used in the plugin message reporting the client brand to the server.
        }

        /// <summary>
        /// Login to Minecraft.net and store credentials
        /// </summary>
        public void Login()
        {
            if (VerifyNames)
            {
                YggdrasilStatus result = LoginAuthServer(ref ClientName, ClientPassword, ref AccessToken, ref ClientToken, ref SelectedProfile);

                switch (result)
                {
                    case YggdrasilStatus.Success:
                        RaiseLoginSuccess(this);
                        RaiseInfo(this, "Logged in to Minecraft.net successfully.");
                        RaiseDebug(this, string.Format("Token: {0}\nProfile: {1}", AccessToken, SelectedProfile));
                        break;

                    default:
                        VerifyNames = false; // -- Fall back to no auth.

                        RaiseLoginFailure(this, result.ToString());
                        RaiseError(this, "Failed to login to Minecraft.net! (Incorrect username or password)");
                        break;
                }
            }
            else
            {
                AccessToken = "None";
                SelectedProfile = "None";
            }

        }

        public bool VerifyName(string accessToken, string selectedProfile, string serverHash)
        {
            try
            {
                WebClient wClient = new WebClient();
                wClient.Headers.Add("Content-Type: application/json");
                string json = "{\"accessToken\": \"" + accessToken + "\",\"selectedProfile\": \"" + selectedProfile +
                              "\",\"serverId\": \"" + serverHash + "\"}";
                string result = wClient.UploadString("https://sessionserver.mojang.com/session/minecraft/join", json);

                {
                    // dunno what to do, can't find answer
                }

                return true;
            }
            catch (WebException e)
            {
                return false;
            }

        }

        public bool VerifySession(string accessToken)
        {
            try
            {
                WebClient wClient = new WebClient();
                wClient.Headers.Add("Content-Type: application/json");
                string json = "{\"accessToken\": \"" + accessToken + "\"}";
                string result = wClient.UploadString("https://authserver.mojang.com/validate", json);

                {
                    string[] temp = result.Split(new string[] { "accessToken\":\"" },
                        StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length >= 2)
                    {
                        accessToken = temp[1].Split('"')[0];
                    }

                    return true;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        /// <summary>
        /// Uses a client's stored credentials to verify with Minecraft.net
        /// </summary>
        public bool RefreshSession()
        {
            if (AccessToken == null || ClientToken == null)
            {
                RaiseError(this, "Credentials are not set!");
                return false;
            }

            YggdrasilStatus result = RefreshSession(ref AccessToken, ref ClientToken);

            switch (result)
            {
                case YggdrasilStatus.Success:
                    RaiseInfo(this, "Credentials verified and refreshed!");
                    return true;

                default:
                    RaiseError(this, "Unable to Verify Session!");
                    return false;
            }

        }

        /// <summary>
        /// Uses a client's stored credentials to verify with Minecraft.net
        /// </summary>
        /// <param name="accessToken">Stored Access Token</param>
        /// <param name="clientToken">Stored Client Token</param>
        public bool RefreshSession(string accessToken, string clientToken)
        {
            AccessToken = accessToken;
            ClientToken = clientToken;

            if (AccessToken == null || ClientToken == null)
            {
                RaiseError(this, "Credentials are not set!");
                return false;
            }

            YggdrasilStatus result = RefreshSession(ref AccessToken, ref ClientToken);

            switch (result)
            {
                case YggdrasilStatus.Success:
                    RaiseInfo(this, "Credentials verified and refreshed!");
                    return true;

                default:
                    RaiseError(this, "Unable to Verify Session!");
                    return false;
            }

        }

        /// <summary>
        /// Connects to the Minecraft Server.
        /// </summary>
        /// <param name="ip">The IP of the server to connect to</param>
        /// <param name="port">The port of the server to connect to</param>
        public void Connect(string ip, int port)
        {
            ServerIP = ip;
            ServerPort = port;

            if (nh != null)
                Disconnect();

            Players = new Dictionary<string, short>();

            nh = new NetworkHandler(this);

            // -- Register our event handlers.
            nh.InfoMessage += NetworkInfo;
            nh.DebugMessage += NetworkDebug;
            nh.SocketError += NetworkError;
            nh.PacketHandled += RaisePacketHandled;

            // -- Connect to the server and begin reading packets.

            nh.Start();

            RaiseDebug(this, "Network handler created, Connecting to server...");
        }

        /// <summary>
        /// Send IPacket to the Minecraft Server.
        /// </summary>
        /// <param name="packet">IPacket to sent to server</param>
        public void SendPacket(IPacket packet)
        {
            if (nh != null)
            {
                nh.Send(packet);
            }
            else RaiseError(this, "Connect first!");
        }

        /// <summary>
        /// Disconnects from the Minecraft server.
        /// </summary>
        public void Disconnect()
        {
            if (nh != null)
                nh.Stop();

            // -- Reset all variables to default so we can make a new connection.

            Running = false;
            ServerState = 0;
            nh = null;
            //MinecraftWorld = null;
            //ThisPlayer = null;
            Players = null;

            RaiseDebug(this, "Variables reset, disconnected from server.");
        }

    }
}
