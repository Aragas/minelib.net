using MinecraftClient.Data;

namespace MinecraftClient.Network
{

    #region Base Events

    public delegate void DebugMessageHandler(object sender, string message);

    public delegate void ErrorMessageHandler(object sender, string message);

    public delegate void InfoMessageHandler(object sender, string message);

    public delegate void MessageHandler(object sender, string message, string name);

    public delegate void PacketHandler(object sender, object packet, int id);

    #endregion

    #region Block Events

    public delegate void BlockChangedEventHandler(int x, byte y, int z, int newType, byte data);

    public delegate void BlockBreakAnimationHandler(Vector3 Location, int Entity_ID, byte Stage);

    public delegate void PistonMoveHandler(byte state, byte direction, int x, short y, int z);

    public delegate void ChestStateChangedHandler(byte state, int x, short y, int z);

    #endregion

    #region World Events

    public delegate void NoteBlockPlayHandler(byte instrument, byte pitch, int x, short y, int z);

    public delegate void GameStateChangedHandler(string eventName, float value);

    public delegate void ChunkUnloadedHandler(int X, int Z);

    public delegate void ChunkLoadedHandler(int X, int Z);

    public delegate void ExplosionHandler(float X, float Y, float Z);

    public delegate void MultiBlockChangeHandler(int Chunk_X, int Chunk_Z);

    #endregion

    #region Entity Events

    public delegate void EntityVelocityChangedHandler(int Entity_ID, int X, int Y, int Z);

    public delegate void EntityTeleportHandler(int Entity_ID, int X, int Y, int Z);

    public delegate void EntityRelMoveHandler(int Entity_ID, int Change_X, int Change_Y, int Change_Z);

    public delegate void EntityLookChangedHandler(int Entity_ID, byte yaw, byte pitch);

    public delegate void EntityHeadLookChangedHandler(int Entity_ID, byte head_yaw);

    //public delegate void EntityEquipmentChangedHandler(int Entity_ID, int slot, Item newItem);

    public delegate void EntityAnimationChangedHandler(object sender, int Entity_ID, byte Animation);

    public delegate void EntityAttachedHandler(int Entity_ID, int Vehicle_ID, bool Leashed);

    public delegate void ItemCollectedHandler(int item_EID, int collector_eid);

    public delegate void EntityDestroyedHandler(int Entity_ID);

    public delegate void EntityStatusChangedHandler(int Entity_ID);

    #endregion

    #region Player Events

    public delegate void ExperienceSetHandler(float expBar, short level, short totalExp);

    public delegate void PlayerRespawnedHandler();

    public delegate void LocationChangedHandler();

    public delegate void OpenWindowHandler(byte Window_ID, byte Type, string Title, byte slots, bool useTitle);

    public delegate void CloseWindowHandler(byte windowID);

    public delegate void HeldSlotChangedHandler(byte slot);

    //public delegate void SetWindowItemHandler(byte window_ID, short slot, Item item);

    //public delegate void SetInventoryItemHandler(short slot, Item item);

    public delegate void SetPlayerHealthHandler(float health, short hunger, float saturation);

    #endregion

    #region Scoreboard Events

    public delegate void ScoreboardObjectiveAddHandler(string name, string value);

    public delegate void ScoreboardObjectiveUpdateHandler(string name, string value);

    public delegate void ScoreboardObjectiveRemoveHandler(string name);

    public delegate void DisplayScoreboardHandler(byte position, string scoreName);

    #endregion

    #region Server Events

    public delegate void PluginMessageHandler(string channel, byte[] data);

    public delegate void PlayerListitemAddHandler(string name, short ping);

    public delegate void PlayerListitemRemoveHandler(string name);

    public delegate void PlayerListitemUpdateHandler(string name, short ping);

    public delegate void LoginSuccessHandler(object sender);

    public delegate void LoginFailureHandler(object sender, string reason);

    public delegate void JoinGameHandler();

    public delegate void TransactionRejectedHandler(byte Window_ID, short Action_ID);

    public delegate void TransactionAcceptedHandler(byte Window_ID, short Action_ID);

    public delegate void PlayerKickedHandler(string reason);

    public delegate void PingMsReceivedHandler(int msPing);

    //public delegate void PingResponseReceivedHandler(string VersionName, int ProtocolVersion, int MaxPlayers, int OnlinePlayers, string[] PlayersSample, string MOTD, Image Favicon);

