using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class Player
    {

        public enum PlayerFacing
        {
            Front, Back, Left, Right
        }
        private Vector2 location;
        private readonly Tile playerTile;
        private PlayerFacing playerFacing;

        public Player()
        {
            location = new Vector2(0, 0);
            playerTile = new PlayerTile(location, Constants.playerTexture);
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
            playerFacing = PlayerFacing.Back;
            Translate(new Vector2(0, Constants.playerMoveAmount));
        }

        public void MoveDown()
        {
            playerFacing = PlayerFacing.Front;
            Translate(new Vector2(0, -Constants.playerMoveAmount));
        }

        public void MoveLeft()
        {
            playerFacing = PlayerFacing.Left
            Translate(new Vector2(-Constants.playerMoveAmount, 0));
        }

        public void MoveRight()
        {
            playerFacing = PlayerFacing.Right;
            Translate(new Vector2(Constants.playerMoveAmount, 0));
        }

        public void Render()
        {
            playerTile.Render();
        }
    }
}