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
        public float renderFreq;
        public DateTime startTime;
        public float updateFreq;
        public Player player;
        public Vector2 playerLoc;
        public Player.PlayerAction playerAction;
        public Player.PlayerFacing playerFacing;

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
            player = game.world.player;
            playerLoc = player.GetLocation();
            playerAction = player.GetAction();
            playerFacing = player.GetFacing();
            garbage1 = GC.CollectionCount(1);
            garbage2 = GC.CollectionCount(2);
            garbage3 = GC.CollectionCount(3);
        }

        public string GetDataAsString()
        {
            Update();
            return "-------------DEBUG-------------\n" + "Start Time: " + startTime + "\nTime: " + gameTime +
                   "\nRender Frequency: " + renderFreq + "\nUpdate Frequency: " +
                   updateFreq + "\nNumber of Chunks Generated: " + amountChunksGenerated + "\nPlayer Location: " + playerLoc + "\nChunkPlayerIsIn: " +
                   chunkPlayerIsIn.GetString() + "\nPlayer Action: " + playerAction + "\nPlayer Facing: " + playerFacing + "\nGarbage 1: " + garbage1 + "\nGarbage 2: " + garbage2 +
                   "\nGarbage 3: " + garbage3;
        }
    }
}