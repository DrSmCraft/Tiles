using System;
using OpenTK;

namespace Tiles
{
    public class Debugger
    {
        private readonly Game game;
        public int amountChunksGenerated;
        public Chunk chunkPlayerIsIn;
        public DateTime gameTime;
        public double garbage1, garbage2, garbage3;
        public Entity Entity;
        public Entity.EntityAction EntityAction;
        public Entity.EntityFacing EntityFacing;
        public Vector2 playerLoc;
        public float renderFreq;
        public float renderTime;
        public DateTime startTime;
        public float updateFreq;
        public float updateTime;

        public Debugger(Game game)
        {
            this.game = game;
            Update();
        }

        public void DisplayInformation()
        {
            Update();
            var info = GetDataAsString();
            Logger.Log(info);
            Console.Out.WriteLine(info);
        }

        public void Update()
        {
            startTime = game.startTime;
            renderFreq = (float) game.RenderFrequency;
            renderTime = (float) game.renderTime;
            updateFreq = (float) game.UpdateFrequency;
            updateTime = (float) game.updateTime;

            gameTime = game.time;
            amountChunksGenerated = game.world.GetAmountChunksGenerated();
            chunkPlayerIsIn = game.world.GetChunkAtPlayer();
            Entity = game.world.player;
            playerLoc = Entity.GetLocation();
            EntityAction = Entity.GetAction();
            EntityFacing = Entity.GetFacing();
            garbage1 = GC.CollectionCount(1);
            garbage2 = GC.CollectionCount(2);
            garbage3 = GC.CollectionCount(3);
        }

        public string GetDataAsString()
        {
            Update();
            return "-------------DEBUG-------------\n" + "Start Time: " + startTime + "\nTime: " + gameTime +
                   "\nRender Frequency: " + renderFreq + "\nRender Time: " + renderTime + "\nUpdate Frequency: " +
                   updateFreq + "\nUpdate Time: " + updateTime + "\nNumber of Chunks Generated: " +
                   amountChunksGenerated + "\nPlayer Location: " +
                   playerLoc + "\nChunkPlayerIsIn: " +
                   chunkPlayerIsIn.GetString() + "\nPlayer Action: " + EntityAction + "\nPlayer Facing: " +
                   EntityFacing + "\nGarbage 1: " + garbage1 + "\nGarbage 2: " + garbage2 +
                   "\nGarbage 3: " + garbage3;
        }
    }
}