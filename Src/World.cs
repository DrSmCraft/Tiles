using System;
using OpenTK;

namespace Tiles
{
    public class World
    {
        protected Chunk[,] chunkArray;
        protected Player player = new Player();

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
            var x = (int) vec.X;
            var y = (int) vec.Y;

            chunkArray[y / Constants.chunkSize, x / Constants.chunkSize].Generate();
        }

        public bool IsChunkGenerated(int x, int y)
        {
            return chunkArray[y / Constants.chunkSize, x / Constants.chunkSize].IsChunkGenerated();
        }

        public bool IsChunkGenerated(Vector2 vec)
        {
            var x = (int) vec.X;
            var y = (int) vec.Y;

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
            for (var i = 0; i < Constants.dim.Y; i++)
            for (var j = 0; j < Constants.dim.X; j++)
            {
                var c = new Chunk(j * Constants.chunkSize, i * Constants.chunkSize);
                chunkArray[i, j] = c;
            }
        }

        public Chunk GetChunk(int x, int y)
        {
            return chunkArray[y / Constants.chunkSize, x / Constants.chunkSize];
        }

        public int GetAmountChunksGenerated()
        {
            var amount = 0;
            for (var i = 0; i < Constants.dim.Y; i++)
            for (var j = 0; j < Constants.dim.X; j++)
                if (chunkArray[i, j].IsChunkGenerated())
                    amount += 1;
            return amount;
        }

        public void Render()
        {
            for (var i = 0; i < Constants.dim.Y; i++)
            for (var j = 0; j < Constants.dim.X; j++)
                chunkArray[i, j].Render();
        }
    }
}