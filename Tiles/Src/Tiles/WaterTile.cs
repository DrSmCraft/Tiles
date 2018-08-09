using OpenTK;

namespace Tiles.Tiles
{
    public class WaterTile : Tile
    {
        private readonly Vector2 location;

        public WaterTile(Vector2 location) : base(location, Constants.waterColor, Constants.waterTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Water at <" + location.X + ", " + location.Y + ">";
        }
    }
}