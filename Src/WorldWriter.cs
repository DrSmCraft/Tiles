

using System.IO;

namespace Tiles
{
    public class WorldWriter{
        public WorldWriter()
        {
            FileStream stream = new FileStream("C:\\Users\\Notebook\\Desktop\\Tiles\\World.tile", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
//            writer.Write("hello");
            writer.Write(5);
            writer.Close();
        }
    }
}





