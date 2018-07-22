namespace Tiles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (Game game = new Game())
            {
                game.Run(60.0);
            }
        }
    }
}