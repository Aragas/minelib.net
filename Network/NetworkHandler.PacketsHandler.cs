using MinecraftClient.Enums;
using MinecraftClient.Network.Packets;

namespace MinecraftClient.Network
{
    public partial class NetworkHandler
    {
        private void RaisePacketHandled(object sender, IPacket packet, int id, ServerState state)
        {
            if (OnPacketHandled != null)
                OnPacketHandled(sender, packet, id, state);
        }

        private void RaisePacketHandledUnUsed(object sender, IPacket packet, int id, ServerState state)
        {
            switch (state)
            {
                case Enums.ServerState.Login:
                    break;

                case Enums.ServerState.Play:

                    #region Play
                    switch ((PacketServer)id)
                    {
                        case PacketServer.KeepAlive:
                            FireKeepAlive(packet);
                            break;

                        case PacketServer.JoinGame:
                            FireJoinGame(packet);
                            break;

                        case PacketServer.ChatMessage:
                            FireChatMessage(packet);
                            break;

                        case PacketServer.TimeUpdate:
                            FireTimeUpdate(packet);
                            break;

                        case PacketServer.EntityEquipment:
                            FireEntityEquipment(packet);
                            break;

                        case PacketServer.SpawnPosition:
                            FireSpawnPosition(packet);
                            break;

                        case PacketServer.UpdateHealth:
                            FireUpdateHealth(packet);
                            break;

                        case PacketServer.Respawn:
                            FireRespawn(packet);
                            break;

                        case PacketServer.PlayerPositionAndLook:
                            FirePlayerPositionAndLook(packet);
                            break;

                        case PacketServer.HeldItemChange:
                            FireHeldItemChange(packet);
                            break;

                        case PacketServer.UseBed:
                            FireUseBed(packet);
                            break;

                        case PacketServer.Animation:
                            FireAnimation(packet);
                            break;

                        case PacketServer.SpawnPlayer:
                            FireSpawnPlayer(packet);
                            break;

                        case PacketServer.CollectItem:
                            FireCollectItem(packet);
                            break;

                        case PacketServer.SpawnObject:
                            FireSpawnObject(packet);
                            break;

                        case PacketServer.SpawnMob:
                            FireSpawnMob(packet);
                            break;

                        case PacketServer.SpawnPainting:
                            FireSpawnPainting(packet);
                            break;

                        case PacketServer.SpawnExperienceOrb:
                            FireSpawnExperienceOrb(packet);
                            break;

                        case PacketServer.EntityVelocity:
                            FireEntityVelocity(packet);
                            break;

                        case PacketServer.DestroyEntities:
                            FireDestroyEntities(packet);
                            break;

                        case PacketServer.Entity:
                            FireEntity(packet);
                            break;

                        case PacketServer.EntityRelativeMove:
                            FireEntityRelativeMove(packet);
                            break;

                        case PacketServer.EntityLook:
                            FireEntityLook(packet);
                            break;

                        case PacketServer.EntityLookAndRelativeMove:
                            FireEntityLookAndRelativeMove(packet);
                            break;

                        case PacketServer.EntityTeleport:
                            FireEntityTeleport(packet);
                            break;

                        case PacketServer.EntityHeadLook:
                            FireEntityHeadLook(packet);
                            break;

                        case PacketServer.EntityStatus:
                            FireEntityStatus(packet);
                            break;

                        case PacketServer.AttachEntity:
                            FireAttachEntity(packet);
                            break;

                        case PacketServer.EntityMetadata:
                            FireEntityMetadata(packet);
                            break;

                        case PacketServer.EntityEffect:
                            FireEntityEffect(packet);
                            break;

                        case PacketServer.RemoveEntityEffect:
                            FireRemoveEntityEffect(packet);
                            break;

                        case PacketServer.SetExperience:
                            FireSetExperience(packet);
                            break;

                        case PacketServer.EntityProperties:
                            FireEntityProperties(packet);
                            break;

                        case PacketServer.ChunkData:
                            FireChunkData(packet);
                            break;

                        case PacketServer.MultiBlockChange:
                            FireMultiBlockChange(packet);
                            break;

                        case PacketServer.BlockChange:
                            FireBlockChange(packet);
                            break;

                        case PacketServer.BlockAction:
                            FireBlockAction(packet);
                            break;

                        case PacketServer.BlockBreakAnimation:
                            FireBlockBreakAnimation(packet);
                            break;

                        case PacketServer.MapChunkBulk:
                            FireMapChunkBulk(packet);
                            break;

                        case PacketServer.Explosion:
                            FireExplosion(packet);
                            break;

                        case PacketServer.Effect:
                            FireEffect(packet);
                            break;

                        case PacketServer.SoundEffect:
                            FireSoundEffect(packet);
                            break;

                        case PacketServer.Particle:
                            FireParticle(packet);
                            break;

                        case PacketServer.ChangeGameState:
                            FireChangeGameState(packet);
                            break;

                        case PacketServer.SpawnGlobalEntity:
                            FireSpawnGlobalEntity(packet);
                            break;

                        case PacketServer.OpenWindow:
                            FireOpenWindow(packet);
                            break;

                        case PacketServer.CloseWindow:
                            FireCloseWindow(packet);
                            break;

                        case PacketServer.SetSlot:
                            FireSetSlot(packet);
                            break;

                        case PacketServer.WindowItems:
                            FireWindowItems(packet);
                            break;

                        case PacketServer.WindowProperty:
                            FireWindowProperty(packet);
                            break;

                        case PacketServer.ConfirmTransaction:
                            FireConfirmTransaction(packet);
                            break;

                        case PacketServer.UpdateSign:
                            FireUpdateSign(packet);
                            break;

                        case PacketServer.Maps:
                            FireMaps(packet);
                            break;

                        case PacketServer.UpdateBlockEntity:
                            FireUpdateBlockEntity(packet);
                            break;

                        case PacketServer.SignEditorOpen:
                            FireSignEditorOpen(packet);
                            break;

                        case PacketServer.Statistics:
                            FireStatistics(packet);
                            break;

                        case PacketServer.PlayerListItem:
                            FirePlayerListItem(packet);
                            break;

                        case PacketServer.PlayerAbilities:
                            FirePlayerAbilities(packet);
                            break;

                        case PacketServer.TabComplete:
                            FireTabComplete(packet);
                            break;

                        case PacketServer.ScoreboardObjective:
                            FireScoreboardObjective(packet);
                            break;

                        case PacketServer.UpdateScore:
                            FireUpdateScore(packet);
                            break;

                        case PacketServer.DisplayScoreboard:
                            FireDisplayScoreboard(packet);
                            break;

                        case PacketServer.Teams:
                            FireTeams(packet);
                            break;

                        case PacketServer.PluginMessage:
                            FirePluginMessage(packet);
                            break;

                        case PacketServer.Disconnect:
                            FireDisconnect(packet);
                            break;
                    }
                    #endregion

                    break;

                case Enums.ServerState.Status:
                    break;

                default:
                    if (OnPacketHandled != null)
                        OnPacketHandled(sender, packet, id, state);
                    break;
            }

        }

    }
}
