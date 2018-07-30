using LibNoise;
using LibNoise.Filter;
using LibNoise.Primitive;
using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class Chunk
    {
        private int seed = Constants.seed;
        private readonly Voronoi voronoi;
        protected Tile[,] array = new Tile[Constants.chunkSize, Constants.chunkSize];
        protected bool isGenerated;
        protected bool isPlayerIn; // Is player in this chunk
        protected SimplexPerlin simplexPerlin;
        protected int x, y;


        public Chunk(int x, int y)
        {
            this.x = x;
            this.y = y;


            simplexPerlin = new SimplexPerlin(seed, NoiseQuality.Fast);

            voronoi = new Voronoi();
            voronoi.Primitive3D = simplexPerlin;
            voronoi.Distance = false;
            isGenerated = false;
        }

        public Vector2 GetCoord()
        {
            return new Vector2(x, y);
        }

        public void Generate()
        {
            for (var i = 0; i < Constants.chunkSize; i++)
            for (var j = 0; j < Constants.chunkSize; j++)
                array[i, j] = GenerateTile(j + x, i + y); // array[i, j] = GenerateTile(j + x, i + y);
            isGenerated = true;
        }

        private Tile GenerateTile(int x, int y)
        {
            var z = (simplexPerlin.GetValue(x * Constants.generatorZoom, y * Constants.generatorZoom) + 1) / 2;

            var vec = new Vector2(x, y);
            if (z < 0.05) return new WaterTile(vec);
            if (z > 0.05 && z < 0.8) return new GrassTile(vec);
            if (z > 0.8) return new StoneTile(vec);

            return new DirtTile(vec);
        }

        public bool IsPlayerInChunk()
        {
            return isPlayerIn;
        }

        public void SetPlayerInChunk(Player player)
        {
            float playerX = player.GetLocation().X;
            float playerY = player.GetLocation().Y;
            isPlayerIn = (playerX >= x && playerX <= x + Constants.tileSize) &&
                         (playerY >= y && playerY <= y + Constants.tileSize);
        }


        public void Render()
        {
            if (IsChunkGenerated() && IsPlayerInChunk())
                for (var i = 0; i < Constants.chunkSize; i++)
                for (var j = 0; j < Constants.chunkSize; j++)
                    array[i, j].Render();
        }

        public bool IsChunkGenerated()
        {
            return isGenerated;
        }

        public string GetString()
        {
            return "Chunk: (" + x + ", " + y + ") " + "Is Generated: " + IsChunkGenerated();
        }
    }
}