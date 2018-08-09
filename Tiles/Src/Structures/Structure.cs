using OpenTK;
using Tiles.Tiles;

namespace Tiles.Structures
{
    public class Structure : Tile
    {
        private readonly Vector2 location;

        public Structure(Vector2 location, Vector3 color, Texture tex) : base(location, color, tex)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Structure at <" + location.X + ", " + location.Y + ">";
        }
    }
}