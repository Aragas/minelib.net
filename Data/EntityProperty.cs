﻿namespace MinecraftClient.Data
{
    public struct EntityProperty
    {
        public EntityProperty(string key, double value)
        {
            Key = key;
            Value = value;
            UnknownList = new EntityPropertyListItem[0];
        }

        public string Key;
        public double Value;
        public EntityPropertyListItem[] UnknownList;
    }
}
