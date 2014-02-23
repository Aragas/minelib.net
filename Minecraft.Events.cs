using System;
using MinecraftClient.BigData;
using MinecraftClient.Events;
using MinecraftClient.Network.Packets;
using MinecraftClient.Network.Packets.Server;

namespace MinecraftClient
{
    public partial class Minecraft
    {
        #region Events

        public event PacketsHandler FirePacketHandled;

        public event PacketHandler FireKeepAlive;
        public event PacketHandler FireJoinGame;
        public event PacketHandler FireChatMessage;
        public event PacketHandler FireTimeUpdate;
        public event PacketHandler FireEntityEquipment;
        public event PacketHandler FireSpawnPosition;
        public event PacketHandler FireUpdateHealth;
        public event PacketHandler FireRespawn;
        public event PacketHandler FirePlayerPositionAndLook;
        public event PacketHandler FireHeldItemChange;
        public event PacketHandler FireUseBed;
        public event PacketHandler FireAnimation;
        public event PacketHandler FireSpawnPlayer;
        public event PacketHandler FireCollectItem;
        public event PacketHandler FireSpawnObject;
        public event PacketHandler FireSpawnMob;
        public event PacketHandler FireSpawnPainting;
        public event PacketHandler FireSpawnExperienceOrb;
        public event PacketHandler FireEntityVelocity;
        public event PacketHandler FireDestroyEntities;
        public event PacketHandler FireEntity;
        public event PacketHandler FireEntityRelativeMove;
        public event PacketHandler FireEntityLook;
        public event PacketHandler FireEntityLookAndRelativeMove;
        public event PacketHandler FireEntityTeleport;
        public event PacketHandler FireEntityHeadLook;
        public event PacketHandler FireEntityStatus;
        public event PacketHandler FireAttachEntity;
        public event PacketHandler FireEntityMetadata;
        public event PacketHandler FireEntityEffect;
        public event PacketHandler FireRemoveEntityEffect;
        public event PacketHandler FireSetExperience;
        public event PacketHandler FireEntityProperties;
        public event PacketHandler FireChunkData;
        public event PacketHandler FireMultiBlockChange;
        public event PacketHandler FireBlockChange;
        public event PacketHandler FireBlockAction;
        public event PacketHandler FireBlockBreakAnimation;
        public event PacketHandler FireMapChunkBulk;
        public event PacketHandler FireExplosion;
        public event PacketHandler FireEffect;
        public event PacketHandler FireSoundEffect;
        public event PacketHandler FireParticle;
        public event PacketHandler FireChangeGameState;
        public event PacketHandler FireSpawnGlobalEntity;
        public event PacketHandler FireOpenWindow;
        public event PacketHandler FireCloseWindow;
        public event PacketHandler FireSetSlot;
        public event PacketHandler FireWindowItems;
        public event PacketHandler FireWindowProperty;
        public event PacketHandler FireConfirmTransaction;
        public event PacketHandler FireUpdateSign;
        public event PacketHandler FireMaps;
        public event PacketHandler FireUpdateBlockEntity;
        public event PacketHandler FireSignEditorOpen;
        public event PacketHandler FireStatistics;
        public event PacketHandler FirePlayerListItem;
        public event PacketHandler FirePlayerAbilities;
        public event PacketHandler FireTabComplete;
        public event PacketHandler FireScoreboardObjective;
        public event PacketHandler FireUpdateScore;
        public event PacketHandler FireDisplayScoreboard;
        public event PacketHandler FireTeams;
        public event PacketHandler FirePluginMessage;
        public event PacketHandler FireDisconnect;

        #endregion

        #region Voids

        private void OnKeepAlive(IPacket packet)
        {
            KeepAlivePacket KeepAlive = (KeepAlivePacket) packet;
            Console.WriteLine(KeepAlive.KeepAlive);
            SendPacket(packet);
        }

        private void OnJoinGame(IPacket packet)
        {
            JoinGamePacket JoinGame = (JoinGamePacket) packet;
            Player.EntityID = JoinGame.EntityID;
        }

        private void OnChatMessage(IPacket packet)
        {
            ChatMessagePacket ChatMessage = (ChatMessagePacket) packet;
            Console.WriteLine(ChatMessage.Message);
        }

        private void OnTimeUpdate(IPacket packet)
        {
            TimeUpdatePacket TimeUpdatet = (TimeUpdatePacket) packet;
            if (Ready)
                SendPacket(Player.Packet());
        }

        private void OnEntityEquipment(IPacket packet)
        {
            EntityEquipmentPacket EntityEquipment = (EntityEquipmentPacket) packet;
            if (!Entities.ContainsKey(EntityEquipment.EntityID))
                Entities.Add(EntityEquipment.EntityID, new Entity {EntityID = EntityEquipment.EntityID});

            Entities[EntityEquipment.EntityID].Equipment.Item = EntityEquipment.Item;
            Entities[EntityEquipment.EntityID].Equipment.Slot = EntityEquipment.Slot;
        }

