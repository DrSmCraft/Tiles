using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class Player
    {
        public enum PlayerAction
        {
            Attacking,
            Walking,
            Sneaking
        }

        public enum PlayerFacing
        {
            Front,
            Back,
            Left,
            Right
        }

        private readonly int health;
        private PlayerAction action;


        private Vector2 location;
        private PlayerFacing playerFacing;

        private readonly PlayerTile playerTile;

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
            action = PlayerAction.Walking;
            location += moveVector;
            playerTile.Translate(moveVector);
        }

        public void Move(Vector2 vec)
        {
            action = PlayerAction.Walking;
            location = vec;
            playerTile.Move(vec);
        }

        public void MoveUp()
        {
            action = PlayerAction.Walking;
            playerFacing = PlayerFacing.Back;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(0, Constants.playerMoveAmount));
        }

        public void MoveDown()
        {
            action = PlayerAction.Walking;
            playerFacing = PlayerFacing.Front;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(0, -Constants.playerMoveAmount));
        }

        public void MoveLeft()
        {
            action = PlayerAction.Walking;
            playerFacing = PlayerFacing.Left;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(-Constants.playerMoveAmount, 0));
        }

        public void MoveRight()
        {
            action = PlayerAction.Walking;
            playerFacing = PlayerFacing.Right;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(Constants.playerMoveAmount, 0));
        }

        public void SneakUp()
        {
            action = PlayerAction.Sneaking;
            playerFacing = PlayerFacing.Back;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(0, Constants.playerSneakAmount));
        }

        public void SneakDown()
        {
            action = PlayerAction.Sneaking;
            playerFacing = PlayerFacing.Front;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(0, -Constants.playerSneakAmount));
        }

        public void SneakLeft()
        {
            action = PlayerAction.Sneaking;
            playerFacing = PlayerFacing.Left;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(-Constants.playerSneakAmount, 0));
        }

        public void SneakRight()
        {
            action = PlayerAction.Sneaking;
            playerFacing = PlayerFacing.Right;
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            Translate(new Vector2(Constants.playerSneakAmount, 0));
        }


        public int GetHealth()
        {
            return health;
        }

        public PlayerFacing GetFacing()
        {
            return playerFacing;
        }

        public void Attack()
        {
            action = PlayerAction.Attacking;
        }

        public void SetFacing(PlayerFacing facing)
        {
            playerFacing = facing;
        }

        public void SetAction(PlayerAction playerAction)
        {
            action = playerAction;
        }

        public PlayerAction GetAction()
        {
            return action;
        }

        public void Render(bool bounderies = false)
        {
            playerTile.SetFacing(playerFacing);
            playerTile.SetAction(action);
            playerTile.Render(bounderies);
        }
    }
}