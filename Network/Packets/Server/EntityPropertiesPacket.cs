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
            EntityID = stream.ReadShort();
            var count = stream.ReadShort();
            if (count < 0)
                throw new InvalidOperationException("Cannot specify less than zero properties.");
            Properties = new EntityProperty[count];
            for (int i = 0; i < count; i++)
            {
                var property = new EntityProperty();
                property.Key = stream.ReadString();
                property.Value = stream.ReadDouble();
                var listLength = stream.ReadShort();
                property.UnknownList = new EntityPropertyListItem[listLength];
                for (int j = 0; j < listLength; j++)
                {
                    var item = new EntityPropertyListItem();
                    item.UUID = stream.ReadLong();
                    item.Amount = stream.ReadDouble();
                    item.Operation = stream.ReadByte();
                    property.UnknownList[j] = item;
                }
                Properties[i] = property;
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteVarInt(EntityID);
            stream.WriteVarInt(Properties.Length);
            for (int i = 0; i < Properties.Length; i++)
            {
                stream.WriteString(Properties[i].Key);
                stream.WriteDouble(Properties[i].Value);
                stream.WriteShort((short)Properties[i].UnknownList.Length);
                for (int j = 0; j < Properties[i].UnknownList.Length; j++)
                {
                    stream.WriteLong(Properties[i].UnknownList[j].UUID);
                    stream.WriteDouble(Properties[i].UnknownList[j].Amount);
                    stream.WriteByte(Properties[i].UnknownList[j].Operation);
                }
            }
            stream.Purge();
        }
    }
}