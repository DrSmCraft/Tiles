using OpenTK;

namespace Tiles.Tiles
{
    public class LeavesTile : Tile
    {
        private Vector2 location;

        public LeavesTile(Vector2 location) : base(location, Constants.pathColor, Constants.leavesTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Leaves at <" + location.X + ", " + location.Y + ">";
        }
    }
}