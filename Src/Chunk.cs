using System;
using LibNoise;
using LibNoise.Filter;
using LibNoise.Primitive;
using OpenTK;
using Tiles.Tiles;
using Tiles.Structures;
using Tiles.Util;

namespace Tiles
{
    public class Chunk
    {
        private int seed = Constants.seed;
        private readonly Voronoi voronoi;
        protected Tile[,] array = new Tile[Constants.chunkSize, Constants.chunkSize];
        protected Structure[,] structureArray = new Structure[Constants.chunkSize, Constants.chunkSize];
        protected TilesRandom random = new TilesRandom(Constants.seed);
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
            {
                array[i, j] = GenerateTile(j + x, i + y); // array[i, j] = GenerateTile(j + x, i + y);
//                structureArray[i, j] = GenerateStructure(j + x, i + y);
            }

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

        private Structure GenerateStructure(int x, int y)
        {
            if (array[y, x] is GrassTile)
            {
                if(random.RandomByChance(Constants.treeGenerationFreq))
                {
                    return new TreeStructure(new Vector2(x, y));
                }
            }

            return null;
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
                {
                    for (var j = 0; j < Constants.chunkSize; j++)
                    {
                        array[i, j].Render();
                        try
                        {
                            structureArray[i, j].Render();
                        }
                        catch (Exception e)
                        {
//                            Console.WriteLine(e);
                        }
                    }
                }

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