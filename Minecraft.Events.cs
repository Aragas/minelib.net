using System;
using System.Collections.Generic;
using MinecraftClient.BigData;
using MinecraftClient.Enums;
using MinecraftClient.Network;
using MinecraftClient.Network.Packets;
using MinecraftClient.Network.Packets.Server;

namespace MinecraftClient
{
    public partial class Minecraft
    {
        public bool Ready;

        public event PacketHandler OnPacketHandled;

        void RaisePacketHandled(object sender, IPacket packet, int id, ServerState state)
        {
            Ready = true;

            switch (state)
            {
                case Enums.ServerState.Play:
                    switch ((PacketServer) id)
                    {
                        case PacketServer.KeepAlive:
                            KeepAlivePacket KeepAlive = (KeepAlivePacket) packet;
                            Console.WriteLine(KeepAlive.KeepAlive);
                            SendPacket(packet);
                            break;

                        case PacketServer.ChatMessage:
                            ChatMessagePacket ChatMessage = (ChatMessagePacket) packet;
                            Console.WriteLine(ChatMessage.Message);
                            break;

                        case PacketServer.JoinGame:
                            JoinGamePacket JoinGame = (JoinGamePacket)packet;
                            Player.EntityID = JoinGame.EntityID;
                            break;

                        case PacketServer.TimeUpdate:
                            TimeUpdatePacket TimeUpdatet = (TimeUpdatePacket)packet;
                            if (Ready)
                                SendPacket(Player.Packet());
                            break;

                        #region Player part
                        case  PacketServer.PlayerListItem:
                            PlayerListItemPacket PlayerListItem = (PlayerListItemPacket)packet;

                            if (!PlayerList.ContainsKey(PlayerListItem.PlayerName))
                                PlayerList.Add(PlayerListItem.PlayerName, PlayerListItem.Ping);
                            break;

                        case PacketServer.SoundEffect:
                            SoundEffectPacket SoundEffect = (SoundEffectPacket)packet;
                            PlaySound(SoundEffect.SoundName, SoundEffect.X, SoundEffect.Y, 
                                SoundEffect.Z, SoundEffect.Volume, SoundEffect.Pitch);
                            break;

                        case PacketServer.Effect:
                            EffectPacket Effect = (EffectPacket)packet;
                            PlayEffect(Effect.EffectID, Effect.X, Effect.Y, Effect.Z, 
                                Effect.Data, Effect.DisableRelativeVolume);
                            break;

                        case PacketServer.SpawnPosition:
                            SpawnPositionPacket SpawnPosition = (SpawnPositionPacket)packet;
                            Player.SpawnPosition.X = SpawnPosition.X;
                            Player.SpawnPosition.Y = SpawnPosition.Y;
                            Player.SpawnPosition.Z = SpawnPosition.Z;
                            break;

                        case PacketServer.UpdateHealth:
                            UpdateHealthPacket UpdateHealth = (UpdateHealthPacket)packet;
                            Player.Health.Food = UpdateHealth.Food;
                            Player.Health.FoodSaturation = UpdateHealth.FoodSaturation;
                            Player.Health.Health = UpdateHealth.Health;
                            break;

                        case PacketServer.Respawn:
                            RespawnPacket Respawn = (RespawnPacket)packet;
                            break;

                        case PacketServer.PlayerPositionAndLook:
                            PlayerPositionAndLookPacket PlayerPositionAndLook = (PlayerPositionAndLookPacket)packet;
                            if (!Player.Position.Initialized)
                            {
                                Player.Position.X = (int)PlayerPositionAndLook.X;
                                Player.Position.Y = (int)PlayerPositionAndLook.Y;
                                Player.Position.Z = (int)PlayerPositionAndLook.Z;
                                Player.Position.OnGround = PlayerPositionAndLook.OnGround;
                                Player.Look.Yaw = PlayerPositionAndLook.Yaw;
                                Player.Look.Pitch = PlayerPositionAndLook.Pitch;
                            }
                            else
                            {
                                // Change smoothly the last data to new data.
                            }
                            break;

                        case PacketServer.HeldItemChange:
                            HeldItemChangePacket HeldItemChange = (HeldItemChangePacket)packet;
                            Player.HeldItem.Slot = HeldItemChange.Slot;
                            break;

                        case PacketServer.SetExperience:
                            SetExperiencePacket SetExperience = (SetExperiencePacket)packet;
                            Player.Experience.ExperienceBar = SetExperience.ExperienceBar;
                            Player.Experience.Level = SetExperience.Level;
                            Player.Experience.TotalExperience = SetExperience.TotalExperience;
                            break;

                        case PacketServer.PlayerAbilities:
                            PlayerAbilitiesPacket PlayerAbilities = (PlayerAbilitiesPacket)packet;
                            Player.Abilities.Flags = PlayerAbilities.Flags;
                            Player.Abilities.FlyingSpeed = PlayerAbilities.FlyingSpeed;
                            Player.Abilities.WalkingSpeed = PlayerAbilities.WalkingSpeed;
                            break;

                        case PacketServer.Statistics:
                            StatisticsPacket Statistics = (StatisticsPacket)packet;
                            Player.Statistics.Count = Statistics.Count;
                            Player.Statistics.StatisticsName = Statistics.StatisticsName;
                            Player.Statistics.Value = Statistics.Value;
                            break;

                        //case PacketServer.WindowItems:
                        //    WindowItemsPacket WindowItems = (WindowItemsPacket)packet;
                        //    Player.Items.WindowId = WindowItems.WindowId;
                        //    Player.Items.SlotData = WindowItems.SlotData;
                        //    break;

                        case PacketServer.WindowProperty:
                            WindowPropertyPacket WindowProperty = (WindowPropertyPacket)packet;     
                            break;

                        case PacketServer.WindowItems:
                            WindowItemsPacket WindowItems = (WindowItemsPacket)packet;
                            Player.WindowItems(WindowItems.WindowId, WindowItems.SlotData);
                            break;

                        case PacketServer.SetSlot:
                            SetSlotPacket SetSlot = (SetSlotPacket)packet;
                            Player.SetSlot(SetSlot.WindowId, SetSlot.Slot, SetSlot.SlotData);
                            break;

                        #endregion

                        case PacketServer.SpawnObject:
                            SpawnObjectPacket SpawnObject = (SpawnObjectPacket)packet;
                            break;

                        #region Entity part
                            //
                        case PacketServer.Entity:
                            EntityPacket Entity = (EntityPacket)packet;
                            if (!Entities.ContainsKey(Entity.EntityID))
                                Entities.Add(Entity.EntityID, new Entity { EntityID = Entity.EntityID });
                            break;
                            //
                        case PacketServer.EntityStatus:
                            EntityStatusPacket EntityStatus = (EntityStatusPacket)packet;
                            if (!Entities.ContainsKey(EntityStatus.EntityID))
                                Entities.Add(EntityStatus.EntityID, new Entity { EntityID = EntityStatus.EntityID });

                            Entities[EntityStatus.EntityID].Status = EntityStatus.Status;
                            break;
                            //
                        case PacketServer.DestroyEntities:
                            DestroyEntitiesPacket DestroyEntities = (DestroyEntitiesPacket)packet;                         
                            foreach (var t in DestroyEntities.EntityIDs)
                            {
                                Entities.Remove(t);
                            }
                            break;
                            //
                        // For player too!
                        case PacketServer.EntityEffect:
                            EntityEffectPacket EntityEffect = (EntityEffectPacket) packet;
                            if (Player.EntityID == EntityEffect.EntityID)
                            {
                                Player.Effects.Add(new PlayerEffect
                                {
                                    EffectID = EntityEffect.EffectID,
                                    Amplifier = EntityEffect.Amplifier,
                                    Duration = EntityEffect.Duration
                                });
                            }
                            else
                            {
                                if (!Entities.ContainsKey(EntityEffect.EntityID))
                                    Entities.Add(EntityEffect.EntityID, new Entity { EntityID = EntityEffect.EntityID });

                                Entities[EntityEffect.EntityID].Effects.Add(new EntityEffect
                                {
                                    EffectID = EntityEffect.EffectID,
                                    Amplifier = EntityEffect.Amplifier,
                                    Duration = EntityEffect.Duration
                                });
                            }
                            break;

                        case PacketServer.EntityTeleport:
                            EntityTeleportPacket EntityTeleport = (EntityTeleportPacket)packet;
                            break;
                            //
                        case PacketServer.EntityHeadLook:
                            EntityHeadLookPacket EntityHeadLook = (EntityHeadLookPacket)packet;
                            if (!Entities.ContainsKey(EntityHeadLook.EntityID))
                                Entities.Add(EntityHeadLook.EntityID, new Entity { EntityID = EntityHeadLook.EntityID });

                            Entities[EntityHeadLook.EntityID].Look.Yaw = EntityHeadLook.HeadYaw;
                            break;
                            //
                        case PacketServer.EntityLook:
                            EntityLookPacket EntityLook = (EntityLookPacket)packet;
                            if (!Entities.ContainsKey(EntityLook.EntityID))
                                Entities.Add(EntityLook.EntityID, new Entity { EntityID = EntityLook.EntityID });

                            Entities[EntityLook.EntityID].Look.Yaw = EntityLook.Yaw;
                            Entities[EntityLook.EntityID].Look.Pitch = EntityLook.Pitch;
                            break;
                            //
                        case PacketServer.EntityEquipment:
                            EntityEquipmentPacket EntityEquipment = (EntityEquipmentPacket)packet;
                            if (!Entities.ContainsKey(EntityEquipment.EntityID))
                                Entities.Add(EntityEquipment.EntityID, new Entity { EntityID = EntityEquipment.EntityID });

                            Entities[EntityEquipment.EntityID].Equipment.Item = EntityEquipment.Item;
                            Entities[EntityEquipment.EntityID].Equipment.Slot = EntityEquipment.Slot;
                            break;

                        case PacketServer.EntityLookAndRelativeMove:
                            EntityLookAndRelativeMovePacket EntityLookAndRelativeMove = (EntityLookAndRelativeMovePacket)packet;
                            break;

                        case PacketServer.EntityVelocity:
                            EntityVelocityPacket EntityVelocity = (EntityVelocityPacket)packet;
                            break;

                        case PacketServer.EntityRelativeMove:
                            EntityRelativeMovePacket EntityRelativeMove = (EntityRelativeMovePacket) packet;
                            break;

                        #endregion

                        default:
                            if (OnPacketHandled != null)
                                OnPacketHandled(sender, packet, id, state);
                            break;
                    }
                    break;
            }
            
        }


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

        #region Base Events

        public event DebugMessageHandler DebugMessage;

        public event ErrorMessageHandler ErrorMessage;

        public event InfoMessageHandler InfoMessage;

        public event MessageHandler Message;

        #endregion

        #region Block Events

        public event BlockChangedHandler BlockChanged;

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

        public event PlayerListItemAddHandler PlayerListitemAdd;

        public event PlayerListItemRemoveHandler PlayerListitemRemove;

        public event PlayerListItemUpdateHandler PlayerListitemUpdate;

        public event LoginSuccessHandler LoginSuccess;

        public event LoginFailureHandler LoginFailure;

        public event JoinGameHandler JoinedGame;

        public event TransactionRejectedHandler TransactionRejected;

        public event TransactionAcceptedHandler TransactionAccepted;

        public event PlayerKickedHandler PlayerKicked;

        public event PingMsReceivedHandler MsPingReceived;

        //public event PingResponseReceivedHandler PingResponseReceived;

        #endregion
    }

}
