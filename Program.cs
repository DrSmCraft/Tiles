﻿namespace Tiles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run(60.0);
            }
        }
    }
}