using OpenTK;

namespace Tiles.Tiles
{
    public class DirtTile : Tile
    {
        private Vector2 location;

        public DirtTile(Vector2 location) : base(location, Constants.pathColor, Constants.dirtTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Path at <" + location.X + ", " + location.Y + ">";
        }
    }
}