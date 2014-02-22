using System;
using CWrapped;
using MinecraftClient.Data;

namespace MinecraftClient.Network.Packets.Server
{
    public struct EntityPropertiesPacket : IPacket
    {
        public int EntityID;
        public EntityProperty[] Properties;

        public const byte PacketId = 0x20;
        public byte Id { get { return 0x20; } }

        public void ReadPacket(ref Wrapped stream)
        {
            EntityID = stream.readShort();
            var count = stream.readShort();
            if (count < 0)
                throw new InvalidOperationException("Cannot specify less than zero properties.");
            Properties = new EntityProperty[count];
            for (int i = 0; i < count; i++)
            {
                var property = new EntityProperty();
                property.Key = stream.readString();
                property.Value = stream.readDouble();
                var listLength = stream.readShort();
                property.UnknownList = new EntityPropertyListItem[listLength];
                for (int j = 0; j < listLength; j++)
                {
                    var item = new EntityPropertyListItem();
                    item.UUID = stream.readLong();
                    item.Amount = stream.readDouble();
                    //item.Operation = stream.readVarInt();
                    property.UnknownList[j] = item;
                }
                Properties[i] = property;
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.writeVarInt(Id);
            stream.writeVarInt(EntityID);
            stream.writeVarInt(Properties.Length);
            for (int i = 0; i < Properties.Length; i++)
            {
                stream.writeString(Properties[i].Key);
                stream.writeDouble(Properties[i].Value);
                stream.writeShort((short)Properties[i].UnknownList.Length);
                for (int j = 0; j < Properties[i].UnknownList.Length; j++)
                {
                    stream.writeLong(Properties[i].UnknownList[j].UUID);
                    stream.writeDouble(Properties[i].UnknownList[j].Amount);
                    stream.writeVarInt(Properties[i].UnknownList[j].Operation);
                }
            }
            stream.Purge();
        }
    }
}