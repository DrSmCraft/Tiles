using System;
using LibNoise;
using LibNoise.Filter;
using LibNoise.Primitive;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Tiles.Structures;
using Tiles.Tiles;
using Tiles.Util;

namespace Tiles
{
    public class Chunk
    {
        private readonly int seed = Constants.seed;
        private readonly Voronoi voronoi;
        protected Tile[,] array = new Tile[Constants.chunkSize, Constants.chunkSize];
        protected bool isGenerated;
        protected bool isPlayerIn; // Is player in this chunk
        protected TilesRandom random = new TilesRandom(Constants.seed);
        protected SimplexPerlin simplexPerlin;
        protected Structure[,] structureArray = new Structure[Constants.chunkSize, Constants.chunkSize];
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
//                structureArray[i, j] = GenerateStructure(j + x, i + y);

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

        public Tile GetTile(int xCoord, int yCoord)
        {
            return array[yCoord, xCoord];
        }

        public Tile GetTile(float xCoord, float yCoord)
        {
            return array[(int) yCoord, (int) xCoord];
        }

        public Tile GetTile(Vector2 vec)
        {
            float xCoord = vec.X;
            float yCoord = vec.Y;
            return array[(int) yCoord, (int) xCoord];
        }

        private Structure GenerateStructure(int x, int y)
        {
            if (array[y, x] is GrassTile)
                if (random.RandomByChance(Constants.treeGenerationFreq))
                    return new TreeStructure(new Vector2(x, y));

            return null;
        }

        public bool IsPlayerInChunk()
        {
            return isPlayerIn;
        }

        public void SetBoolPlayerInChunk(Entity entity)
        {
            var playerX = entity.GetLocation().X;
            var playerY = entity.GetLocation().Y;
            isPlayerIn = playerX >= x && playerX <= x + Constants.tileSize && playerY >= y &&
                         playerY <= y + Constants.tileSize;
        }


        public void Render(bool bounderies = false)
        {
            if (IsChunkGenerated())
                for (var i = 0; i < Constants.chunkSize; i++)
                for (var j = 0; j < Constants.chunkSize; j++)
                {
                    if (bounderies)
                    {
                        RenderChunkBounderies();
                        array[i, j].Render(true);
                    }
                    else
                    {
                        array[i, j].Render(false);
                    }

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

        private void RenderChunkBounderies()
        {
            GL.LineWidth(Constants.tileDebugLineThickness);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(Constants.chunkDebugColor);
            GL.Vertex2(x, y);

            GL.Vertex2(x + Constants.tileSize * Constants.chunkSize, y);

            GL.Vertex2(x + Constants.tileSize * Constants.chunkSize, y + Constants.tileSize * Constants.chunkSize);

            GL.Vertex2(x, y + Constants.tileSize * Constants.chunkSize);
            GL.End();

            GL.Color3(new Vector3(1f, 1f, 1f));
        }

        public bool IsChunkGenerated()
        {
            return isGenerated;
        }

        public string GetString()
        {
            return "Chunk: (" + x + ", " + y + ") " + "Is Generated: " + IsChunkGenerated();
        }

//        public Tile GetTileAtPlayer(Entity entity)
//        {
//            var loc = entity.GetLocation();
//            var size = entity.GetSize();
//
//            var X = (loc.X + size) / 2;
//            var Y = (loc.Y + size) / 2;
//
//            try
//            {
//                return array[(int) (Y - y), (int) (X - x)];
//            }
//            catch (Exception e)
//            {
//                Logger.Log("Attempted to find Tile at Player while Player is not in Chunk");
//                return null;
//            }
//        }
    }
}