    #endregion


    public class MinecraftEvent
    {

        #region Base Events

        public event DebugMessageHandler DebugMessage;

        public event ErrorMessageHandler ErrorMessage;

        public event InfoMessageHandler InfoMessage;

        public event MessageHandler Message;

        public event PacketHandler PacketHandled;

        #endregion

        #region Block Events

        public event BlockChangedEventHandler BlockChanged;

        //public event BlockBreakAnimationHandler BlockBreaking;

        public event PistonMoveHandler PistonMoved;

        public event ChestStateChangedHandler ChestStateChanged;

        #endregion

        #region World Events

        public event NoteBlockPlayHandler NoteBlockPlay;

        public event GameStateChangedHandler GameStateChanged;

        public event ChunkUnloadedHandler ChunkUnloaded;

        public event ChunkLoadedHandler ChunkLoaded;

        public event ExplosionHandler Explosion;

        public event MultiBlockChangeHandler MultiBlockChange;

        #endregion

        #region Entity Events

        public event EntityVelocityChangedHandler EntityVelocityChanged;

        public event EntityTeleportHandler EntityTeleport;

        public event EntityRelMoveHandler EntityRelMove;

        public event EntityLookChangedHandler EntityLookChanged;

        public event EntityHeadLookChangedHandler EntityHeadLookChanged;

        //public event EntityEquipmentChangedHandler EntityEquipmentChanged;

        public event EntityAnimationChangedHandler EntityAnimationChanged;

        public event EntityAttachedHandler EntityAttached;

        public event ItemCollectedHandler ItemCollected;

        public event EntityDestroyedHandler EntityDestroyed;

        public event EntityStatusChangedHandler EntityStatusChanged;

        #endregion

        #region Player Events

        public event ExperienceSetHandler ExperienceSet;

        public event PlayerRespawnedHandler PlayerRespawned;

        public event LocationChangedHandler LocationChanged;

        public event OpenWindowHandler OpenWindow;

        public event CloseWindowHandler CloseWindow;

        public event HeldSlotChangedHandler HeldSlotChanged;

        //public event SetWindowItemHandler SetWindowItem;

        //public event SetInventoryItemHandler SetInventoryItem;

        public event SetPlayerHealthHandler SetPlayerHealth;

        #endregion

        #region Scoreboard Events

        public event ScoreboardObjectiveAddHandler ScoreboardObjectiveAdd;

        public event ScoreboardObjectiveUpdateHandler ScoreboardObjectiveUpdate;

        public event ScoreboardObjectiveRemoveHandler ScoreboardObjectiveRemove;

        public event DisplayScoreboardHandler DisplayScoreboard;

        #endregion

        #region Server Events

        public event PluginMessageHandler PluginMessage;

        public event PlayerListitemAddHandler PlayerListitemAdd;

        public event PlayerListitemRemoveHandler PlayerListitemRemove;

        public event PlayerListitemUpdateHandler PlayerListitemUpdate;

        public event LoginSuccessHandler LoginSuccess;

        public event LoginFailureHandler LoginFailure;

        public event JoinGameHandler JoinedGame;

        public event TransactionRejectedHandler TransactionRejected;

        public event TransactionAcceptedHandler TransactionAccepted;

        public event PlayerKickedHandler PlayerKicked;

        public event PingMsReceivedHandler MsPingReceived;

        //public event PingResponseReceivedHandler PingResponseReceived;

        #endregion



        #region Event Messengers

        #region Server Events
        void RaisePlayerlistAdd(string name, short ping)
        {
            if (PlayerListitemAdd != null)
                PlayerListitemAdd(name, ping);
        }

        void RaisePlayerlistRemove(string name)
        {
            if (PlayerListitemRemove != null)
                PlayerListitemRemove(name);
        }

        void RaisePlayerlistUpdate(string name, short ping)
        {
            if (PlayerListitemUpdate != null)
                PlayerListitemUpdate(name, ping);
        }

        void RaisePluginMessage(string channel, byte[] data)
        {
            if (PluginMessage != null)
                PluginMessage(channel, data);
        }

        void RaiseLoginSuccess(object Sender)
        {
            if (LoginSuccess != null)
                LoginSuccess(Sender);
        }

        void RaiseLoginFailure(object Sender, string Reason)
        {
            if (LoginFailure != null)
                LoginFailure(Sender, Reason);
        }

