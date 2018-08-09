using OpenTK;

namespace Tiles.Tiles
{
    public class WoodTile : Tile
    {
        private readonly Vector2 location;

        public WoodTile(Vector2 location) : base(location, Constants.pathColor, Constants.woodTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Wood at <" + location.X + ", " + location.Y + ">";
        }
    }
}