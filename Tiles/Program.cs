namespace Tiles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var game = new Game())
            {
                Logger.Log("Starting Program");
                game.Run(60.0, 60.0);
            }
        }
    }
}