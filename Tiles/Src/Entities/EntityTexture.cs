namespace Tiles
{
    public class EntityTexture
    {
        private readonly Texture attackBack;
        private readonly Texture attackFront;
        private readonly Texture attackLeft;
        private readonly Texture attackRight;
        private readonly Texture back;
        private readonly Texture front;
        private readonly Texture left;
        private readonly Texture right;

        public EntityTexture(Texture front, Texture back, Texture left, Texture right, Texture attackFront,
            Texture attackBack, Texture attackLeft, Texture attackRight)
        {
            this.front = front;
            this.back = back;
            this.left = left;
            this.right = right;

            this.attackFront = attackFront;
            this.attackBack = attackBack;
            this.attackLeft = attackLeft;
            this.attackRight = attackRight;
        }

        public void Load(Entity.EntityAction action, Entity.EntityFacing facing)
        {
            if (action == Entity.EntityAction.Walking || action == Entity.EntityAction.Sneaking)
            {
                if (facing == Entity.EntityFacing.Front) front.Load();

                if (facing == Entity.EntityFacing.Back) back.Load();

                if (facing == Entity.EntityFacing.Left) left.Load();

                if (facing == Entity.EntityFacing.Right) right.Load();
            }

            if (action == Entity.EntityAction.Attacking)
            {
                if (facing == Entity.EntityFacing.Front) attackFront.Load();

                if (facing == Entity.EntityFacing.Back) attackBack.Load();

                if (facing == Entity.EntityFacing.Left) attackLeft.Load();

                if (facing == Entity.EntityFacing.Right) attackRight.Load();
            }
        }
    }
}