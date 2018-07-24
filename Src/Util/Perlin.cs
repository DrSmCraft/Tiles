using LibNoise.Primitive;

namespace Tiles.Util
{
    public class Perlin
    {
        public Perlin()
        {
            var perlin = new SimplexPerlin();
            perlin.Seed = 1;
            perlin.GetValue(1, 2);
        }
    }
}