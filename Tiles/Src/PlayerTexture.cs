﻿namespace Tiles
{
    public class PlayerTexture
    {
        private readonly Texture attackFront;
        private readonly Texture attackBack;
        private readonly Texture attackLeft;
        private readonly Texture attackRight;
        private readonly Texture front;
        private readonly Texture back;
        private readonly Texture left;
        private readonly Texture right;

        public PlayerTexture(Texture front, Texture back, Texture left, Texture right, Texture attackFront,
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

        public void Load(Player.PlayerAction action, Player.PlayerFacing facing)
        {
            if (action == Player.PlayerAction.Walking || action == Player.PlayerAction.Sneaking)
            {
                if (facing == Player.PlayerFacing.Front) front.Load();

                if (facing == Player.PlayerFacing.Back) back.Load();

                if (facing == Player.PlayerFacing.Left) left.Load();

                if (facing == Player.PlayerFacing.Right) right.Load();
            }

            if (action == Player.PlayerAction.Attacking)
            {
                if (facing == Player.PlayerFacing.Front) attackFront.Load();

                if (facing == Player.PlayerFacing.Back) attackBack.Load();

                if (facing == Player.PlayerFacing.Left) attackLeft.Load();

                if (facing == Player.PlayerFacing.Right) attackRight.Load();
            }
        }
    }
}