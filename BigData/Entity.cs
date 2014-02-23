using System.Collections.Generic;
using MinecraftClient.Data;
using MinecraftClient.Enums;

namespace MinecraftClient.BigData
{
    public class Entity
    {
        public int EntityID;
        public Metadata Metadata;

        public EntityStatus Status;

        public EntityEquipment Equipment;
        public EntityUseBed UseBed;
        public EntityAnimation Animation;
        public EntityPosition Position;
        public EntityLook Look;
        public List<EntityEffect> Effects;
    }

    public struct EntityEquipment
    {
        public EntityEquipmentSlot Slot;
        public ItemStack Item;

        public short CurrentItem;
    }

    public struct EntityUseBed
    {
        public int X;
        public byte Y;
        public int Z;
    }

    public struct EntityAnimation
    {
        public Animation Animation;
    }

    public struct EntityPosition
    {
        public int X, Y, Z;
    }

    public struct EntityLook
    {
        public byte Yaw, Pitch;
    }

    public struct EntityEffect
    {
        public byte EffectID;
        public byte Amplifier;
        public short Duration;
    }

}
