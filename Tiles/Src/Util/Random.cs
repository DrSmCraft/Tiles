using System;

namespace Tiles.Util
{
    public class TilesRandom : Random
    {
        private int seed;

        public TilesRandom(int seed) : base(seed)
        {
        }

        public object RandomObject(params object[] list)
        {
            return list[Next(0, list.Length)];
        }

        public bool RandomByChance(float chance)
        {
            return Next(100) <= chance * 100;
        }


    }
}