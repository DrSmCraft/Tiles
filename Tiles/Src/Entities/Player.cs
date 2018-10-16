namespace Tiles.Entities
{
    public class Player : Entity
    {
        public Player() : base(Constants.playerTexture)
        {
            health = Constants.playerHealth;
        }


        public float GetPlayerSize()
        {
            return entityTile.GetSize();
        }
    }
}