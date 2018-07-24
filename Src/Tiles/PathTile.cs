using OpenTK;

namespace Tiles.Tiles
{
    public class PathTile : Tile
    {
        private Vector2 location;
        public PathTile(Vector2 location) : base(location, Constants.pathColor)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Path at <" + location.X + ", " + location.Y + ">";
        }
    }
}