        void RaiseGameJoined()
        {
            if (JoinedGame != null)
                JoinedGame();
        }

        void RaiseTransactionRejected(byte Window_ID, short Action_ID)
        {
            if (TransactionRejected != null)
                TransactionRejected(Window_ID, Action_ID);
        }

        void RaiseTransactionAccepted(byte Window_ID, short Action_ID)
        {
            if (TransactionAccepted != null)
                TransactionAccepted(Window_ID, Action_ID);
        }

        void RaiseKicked(string reason)
        {
            if (PlayerKicked != null)
                PlayerKicked(reason);
        }

        void RaiseExplosion(float X, float Y, float Z)
        {
            if (Explosion != null)
                Explosion(X, Y, Z);
        }

        //void RaisePingResponse(string VersionName, int ProtocolVersion, int MaxPlayers, int OnlinePlayers, string[] PlayersSample, string MOTD, Image Favicon)
        //{
        //    if (PingResponseReceived != null)
        //        PingResponseReceived(VersionName, ProtocolVersion, MaxPlayers, OnlinePlayers, PlayersSample, MOTD, Favicon);
        //}

        void RaisePingMs(int MsPing)
        {
            if (MsPingReceived != null)
                MsPingReceived(MsPing);
        }
        #endregion

        #region Base Events
        void NetworkInfo(object Sender, string Message)
        {
            if (InfoMessage != null)
                InfoMessage(Sender, "(NETWORK): " + Message);
        }

        void NetworkDebug(object Sender, string Message)
        {
            if (DebugMessage != null)
                DebugMessage(Sender, "(NETWORK): " + Message);
        }

        void NetworkError(object Sender, string Message)
        {
            if (ErrorMessage != null)
                ErrorMessage(Sender, "(NETWORK): " + Message);
        }

        void RaisePacketHandled(object Sender, object Packet, int id)
        {
            if (PacketHandled != null)
                PacketHandled(Sender, Packet, id);
        }

        void RaiseError(object Sender, string Message)
        {
            if (ErrorMessage != null)
                ErrorMessage(Sender, Message);
        }

        void RaiseInfo(object Sender, string Message)
        {
            if (InfoMessage != null)
                InfoMessage(Sender, Message);
        }

        void RaiseDebug(object Sender, string Message)
        {
            if (DebugMessage != null)
                DebugMessage(Sender, Message);
        }

        void RaiseMC(object Sender, string McMessage, string Name)
        {
            if (Message != null)
                Message(Sender, McMessage, Name);
        }
        #endregion

        #region Block Events
        void RaiseChestStateChange(byte state, int x, short y, int z)
        {
            if (ChestStateChanged != null)
                ChestStateChanged(state, x, y, z);
        }

        //void RaiseBlockBreakingEvent(Vector Location, int Entity_ID, byte Stage)
        //{
        //    if (BlockBreaking != null)
        //        BlockBreaking(Location, Entity_ID, Stage);
        //}

        void RaiseBlockChangedEvent(int x, byte y, int z, int type, byte data)
        {
            if (BlockChanged != null)
                BlockChanged(x, y, z, type, data);
        }

        void RaisePistonMoved(byte state, byte direction, int x, short y, int z)
        {
            if (PistonMoved != null)
                PistonMoved(state, direction, x, y, z);
        }
        #endregion

        #region World Events
        void RaiseChunkUnload(int X, int Z)
        {
            if (ChunkUnloaded != null)
                ChunkUnloaded(X, Z);
        }

        void RaiseChunkLoad(int X, int Z)
        {
            if (ChunkLoaded != null)
                ChunkLoaded(X, Z);
        }

        void RaiseNoteBlockSound(byte instrument, byte pitch, int x, short y, int z)
        {
            if (NoteBlockPlay != null)
                NoteBlockPlay(instrument, pitch, x, y, z);
        }

        void RaiseGameStateChanged(string eventName, float value)
        {
            if (GameStateChanged != null)
                GameStateChanged(eventName, value);
        }

        void RaiseMultiBlockChange(int Chunk_X, int Chunk_Z)
        {
            if (MultiBlockChange != null)
                MultiBlockChange(Chunk_X, Chunk_Z);
        }
        #endregion

        #region Entity Events
        void RaiseEntityAnimationChanged(object Sender, int Entity_ID, byte Animation)
        {
            if (EntityAnimationChanged != null)
                EntityAnimationChanged(Sender, Entity_ID, Animation);
        }

