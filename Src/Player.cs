using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class Player
    {
        public enum PlayerAction
        {
            None,
            Hurting
        }

        public enum PlayerFacing
        {
            Front,
            Back,
            Left,
            Right
        }

        private readonly int health;

        private readonly PlayerTile playerTile;
        private PlayerAction action;

        // Website used to generate charecter sprite
        // http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/#
        // http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/#?clothes=longsleeve_brown&legs=pants_teal&mail=chain&nose=straight&ears=big&shoes=boots_golden&weapon=none&hair=plain_dark_blonde&belt=leather&hat=cap_leather
        private Vector2 location;
        private PlayerFacing playerFacing;

        public Player()
        {
            location = new Vector2(0, 0);
            health = 10;
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

        public void Move(Vector2 vec)
        {
            location = vec;
            playerTile.Move(vec);
        }

        public void MoveUp()
        {
            playerFacing = PlayerFacing.Back;
            playerTile.SetFacing(playerFacing);
            Translate(new Vector2(0, Constants.playerMoveAmount));
        }

        public void MoveDown()
        {
            playerFacing = PlayerFacing.Front;
            playerTile.SetFacing(playerFacing);
            Translate(new Vector2(0, -Constants.playerMoveAmount));
        }

        public void MoveLeft()
        {
            playerFacing = PlayerFacing.Left;
            playerTile.SetFacing(playerFacing);
            Translate(new Vector2(-Constants.playerMoveAmount, 0));
        }

        public void MoveRight()
        {
            playerFacing = PlayerFacing.Right;
            playerTile.SetFacing(playerFacing);
            Translate(new Vector2(Constants.playerMoveAmount, 0));
        }

        public int GetHealth()
        {
            return health;
        }

        public PlayerFacing GetFacing()
        {
            return playerFacing;
        }

        public void SetFacing(PlayerFacing facing)
        {
            playerFacing = facing;
        }

        public void Render()
        {
            playerTile.Render();
        }
    }
}