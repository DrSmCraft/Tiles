using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tiles.Tiles
{
    public class EntityTile : Tile
    {
        private readonly float size;
        private readonly EntityTexture tex;
        private Entity.EntityAction action;
        private Entity.EntityFacing facing;

        public EntityTile(Vector2 location, EntityTexture tex) : base(location, Constants.playerColor)
        {
            this.tex = tex;
            size = Constants.playerSize;
//            vertcies = new[]
//            {
//                new Vector2(location.X * size, location.Y * size),
//                new Vector2((location.X + 1) * size, location.Y * size),
//                new Vector2((location.X + 1) * size, (location.Y + 1) * size),
//                new Vector2(location.X * size, (location.Y + 1) * size)
//            };

            vertcies = new[]
            {
                new Vector2((location.X * size) - (size / 2), (location.Y * size) - (size / 2)),
                new Vector2((location.X * size)+ (size / 2), (location.Y * size) - (size / 2)),
                new Vector2((location.X * size) + (size / 2), (location.Y * size) + (size / 2)),
                new Vector2((location.X * size) - (size / 2), (location.Y * size) + (size / 2))
            };
        }


        public EntityTile(Vector2 location, EntityTexture tex, float size) : base(location, Constants.playerColor)
        {
            this.tex = tex;
            this.size = size;
            vertcies = new[]
            {
                new Vector2((location.X * size) - (size / 2), (location.Y * size) - (size / 2)),
                new Vector2((location.X * size)+ (size / 2), (location.Y * size) - (size / 2)),
                new Vector2((location.X * size) + (size / 2), (location.Y * size) + (size / 2)),
                new Vector2((location.X * size) - (size / 2), (location.Y * size) + (size / 2))
            };
//            vertcies = new[]
//            {
//                new Vector2(location.X * size, location.Y * size),
//                new Vector2((location.X + 1) * size, location.Y * size),
//                new Vector2((location.X + 1) * size, (location.Y + 1) * size),
//                new Vector2(location.X * size, (location.Y + 1) * size)
//            };
        }

        public float GetSize()
        {
            return size;
        }


        public override void Translate(Vector2 moveVector)
        {
            location += moveVector  * (Constants.tileSize / size);
            vertcies = new[]
            {
                new Vector2((location.X * size) - (size / 2), (location.Y * size) - (size / 2)),
                new Vector2((location.X * size)+ (size / 2), (location.Y * size) - (size / 2)),
                new Vector2((location.X * size) + (size / 2), (location.Y * size) + (size / 2)),
                new Vector2((location.X * size) - (size / 2), (location.Y * size) + (size / 2))
            };

//            vertcies = new[]
//            {
//                new Vector2(location.X * size, location.Y * size),
//                new Vector2((location.X + 1) * size, location.Y * size),
//                new Vector2((location.X + 1) * size, (location.Y + 1) * size),
//                new Vector2(location.X * size, (location.Y + 1) * size)
//            };
        }

        public void Move(Vector2 vec)
        {
            location = vec;
        }

        public Entity.EntityFacing GetFacing()
        {
            return facing;
        }

        public void SetFacing(Entity.EntityFacing facing)
        {
            this.facing = facing;
        }

        public void SetAction(Entity.EntityAction action)
        {
            this.action = action;
        }

        public override void Render(bool bounderies = false)
        {
            if (bounderies) RenderBounderies();
            RenderTexture();
            GL.Color3(new Vector3(1f, 1f, 1f));
        }

        private void RenderTexture()
        {
            tex.Load(action, facing);


            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex2(vertcies[0]);

            GL.TexCoord2(1, 1);
            GL.Vertex2(vertcies[1]);

            GL.TexCoord2(1, 0);
            GL.Vertex2(vertcies[2]);

            GL.TexCoord2(0, 0);
            GL.Vertex2(vertcies[3]);
            GL.End();
            GL.Color3(new Vector3(1f, 1f, 1f));
        }

        public void RenderBounderies()
        {
            GL.LineWidth(Constants.tileDebugLineThickness);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(Constants.playerDebugColor);
            GL.Vertex2(vertcies[0]);

            GL.Vertex2(vertcies[1]);

            GL.Vertex2(vertcies[2]);

            GL.Vertex2(vertcies[3]);
            GL.End();
        }
    }
}