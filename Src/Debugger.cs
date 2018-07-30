using System;

namespace Tiles
{
    public class Debugger
    {
        public int amountChunksGenerated;
        private readonly Game game;
        public float gameTime;
        public float renderFreq;
        public float updateFreq;
        public Chunk chunkPlayerIsIn;
        public double garbage1, garbage2, garbage3;

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
            renderFreq = (float) game.RenderFrequency;
            updateFreq = (float) game.UpdateFrequency;
            amountChunksGenerated = game.world.GetAmountChunksGenerated();
            chunkPlayerIsIn = game.world.GetChunkAtPlayer();
            garbage1 = GC.CollectionCount(1);
            garbage2 = GC.CollectionCount(2);
            garbage3 = GC.CollectionCount(3);
        }

        public string GetDataAsString()
        {
            Update();
            return "-------------DEBUG-------------\n" + "Render Frequency: " + renderFreq + "\nUpdate Frequency: " +
                   updateFreq + "\nNumber of Chunks Generated: " + amountChunksGenerated + "\nChunkPlayerIsIn: " +
                   chunkPlayerIsIn.GetString() + "\nGarbage 1: " + garbage1 + "\nGarbage 2: " + garbage2 +
                   "\nGarbage 3: " + garbage3;
        }
    }
}