        void RaiseEntityAttached(int Entity_ID, int Vehicle_ID, bool Leashed)
        {
            if (EntityAttached != null)
                EntityAttached(Entity_ID, Vehicle_ID, Leashed);
        }

        void RaiseEntityDestruction(int Entity_ID)
        {
            if (EntityDestroyed != null)
                EntityDestroyed(Entity_ID);
        }

        void RaiseEntityStatus(int Entity_ID)
        {
            if (EntityStatusChanged != null)
                EntityStatusChanged(Entity_ID);
        }

        //void RaiseEntityEquipment(int Entity_ID, int slot, Item newItem)
        //{
        //    if (EntityEquipmentChanged != null)
        //        EntityEquipmentChanged(Entity_ID, slot, newItem);
        //}

        void RaiseEntityHeadLookChanged(int Entity_ID, byte head_yaw)
        {
            if (EntityHeadLookChanged != null)
                EntityHeadLookChanged(Entity_ID, head_yaw);
        }

        void RaiseEntityLookChanged(int Entity_ID, byte yaw, byte pitch)
        {
            if (EntityLookChanged != null)
                EntityLookChanged(Entity_ID, yaw, pitch);
        }

        void RaiseEntityRelMove(int Entity_ID, int Change_X, int Change_Y, int Change_Z)
        {
            if (EntityRelMove != null)
                EntityRelMove(Entity_ID, Change_X, Change_Y, Change_Z);
        }

        void RaiseEntityTeleport(int Entity_ID, int X, int Y, int Z)
        {
            if (EntityTeleport != null)
                EntityTeleport(Entity_ID, X, Y, Z);
        }

        void RaiseEntityVelocityChanged(int Entity_ID, int X, int Y, int Z)
        {
            if (EntityVelocityChanged != null)
                EntityVelocityChanged(Entity_ID, X, Y, Z);
        }
        #endregion

        #region Player Events
        void RaiseWindowClosed(byte window_ID)
        {
            if (CloseWindow != null)
                CloseWindow(window_ID);
        }

        void RaiseOpenWindow(byte Window_ID, byte Type, string Title, byte slots, bool useTitle)
        {
            if (OpenWindow != null)
                OpenWindow(Window_ID, Type, Title, slots, useTitle);
        }

        void RaiseItemCollected(int item_EID, int collector_eid)
        {
            if (ItemCollected != null)
                ItemCollected(item_EID, collector_eid);
        }

        void RaiseHeldSlotChanged(byte slot)
        {
            if (HeldSlotChanged != null)
                HeldSlotChanged(slot);
        }

        void RaiseLocationChanged()
        {
            if (LocationChanged != null)
                LocationChanged();
        }

        void RaisePlayerRespawn()
        {
            if (PlayerRespawned != null)
                PlayerRespawned();
        }

        void RaiseExperienceUpdate(float expBar, short level, short totalExp)
        {
            if (ExperienceSet != null)
                ExperienceSet(expBar, level, totalExp);
        }

        //void RaiseSetWindowSlot(byte windowid, short slot, Item item)
        //{
        //    if (SetWindowItem != null)
        //        SetWindowItem(windowid, slot, item);
        //}

        //public void RaiseInventoryItem(short slot, Item item)
        //{
        //    if (SetInventoryItem != null)
        //        SetInventoryItem(slot, item);
        //}

        void RaisePlayerHealthUpdate(float health, short hunger, float saturation)
        {
            if (SetPlayerHealth != null)
                SetPlayerHealth(health, hunger, saturation);
        }
        #endregion

        #region Scoreboard Events
        void RaiseScoreBoard(byte position, string name)
        {
            if (DisplayScoreboard != null)
                DisplayScoreboard(position, name);
        }

        void RaiseScoreboardAdd(string name, string value)
        {
            if (ScoreboardObjectiveAdd != null)
                ScoreboardObjectiveAdd(name, value);
        }

        void RaiseScoreboardRemove(string name)
        {
            if (ScoreboardObjectiveRemove != null)
                ScoreboardObjectiveRemove(name);
        }

        void RaiseScoreboardUpdate(string name, string value)
        {
            if (ScoreboardObjectiveUpdate != null)
                ScoreboardObjectiveUpdate(name, value);
        }
        #endregion

        #endregion


    }

}
