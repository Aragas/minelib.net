using MinecraftClient.Enums;
using MinecraftClient.Network.Packets;

namespace MinecraftClient
{
    public partial class Minecraft
    {
        public bool Ready;

        void RaisePacketHandled(object sender, IPacket packet, int id, ServerState state)
        {
            Ready = true;

            switch (state)
            {
                case Enums.ServerState.Login:
                    break;

                case Enums.ServerState.Play:

                    #region Play
                    switch ((PacketServer)id)
                    {
                        case PacketServer.KeepAlive:
                            OnKeepAlive(packet);
                            break;

                        case PacketServer.JoinGame:
                            OnJoinGame(packet);
                            break;

                        case PacketServer.ChatMessage:
                            OnChatMessage(packet);
                            break;

                        case PacketServer.TimeUpdate:
                            OnTimeUpdate(packet);
                            break;

                        case PacketServer.EntityEquipment:
                            OnEntityEquipment(packet);
                            break;

                        case PacketServer.SpawnPosition:
                            OnSpawnPosition(packet);
                            break;

                        case PacketServer.UpdateHealth:
                            OnUpdateHealth(packet);
                            break;

                        case PacketServer.Respawn:
                            OnRespawn(packet);
                            break;

                        case PacketServer.PlayerPositionAndLook:
                            OnPlayerPositionAndLook(packet);
                            break;

                        case PacketServer.HeldItemChange:
                            OnHeldItemChange(packet);
                            break;

                        case PacketServer.UseBed:
                            OnUseBed(packet);
                            break;

                        case PacketServer.Animation:
                            OnAnimation(packet);
                            break;

                        case PacketServer.SpawnPlayer:
                            OnSpawnPlayer(packet);
                            break;

                        case PacketServer.CollectItem:
                            OnCollectItem(packet);
                            break;

                        case PacketServer.SpawnObject:
                            OnSpawnObject(packet);
                            break;

                        case PacketServer.SpawnMob:
                            OnSpawnMob(packet);
                            break;

                        case PacketServer.SpawnPainting:
                            OnSpawnPainting(packet);
                            break;

                        case PacketServer.SpawnExperienceOrb:
                            OnSpawnExperienceOrb(packet);
                            break;

                        case PacketServer.EntityVelocity:
                            OnEntityVelocity(packet);
                            break;

                        case PacketServer.DestroyEntities:
                            OnDestroyEntities(packet);
                            break;

                        case PacketServer.Entity:
                            OnEntity(packet);
                            break;

                        case PacketServer.EntityRelativeMove:
                            OnEntityRelativeMove(packet);
                            break;

                        case PacketServer.EntityLook:
                            OnEntityLook(packet);
                            break;

                        case PacketServer.EntityLookAndRelativeMove:
                            OnEntityLookAndRelativeMove(packet);
                            break;

                        case PacketServer.EntityTeleport:
                            OnEntityTeleport(packet);
                            break;

                        case PacketServer.EntityHeadLook:
                            OnEntityHeadLook(packet);
                            break;

                        case PacketServer.EntityStatus:
                            OnEntityStatus(packet);
                            break;

                        case PacketServer.AttachEntity:
                            OnAttachEntity(packet);
                            break;

                        case PacketServer.EntityMetadata:
                            OnEntityMetadata(packet);
                            break;

                        case PacketServer.EntityEffect:
                            OnEntityEffect(packet);
                            break;

                        case PacketServer.RemoveEntityEffect:
                            OnRemoveEntityEffect(packet);
                            break;

                        case PacketServer.SetExperience:
                            OnSetExperience(packet);
                            break;

                        case PacketServer.EntityProperties:
                            OnEntityProperties(packet);
                            break;

                        case PacketServer.ChunkData:
                            OnChunkData(packet);
                            break;

                        case PacketServer.MultiBlockChange:
                            OnMultiBlockChange(packet);
                            break;

                        case PacketServer.BlockChange:
                            OnBlockChange(packet);
                            break;

                        case PacketServer.BlockAction:
                            OnBlockAction(packet);
                            break;

                        case PacketServer.BlockBreakAnimation:
                            OnBlockBreakAnimation(packet);
                            break;

                        case PacketServer.MapChunkBulk:
                            OnMapChunkBulk(packet);
                            break;

                        case PacketServer.Explosion:
                            OnExplosion(packet);
                            break;

                        case PacketServer.Effect:
                            OnEffect(packet);
                            break;

                        case PacketServer.SoundEffect:
                            OnSoundEffect(packet);
                            break;

                        case PacketServer.Particle:
                            OnParticle(packet);
                            break;

                        case PacketServer.ChangeGameState:
                            OnChangeGameState(packet);
                            break;

                        case PacketServer.SpawnGlobalEntity:
                            OnSpawnGlobalEntity(packet);
                            break;

                        case PacketServer.OpenWindow:
                            OnOpenWindow(packet);
                            break;

                        case PacketServer.CloseWindow:
                            OnCloseWindow(packet);
                            break;

                        case PacketServer.SetSlot:
                            OnSetSlot(packet);
                            break;

                        case PacketServer.WindowItems:
                            OnWindowItems(packet);
                            break;

                        case PacketServer.WindowProperty:
                            OnWindowProperty(packet);
                            break;

                        case PacketServer.ConfirmTransaction:
                            OnConfirmTransaction(packet);
                            break;

                        case PacketServer.UpdateSign:
                            OnUpdateSign(packet);
                            break;

                        case PacketServer.Maps:
                            OnMaps(packet);
                            break;

                        case PacketServer.UpdateBlockEntity:
                            OnUpdateBlockEntity(packet);
                            break;

                        case PacketServer.SignEditorOpen:
                            OnSignEditorOpen(packet);
                            break;

                        case PacketServer.Statistics:
                            OnStatistics(packet);
                            break;

                        case PacketServer.PlayerListItem:
                            OnPlayerListItem(packet);
                            break;

                        case PacketServer.PlayerAbilities:
                            OnPlayerAbilities(packet);
                            break;

                        case PacketServer.TabComplete:
                            OnTabComplete(packet);
                            break;

                        case PacketServer.ScoreboardObjective:
                            OnScoreboardObjective(packet);
                            break;

                        case PacketServer.UpdateScore:
                            OnUpdateScore(packet);
                            break;

                        case PacketServer.DisplayScoreboard:
                            OnDisplayScoreboard(packet);
                            break;

                        case PacketServer.Teams:
                            OnTeams(packet);
                            break;

                        case PacketServer.PluginMessage:
                            OnPluginMessage(packet);
                            break;

                        case PacketServer.Disconnect:
                            OnDisconnect(packet);
                            break;
                        }
                    #endregion

                    break;

                case Enums.ServerState.Status:
                    break;

                default:
                    if (FirePacketHandled != null)
                        FirePacketHandled(sender, packet, id, state);
                    break;
            }

        }

    }
}
