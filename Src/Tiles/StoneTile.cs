using OpenTK;

namespace Tiles.Tiles
{
    public class StoneTile : Tile
    {
        private Vector2 location;

        public StoneTile(Vector2 location) : base(location, Constants.stoneColor, Constants.stoneTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Stone at <" + location.X + ", " + location.Y + ">";
        }
    }
}