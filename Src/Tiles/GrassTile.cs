using OpenTK;

namespace Tiles.Tiles
{
    public class GrassTile : Tile
    {
        private Vector2 location;
        public GrassTile(Vector2 location) : base(location, Constants.grassColor, new Texture("C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Tiles\\GrassTile.png", 1))
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Grass at <" + location.X + ", " + location.Y + ">";
        }
    }
}