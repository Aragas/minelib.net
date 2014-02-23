﻿using CWrapped;

namespace MinecraftClient.Network.Packets.Server
{
    public struct StatisticsPacket : IPacket
    {
        public int Count;
        public string[] StatisticsName;
        public int[] Value;

        public const byte PacketId = 0x37;
        public byte Id { get { return 0x37; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Count = stream.ReadVarInt();

            StatisticsName = new string[Count];
            Value = new int[Count];
            for (int i = 0; i < Count; i++)
            {
                StatisticsName[i] = stream.ReadString();
                Value[i] = stream.ReadVarInt();
            }
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteVarInt(Count);
            stream.WriteStringArray(StatisticsName);
            stream.WriteIntArray(Value);
            stream.Purge();
        }
    }
}