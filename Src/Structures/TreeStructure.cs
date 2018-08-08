using System.Drawing;
using OpenTK;

namespace Tiles.Structures
{
    public class TreeStructure : Structure
    {
        private Vector2 location;

        public TreeStructure(Vector2 location) : base(location, Constants.grassColor, Constants.treeTexture)
        {
            this.location = location;
        }

        public override string ToString()
        {
            return "Tree at <" + location.X + ", " + location.Y + ">";
        }
    }
}