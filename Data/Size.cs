﻿namespace MinecraftClient.Data
{
    /// <summary>
    /// Represents the size of an object in 3D space.
    /// </summary>
    public struct Size
    {
        public double Depth;
        public double Height;
        public double Width;

        public Size(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        // TODO: More operators
        public static Size operator /(Size a, double b)
        {
            return new Size(a.Width / b, a.Height / b, a.Depth / b);
        }
    }
}