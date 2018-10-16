using Tiles;


namespace Tiles.Entities
{
    public class Orc : Entity
    {
        public Orc() : base(Constants.orcTexture)
        {
            health = Constants.orcHealth;

        }
    }
}