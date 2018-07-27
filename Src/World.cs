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

        protected Chunk[,] chunkArray;

        public World()
        {
            chunkArray = new Chunk[(int) Constants.dim.Y, (int) Constants.dim.X];
            Console.Out.WriteLine(chunkArray);
            GenerateChunks();
        }

        public void GenerateChunk(int x, int y)
        {
            chunkArray[y / Constants.chunkSize, x / Constants.chunkSize].Generate();
        }

        public void GenerateChunk(Vector2 vec)
        {
            int x = (int) vec.X;
            int y = (int) vec.Y;

            chunkArray[y / Constants.chunkSize, x / Constants.chunkSize].Generate();
        }

        public bool IsChunkGenerated(int x, int y)
        {
            return chunkArray[y / Constants.chunkSize, x / Constants.chunkSize].IsChunkGenerated();
        }

        public bool IsChunkGenerated(Vector2 vec)
        {
            int x = (int) vec.X;
            int y = (int) vec.Y;

            return chunkArray[y / Constants.chunkSize, x / Constants.chunkSize].IsChunkGenerated();
        }

        public Chunk GetChunkAtPlayer()
        {
            return chunkArray[(int) player.GetLocation().Y / Constants.chunkSize,
                (int) player.GetLocation().X / Constants.chunkSize];
        }







        public Player GetPlayer()
        {
            return player;
        }

        private void GenerateChunks()
        {
            for (int i = 0; i < Constants.dim.Y; i++)
            {
                for (int j = 0; j < Constants.dim.X; j++){

                    Chunk c = new Chunk(j * Constants.chunkSize, i * Constants.chunkSize);
                    chunkArray[i, j] = c;
                }
            }
        }

        public Chunk GetChunk(int x, int y)
        {
            return chunkArray[y / Constants.chunkSize, x / Constants.chunkSize];
        }

//        public Tile GetTileAtCoord(int x, int y)
//        {
//            try
//            {
//                return tiles[y][x];
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//
//        }
//
//        public Tile GetTileAtCoord(Vector2 vec)
//        {
//            int x = (int) vec.X;
//            int y = (int) vec.Y;
//            try
//            {
//                return tiles[y][x];
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//
//        }



        public void Render()
        {
            for (int i = 0; i < Constants.dim.Y; i++)
            {
                for (int j = 0; j < Constants.dim.X; j++)
                {
                    if (IsChunkGenerated(i * Constants.chunkSize, j * Constants.chunkSize))
                    {
                        Console.Out.WriteLine(chunkArray[i, j].GetString());
                        chunkArray[i, j].Render();
                    }

                }
            }
        }


    }
}