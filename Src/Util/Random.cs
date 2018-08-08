using System;

namespace Tiles.Util
{
    public class TilesRandom
    {
        private int seed;
        private Random rand;

        public TilesRandom(int seed)
        {
            this.seed = seed;
            rand = new Random(seed);
        }

        public object RandomObject(params object[] list)
        {
            return list[rand.Next(0, list.Length)];
        }

        public bool RandomByChance(float chance)
        {
            return rand.Next(100) <= chance * 100;
        }
    }
}