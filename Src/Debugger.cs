using System;
using OpenTK;

namespace Tiles
{
    public class Debugger
    {
        public float renderFreq;
        public float updateFreq;
        public int amountChunksGenerated;
        public float gameTime;
        private Game game;


        public Debugger(Game game)
        {
            this.game = game;
            renderFreq = (float) game.RenderFrequency;
            updateFreq = (float) game.UpdateFrequency;
            amountChunksGenerated = game.world.GetAmountChunksGenerated();
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
        }

        public string GetDataAsString()
        { Update();
            return "-------------DEBUG-------------\n" + "Render Frequency: " + renderFreq + "\nUpdate Frequency: " +
                   updateFreq + "\nNumber of Chunks Generated: " + amountChunksGenerated;

        }
    }
}