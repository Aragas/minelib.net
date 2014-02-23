using MinecraftClient.Enums;

namespace MinecraftClient.Data
{
    public class Block
    {
        public int ID;
        public string Name;
        public int x;
        public int y;
        public int z;
        public int cx;
        public int cz;

        public Block(int id, int X, int Y, int Z, int CX, int CZ)
        {
            ID = id;
            x = X;
            y = Y;
            z = Z;
            cx = CX;
            cz = CZ;

            Name = ((Blocks)ID).ToString();
        }

    }
}
