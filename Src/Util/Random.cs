namespace Tiles.Util
{
    public class Random
    {
        public static object RandomObject(params object[] list)
        {
            var rand = new System.Random();
            return list[rand.Next(0, list.Length)];
        }
    }
}