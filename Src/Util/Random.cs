using System;

namespace Tiles.Util
{
    public class Random
    {
        public static Object RandomObject(params Object[] list)
        {
            System.Random rand = new System.Random();
            return list[rand.Next(0, list.Length)];
        }
    }
}