        private void OnSpawnPosition(IPacket packet)
        {
            SpawnPositionPacket SpawnPosition = (SpawnPositionPacket) packet;
            Player.SpawnPosition.X = SpawnPosition.X;
            Player.SpawnPosition.Y = SpawnPosition.Y;
            Player.SpawnPosition.Z = SpawnPosition.Z;
        }

        private void OnUpdateHealth(IPacket packet)
        {
            UpdateHealthPacket UpdateHealth = (UpdateHealthPacket) packet;
            Player.Health.Food = UpdateHealth.Food;
            Player.Health.FoodSaturation = UpdateHealth.FoodSaturation;
            Player.Health.Health = UpdateHealth.Health;
        }

        private void OnRespawn(IPacket packet)
        {
            RespawnPacket Respawn = (RespawnPacket) packet;
        }

        private void OnPlayerPositionAndLook(IPacket packet)
        {
            PlayerPositionAndLookPacket PlayerPositionAndLook = (PlayerPositionAndLookPacket) packet;
            if (!Player.Position.Initialized)
            {
                Player.Position.X = (int) PlayerPositionAndLook.X;
                Player.Position.Y = (int) PlayerPositionAndLook.Y;
                Player.Position.Z = (int) PlayerPositionAndLook.Z;
                Player.Position.OnGround = PlayerPositionAndLook.OnGround;
                Player.Look.Yaw = PlayerPositionAndLook.Yaw;
                Player.Look.Pitch = PlayerPositionAndLook.Pitch;
                Player.Position.Initialized = true;
            }
            else
            {
                // Change smoothly the last data to new data.
            }
        }

        private void OnHeldItemChange(IPacket packet)
        {
            HeldItemChangePacket HeldItemChange = (HeldItemChangePacket) packet;
            Player.HeldItem.Slot = HeldItemChange.Slot;
        }

        private void OnUseBed(IPacket packet)
        {
            UseBedPacket UseBed = (UseBedPacket) packet;
        }

        private void OnAnimation(IPacket packet)
        {

        }

        private void OnSpawnPlayer(IPacket packet)
        {

        }

        private void OnCollectItem(IPacket packet)
        {

        }

        private void OnSpawnObject(IPacket packet)
        {
            SpawnObjectPacket SpawnObject = (SpawnObjectPacket) packet;
        }

        private void OnSpawnMob(IPacket packet)
        {

        }

        private void OnSpawnPainting(IPacket packet)
        {

        }

        private void OnSpawnExperienceOrb(IPacket packet)
        {

        }

        private void OnEntityVelocity(IPacket packet)
        {
            EntityVelocityPacket EntityVelocity = (EntityVelocityPacket) packet;
        }

        private void OnDestroyEntities(IPacket packet)
        {
            DestroyEntitiesPacket DestroyEntities = (DestroyEntitiesPacket) packet;
            foreach (var t in DestroyEntities.EntityIDs)
            {
                Entities.Remove(t);
            }
        }

        private void OnEntity(IPacket packet)
        {
            EntityPacket Entity = (EntityPacket) packet;
            if (!Entities.ContainsKey(Entity.EntityID))
                Entities.Add(Entity.EntityID, new Entity {EntityID = Entity.EntityID});
        }

        private void OnEntityRelativeMove(IPacket packet)
        {
            EntityRelativeMovePacket EntityRelativeMove = (EntityRelativeMovePacket) packet;
        }

        private void OnEntityLook(IPacket packet)
        {
            EntityLookPacket EntityLook = (EntityLookPacket) packet;
            if (!Entities.ContainsKey(EntityLook.EntityID))
                Entities.Add(EntityLook.EntityID, new Entity {EntityID = EntityLook.EntityID});

            Entities[EntityLook.EntityID].Look.Yaw = EntityLook.Yaw;
            Entities[EntityLook.EntityID].Look.Pitch = EntityLook.Pitch;
        }

        private void OnEntityLookAndRelativeMove(IPacket packet)
        {
            EntityLookAndRelativeMovePacket EntityLookAndRelativeMove = (EntityLookAndRelativeMovePacket) packet;
        }

        private void OnEntityTeleport(IPacket packet)
        {
            EntityTeleportPacket EntityTeleport = (EntityTeleportPacket) packet;
        }

        private void OnEntityHeadLook(IPacket packet)
        {
            EntityHeadLookPacket EntityHeadLook = (EntityHeadLookPacket) packet;
            if (!Entities.ContainsKey(EntityHeadLook.EntityID))
                Entities.Add(EntityHeadLook.EntityID, new Entity {EntityID = EntityHeadLook.EntityID});

            Entities[EntityHeadLook.EntityID].Look.Yaw = EntityHeadLook.HeadYaw;
        }

        private void OnEntityStatus(IPacket packet)
        {
            EntityStatusPacket EntityStatus = (EntityStatusPacket) packet;
            if (!Entities.ContainsKey(EntityStatus.EntityID))
                Entities.Add(EntityStatus.EntityID, new Entity {EntityID = EntityStatus.EntityID});

            Entities[EntityStatus.EntityID].Status = EntityStatus.Status;
        }

