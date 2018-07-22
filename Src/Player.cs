using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class Player
    {
        private Vector2 location;
        private Tile playerTile;

        public Player()
        {
            location = new Vector2(0, 0);
            playerTile = new PlayerTile(location);
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public void Translate(Vector2 moveVector)
        {
            location += moveVector;
            playerTile.Translate(moveVector);
        }

        public void MoveUp()
        {
            Translate(new Vector2(0, Constants.playerMoveAmount));
        }

        public void MoveDown()
        {
            Translate(new Vector2(0, -Constants.playerMoveAmount));
        }

        public void MoveLeft()
        {
            Translate(new Vector2(-Constants.playerMoveAmount, 0));
        }

        public void MoveRight()
        {
            Translate(new Vector2(Constants.playerMoveAmount, 0));
        }

        public void Render()
        {
            playerTile.Render();
        }
    }
}