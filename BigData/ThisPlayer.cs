﻿using System.Collections.Generic;
using MinecraftClient.Data;
using MinecraftClient.Enums;
using MinecraftClient.Network.Packets.Client;

namespace MinecraftClient.BigData
{
    public class ThisPlayer
    {

        public PlayerPacket Packet()
        {
            // Update status about Effects here
            // Update all valuer here.. i think..

            return new PlayerPacket { OnGround = Position.OnGround };
        }

        public int EntityID;

        public PlayerPosition Position;//
        public PlayerLook Look;//
        public PlayerSpawnPosition SpawnPosition;//
        public PlayerAbilities Abilities;
    
        public PlayerHealth Health;//
        public PlayerItems Items;//
        public PlayerHeldItem HeldItem;//
        public PlayerExperience Experience;//
        public PlayerAnimation Animation;///
        public PlayerStatistics Statistics;
        public List<PlayerEffect> Effects;
        public List<PlayerWindow> Windows;
        public PlayerScoreboardObjective ScoreboardObjective;

        public void WindowItems(byte windowId, ItemStack[] slotData)
        {
            if (Items.WindowId == windowId)
                Items.SlotData = slotData;
            
        }

        public void SetSlot(byte windowId, short slot, ItemStack slotData)
        {
            if (Items.WindowId == windowId)
                Items.SlotData[slot] = slotData;

        }

        public void OpenWindow(byte windowId, byte inventoryType, string windowTitle, 
            byte NumberOfSlots, bool UseProvidedWindowTitle, int EntityID = 0)
        {
        }

        public void CloseWindow(byte windowId)
        { 
        }
    }

    public struct PlayerPosition
    {
        public int X, Y, Z;
        public bool OnGround;
        public bool Initialized;
    }

    public struct PlayerSpawnPosition
    {
        public int X, Y, Z;
    }

    public struct PlayerAbilities
    {
        public byte Flags;
        public float FlyingSpeed, WalkingSpeed;
    }

    public struct PlayerLook
    {
        public float Yaw, Pitch;
    }

    public struct PlayerHealth
    {
        public float Health;
        public short Food;
        public float FoodSaturation;
    }

    public struct PlayerItems
    {
        public byte WindowId;
        public ItemStack[] SlotData;
    }

    public struct PlayerHeldItem
    {
        public byte Slot;
    }

    public struct PlayerExperience
    {
        public float ExperienceBar;
        public short Level;
        public short TotalExperience;
    }

    public struct PlayerAnimation
    {
        public Animation Animation;
    }

    public struct PlayerStatistics
    {
        public int Count;
        public string[] StatisticsName;
        public int[] Value;
    }

    public struct PlayerEffect
    {
        public byte EffectID;
        public byte Amplifier;
        public short Duration;
    }

    public struct PlayerWindow
    {
    }

    public struct PlayerScoreboardObjective
    {
        public string ObjectiveName;
        public string ObjectiveValue;
        public string ItemName;
        public int Value;

    }

}
