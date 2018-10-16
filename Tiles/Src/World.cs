using System;
using OpenTK;
using Tiles.Entities;
using Tiles.Tiles;
using Tiles.Util;

namespace Tiles
{
    public class World
    {
        protected Chunk[,] chunkArray;
        public Player player = new Player();
        public Entity[] entities;
        protected Chunk[] renderBuffer;
        protected int seed = Constants.seed;

        public World()
        {

            chunkArray = new Chunk[(int) Constants.dim.Y, (int) Constants.dim.X];
            renderBuffer = new Chunk[Constants.chunksVisable];
            CreateChunks();

            entities = new Entity[Constants.maxEntityNumber];
            GenerateEntities();
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
            return chunkArray[(int) (player.GetRawLocation().Y / Constants.chunkSize),
                (int) (player.GetRawLocation().X / Constants.chunkSize)];
        }

        public Tile GetTileAtPlayer() // TODO This Method needs to be tested
        {
            return GetChunkAtPlayer().GetTile(player.GetLocation());
        }

        public Tile GetTilePlayerFacing() // TODO This Method needs to be tested too
        {
            var t = GetTileAtPlayer();
            var facing = player.GetFacing();
            if (facing == Entity.EntityFacing.Front)
                return GetChunkAtPlayer().GetTile(player.GetLocation().X, player.GetLocation().Y + 1);
            if (facing == Entity.EntityFacing.Back)
                return GetChunkAtPlayer().GetTile(player.GetLocation().X, player.GetLocation().Y - 1);
            if (facing == Entity.EntityFacing.Left)
                return GetChunkAtPlayer().GetTile(player.GetLocation().X - 1, player.GetLocation().Y);
            if (facing == Entity.EntityFacing.Right)
                return GetChunkAtPlayer().GetTile(player.GetLocation().X + 1, player.GetLocation().Y);

            return null;
        }


        public Entity GetPlayer()
        {
            return player;
        }

        private void CreateChunks()
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

        public void SetBoolPlayerInChunk()
        {
            for (var i = 0; i < Constants.dim.Y; i++)
            for (var j = 0; j < Constants.dim.X; j++)
                chunkArray[i, j].SetBoolPlayerInChunk(player);
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

        private void GenerateEntities()
        {
            Random rand = new TilesRandom(Constants.seed);
            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] = new Orc();
                entities[i].Translate(new Vector2(rand.Next(0, 20), rand.Next(0, 20)));
            }

        }

        public void Update()
        {
            renderBuffer[0] = GetChunkAtPlayer();

        }

        public void Render(bool bounderies = false)
        {
            foreach (var chunk in renderBuffer)
                if (bounderies)
                    chunk.Render(true);
                else
                    chunk.Render(false);
        }
    }
}