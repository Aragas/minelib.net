﻿using System;
using System.Linq;
using MinecraftClient.Network.IO;

// Sending data to server
namespace MinecraftClient.Network.Packets
{
    // Not implemented.
    [Packet(ID = Packet.Player)]
    public class Player : IPacket
    {
        public bool OnGround { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PlayerPosition)]
    public class PlayerPosition : IPacket
    {
        public double X { get; set; }
        public double FeetY { get; set; }
        public double HeadY { get; set; }
        public double Z { get; set; }

        public bool OnGround { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PlayerLook)]
    public class PlayerLook : IPacket
    {
        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public bool OnGround { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PlayerPositionAndLook)]
    public class PlayerPositionAndLook : IPacket
    {
        public double X { get; set; }
        public double FeetY { get; set; }
        public double HeadY { get; set; }
        public double Z { get; set; }

        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public bool OnGround { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PlayerDigging)]
    public class PlayerDigging : IPacket
    {
        public byte Status { get; set; }

        public int X { get; set; }
        public byte Y { get; set; }
        public int Z { get; set; }

        public byte Face { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PlayerBlockPlacement)]
    public class PlayerBlockPlacement : IPacket
    {
        public int X { get; set; }
        public byte Y { get; set; }
        public int Z { get; set; }

        public byte Direction { get; set; }
        //public Slot HeldItem { get; set; }

        public byte CursorX { get; set; }
        public byte CursorY { get; set; }
        public byte CursorZ { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.HeldItemChange)]
    public class HeldItemChange : IPacket
    {
        public short Slot { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.Animation)]
    public class Animation : IPacket
    {
        public int EntityID { get; set; }
        public byte AnimationID { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }


    [Packet(ID = Packet.SteerVehicle)]
    public class SteerVehicle : IPacket
    {
        public float Sideways { get; set; }
        public float Forward { get; set; }
        public bool Jump { get; set; }
        public bool Unmount { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.CloseWindow)]
    public class CloseWindow : IPacket
    {
        public byte WindowID { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.ClickWindow)]
    public class ClickWindow : IPacket
    {
        public byte WindowID { get; set; }
        public short Slot { get; set; }
        public byte Button { get; set; }
        public short ActionID { get; set; }
        public byte Mode { get; set; }
        //public Slot ItemID { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.ConfirmTransaction)]
    public class ConfirmTransaction : IPacket
    {
        public byte WindowID { get; set; }
        public short ActionID { get; set; }
        public bool Accepted { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.CreativeInventoryAction)]
    public class CreativeInventoryAction : IPacket
    {
        private byte _id;
        public short Slot { get; set; }
        //public Slot ItemID { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.EnchantItem)]
    public class EnchantItem : IPacket
    {
        private byte _id;
        public byte WindowID { get; set; }
        //public Slot ItemID { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.UpdateSign)]
    public class UpdateSign : IPacket
    {
        public int X { get; set; }
        public short Y { get; set; }
        public int Z { get; set; }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PlayerAbilities)]
    public class PlayerAbilities : IPacket
    {
        public byte Flags { get; set; }
        public float FlyingSpeed { get; set; }
        public float WalkingSpeed { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.TabComplete)]
    public class TabComplete : IPacket
    {
        public string Text { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.ClientSettings)]
    public class ClientSettings : IPacket
    {
        public string Locale { get; set; }
        public byte ViewDistance { get; set; }
        public byte ChatFlags { get; set; }
        public bool ChatColours { get; set; }
        public byte Difficulty { get; set; }
        public bool ShowCape { get; set; }

        public byte Id
        {
            get { return (byte) GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }

    [Packet(ID = Packet.PluginMessage)]
    public class PluginMessage : IPacket
    {
        public string Channel { get; set; }
        public short Length { get; set; }
        public byte[] Data { get; set; }

        public byte Id
        {
            get { return (byte)GetType().GetCustomAttributes(false).OfType<PacketAttribute>().Single().ID; }
        }

        public void ReadPacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }

        public void WritePacket(MinecraftStream stream)
        {
            throw new NotImplementedException();
        }
    }
}