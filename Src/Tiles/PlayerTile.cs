using OpenTK;

namespace Tiles.Tiles
{
    public class PlayerTile : Tile
    {
        public PlayerTile(Vector2 location) : base(location, Constants.playerColor)
        {
            vertcies = new[]
            {
                new Vector2((location.X) * Constants.playerSize, (location.Y) * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, (location.Y) * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, (location.Y + 1) * Constants.playerSize),
                new Vector2((location.X) * Constants.playerSize, (location.Y + 1) * Constants.playerSize)
            };
        }

        public override void Translate(Vector2 moveVector)
        {
            location += moveVector;
            vertcies = new[]
            {
                new Vector2((location.X) * Constants.playerSize, (location.Y) * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, (location.Y) * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, (location.Y + 1) * Constants.playerSize),
                new Vector2((location.X) * Constants.playerSize, (location.Y + 1) * Constants.playerSize)
            };

        }
    }
}