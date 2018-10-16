using OpenTK;
using Tiles.Tiles;

namespace Tiles
{
    public class Entity
    {
        public enum EntityAction
        {
            Attacking,
            Walking,
            Sneaking
        }

        public enum EntityFacing
        {
            Front,
            Back,
            Left,
            Right
        }

        protected int health;

        protected EntityTile entityTile;
        protected EntityAction action;


        protected Vector2 location;
        protected EntityFacing _entityFacing;

        public Entity()
        {
            location = Constants.playerStartPosition;
            health = 10;
            entityTile = new EntityTile(location, Constants.playerTexture);
        }

        public Entity(EntityTexture texture)
        {
            location = Constants.playerStartPosition;
            health = 10;
            entityTile = new EntityTile(location, texture);
        }




        public Vector2 GetLocation()
        {
            return location;
        }

        public Vector2 GetRawLocation()
        {
            return location * (Constants.tileSize / entityTile.GetSize());
        }

        public void Translate(Vector2 moveVector)
        {
            action = EntityAction.Walking;
            location += moveVector;
            entityTile.Translate(moveVector);
        }

        public void Move(Vector2 vec)
        {
            action = EntityAction.Walking;
            location = vec;
            entityTile.Move(vec);
        }

        public void MoveUp()
        {
            action = EntityAction.Walking;
            _entityFacing = EntityFacing.Back;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(0, Constants.playerMoveAmount));
        }

        public void MoveDown()
        {
            action = EntityAction.Walking;
            _entityFacing = EntityFacing.Front;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(0, -Constants.playerMoveAmount));
        }

        public void MoveLeft()
        {
            action = EntityAction.Walking;
            _entityFacing = EntityFacing.Left;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(-Constants.playerMoveAmount, 0));
        }

        public void MoveRight()
        {
            action = EntityAction.Walking;
            _entityFacing = EntityFacing.Right;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(Constants.playerMoveAmount, 0));
        }

        public void SneakUp()
        {
            action = EntityAction.Sneaking;
            _entityFacing = EntityFacing.Back;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(0, Constants.playerSneakAmount));
        }

        public void SneakDown()
        {
            action = EntityAction.Sneaking;
            _entityFacing = EntityFacing.Front;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(0, -Constants.playerSneakAmount));
        }

        public void SneakLeft()
        {
            action = EntityAction.Sneaking;
            _entityFacing = EntityFacing.Left;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(-Constants.playerSneakAmount, 0));
        }

        public void SneakRight()
        {
            action = EntityAction.Sneaking;
            _entityFacing = EntityFacing.Right;
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            Translate(new Vector2(Constants.playerSneakAmount, 0));
        }


        public int GetHealth()
        {
            return health;
        }

        public EntityFacing GetFacing()
        {
            return _entityFacing;
        }

        public void Attack()
        {
            action = EntityAction.Attacking;
        }

        public void SetFacing(EntityFacing facing)
        {
            _entityFacing = facing;
        }

        public void SetAction(EntityAction entityAction)
        {
            action = entityAction;
        }

        public EntityAction GetAction()
        {
            return action;
        }

        public void Render(bool bounderies = false)
        {
            entityTile.SetFacing(_entityFacing);
            entityTile.SetAction(action);
            entityTile.Render(bounderies);
        }
    }
}