using System;

namespace Tiles
{
    public class Debugger
    {
        private readonly Game game;
        public int amountChunksGenerated;
        public Chunk chunkPlayerIsIn;
        public DateTime gameTime;
        public double garbage1, garbage2, garbage3;
        public float renderFreq;
        public DateTime startTime;
        public float updateFreq;

        public Debugger(Game game)
        {
            this.game = game;
            Update();
        }

        public void DisplayInformation()
        {
            Update();
            Console.Out.WriteLine(GetDataAsString());
        }

        public void Update()
        {
            startTime = game.startTime;
            renderFreq = (float) game.RenderFrequency;
            updateFreq = (float) game.UpdateFrequency;
            gameTime = game.time;
            amountChunksGenerated = game.world.GetAmountChunksGenerated();
            chunkPlayerIsIn = game.world.GetChunkAtPlayer();
            garbage1 = GC.CollectionCount(1);
            garbage2 = GC.CollectionCount(2);
            garbage3 = GC.CollectionCount(3);
        }

        public string GetDataAsString()
        {
            Update();
            return "-------------DEBUG-------------\n" + "Start Time: " + startTime + "\nTime: " + gameTime +
                   "\nRender Frequency: " + renderFreq + "\nUpdate Frequency: " +
                   updateFreq + "\nNumber of Chunks Generated: " + amountChunksGenerated + "\nChunkPlayerIsIn: " +
                   chunkPlayerIsIn.GetString() + "\nGarbage 1: " + garbage1 + "\nGarbage 2: " + garbage2 +
                   "\nGarbage 3: " + garbage3;
        }
    }
}