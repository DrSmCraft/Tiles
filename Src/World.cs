using System;
using System.Collections.Generic;
using LibNoise;
using LibNoise.Filter;
using LibNoise.Primitive;
using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class World
    {
        protected Player player = new Player();

        protected readonly int seed = 1000;
        protected SimplexPerlin simplexPerlin;


        protected List<List<Tile>> tiles = new List<List<Tile>>();
        private readonly Voronoi voronoi;


        public World()
        {

            simplexPerlin = new SimplexPerlin(seed, NoiseQuality.Fast);

            voronoi = new Voronoi();
            voronoi.Primitive3D = simplexPerlin;
            voronoi.Distance = false;

            GenerateTiles(0, 0, (int) Constants.dim.X, (int) Constants.dim.Y);
        }


        private void GenerateTiles(int minX, int minY, int maxX, int maxY)
        {
            for (var i = minY; i < maxY; i++)
            {
                var tempList = new List<Tile>();
                for (var j = minX; j < maxX; j++)
                {
                    var vec = new Vector2(i, j);
                    var z = GenerateTile(i, j);
//                    float v = voronoi.GetValue(i, j, z);


                    if (z < 0.05)
                    {
                        tempList.Add(new WaterTile(vec));
                    }
                    else if (z > 0.05 && z < 0.8)
                    {
                        tempList.Add(new GrassTile(vec));
                    }
                    else if (z > 0.8)
                    {
                        tempList.Add(new StoneTile(vec));
                    }
                }

                tiles.Add(tempList);
            }
        }

        private float GenerateTile(int x, int y)
        {
            return (simplexPerlin.GetValue(x * Constants.generatorZoom, y * Constants.generatorZoom) + 1) / 2;
        }


        public Player GetPlayer()
        {
            return player;
        }

        public Tile GetTileAtCoord(int x, int y)
        {
            try
            {
                return tiles[y][x];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public Tile GetTileAtCoord(Vector2 vec)
        {
            int x = (int) vec.X;
            int y = (int) vec.Y;
            try
            {
                return tiles[y][x];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public List<Tile> GetRow(int y)
        {
            return tiles[y];
        }

        public List<Tile> GetColumn(int x)
        {
            List<Tile> list = new List<Tile>();
            for (int i = 0; i < tiles[i].Count; i++)
            {
                list.Add(tiles[i][x]);
            }

            return list;
        }

        public void GenerateRow(int y, int startX)
        {
            GenerateTiles(startX, (int) (startX + Constants.dim.X), y, y);
        }

        public void GenerateColumn(int x, int startY)
        {
            GenerateTiles(x, x, startY, (int) (startY + Constants.dim.Y));
        }

        public void Render()
        {
            foreach (List<Tile> list in tiles)
            {
                foreach (Tile tile in list)
                {
                    tile.Render();
                }
            }
        }
    }
}