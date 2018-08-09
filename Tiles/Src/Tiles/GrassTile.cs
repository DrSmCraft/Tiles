using OpenTK;

namespace Tiles.Tiles
{
    public class GrassTile : Tile
    {
        private readonly Vector2 location;

        public GrassTile(Vector2 location) : base(location, Constants.grassColor,
            Constants.grassTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Grass at <" + location.X + ", " + location.Y + ">";
        }
    }
}