        private void OnAttachEntity(IPacket packet)
        {

        }

        private void OnEntityMetadata(IPacket packet)
        {

        }

        private void OnEntityEffect(IPacket packet)
        {
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
                    Entities.Add(EntityEffect.EntityID, new Entity {EntityID = EntityEffect.EntityID});

                Entities[EntityEffect.EntityID].Effects.Add(new EntityEffect
                {
                    EffectID = EntityEffect.EffectID,
                    Amplifier = EntityEffect.Amplifier,
                    Duration = EntityEffect.Duration
                });
            }
        }

        private void OnRemoveEntityEffect(IPacket packet)
        {

        }

        private void OnSetExperience(IPacket packet)
        {
            SetExperiencePacket SetExperience = (SetExperiencePacket) packet;
            Player.Experience.ExperienceBar = SetExperience.ExperienceBar;
            Player.Experience.Level = SetExperience.Level;
            Player.Experience.TotalExperience = SetExperience.TotalExperience;
        }

        private void OnEntityProperties(IPacket packet)
        {

        }

        private void OnChunkData(IPacket packet)
        {

        }

        private void OnMultiBlockChange(IPacket packet)
        {

        }

        private void OnBlockChange(IPacket packet)
        {

        }

        private void OnBlockAction(IPacket packet)
        {

        }

        private void OnBlockBreakAnimation(IPacket packet)
        {

        }

        private void OnMapChunkBulk(IPacket packet)
        {

        }

        private void OnExplosion(IPacket packet)
        {

        }

        private void OnEffect(IPacket packet)
        {
            EffectPacket Effect = (EffectPacket) packet;
            PlayEffect(Effect.EffectID, Effect.X, Effect.Y, Effect.Z,
                Effect.Data, Effect.DisableRelativeVolume);
        }

        private void OnSoundEffect(IPacket packet)
        {
            SoundEffectPacket SoundEffect = (SoundEffectPacket) packet;
            PlaySound(SoundEffect.SoundName, SoundEffect.X, SoundEffect.Y,
                SoundEffect.Z, SoundEffect.Volume, SoundEffect.Pitch);
        }

        private void OnParticle(IPacket packet)
        {

        }

        private void OnChangeGameState(IPacket packet)
        {

        }

        private void OnSpawnGlobalEntity(IPacket packet)
        {

        }

        private void OnOpenWindow(IPacket packet)
        {

        }

        private void OnCloseWindow(IPacket packet)
        {

        }

        private void OnSetSlot(IPacket packet)
        {
            SetSlotPacket SetSlot = (SetSlotPacket) packet;
            Player.SetSlot(SetSlot.WindowId, SetSlot.Slot, SetSlot.SlotData);
        }

        private void OnWindowItems(IPacket packet)
        {
            WindowItemsPacket WindowItems = (WindowItemsPacket) packet;
            Player.WindowItems(WindowItems.WindowId, WindowItems.SlotData);
        }

        private void OnWindowProperty(IPacket packet)
        {
            WindowPropertyPacket WindowProperty = (WindowPropertyPacket) packet;
        }

        private void OnConfirmTransaction(IPacket packet)
        {

        }

        private void OnUpdateSign(IPacket packet)
        {

        }

        private void OnMaps(IPacket packet)
        {

        }

        private void OnUpdateBlockEntity(IPacket packet)
        {

        }

        private void OnSignEditorOpen(IPacket packet)
        {

        }

        private void OnStatistics(IPacket packet)
        {
            StatisticsPacket Statistics = (StatisticsPacket) packet;
            Player.Statistics.Count = Statistics.Count;
            Player.Statistics.StatisticsName = Statistics.StatisticsName;
            Player.Statistics.Value = Statistics.Value;
        }

        private void OnPlayerListItem(IPacket packet)
        {
            PlayerListItemPacket PlayerListItem = (PlayerListItemPacket) packet;

            if (!PlayerList.ContainsKey(PlayerListItem.PlayerName))
                PlayerList.Add(PlayerListItem.PlayerName, PlayerListItem.Ping);
        }

        private void OnPlayerAbilities(IPacket packet)
        {
            PlayerAbilitiesPacket PlayerAbilities = (PlayerAbilitiesPacket) packet;
            Player.Abilities.Flags = PlayerAbilities.Flags;
            Player.Abilities.FlyingSpeed = PlayerAbilities.FlyingSpeed;
            Player.Abilities.WalkingSpeed = PlayerAbilities.WalkingSpeed;
        }

        private void OnTabComplete(IPacket packet)
        {

        }

        private void OnScoreboardObjective(IPacket packet)
        {

        }

        private void OnUpdateScore(IPacket packet)
        {

        }

        private void OnDisplayScoreboard(IPacket packet)
        {

        }

        private void OnTeams(IPacket packet)
        {

        }

        private void OnPluginMessage(IPacket packet)
        {

        }

        private void OnDisconnect(IPacket packet)
        {

        }

        #endregion

    }
}
