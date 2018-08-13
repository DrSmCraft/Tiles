using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tiles.Tiles
{
    public class PlayerTile : Tile
    {
        private readonly PlayerTexture tex;
        private Player.PlayerAction action;
        private Player.PlayerFacing facing;

        public PlayerTile(Vector2 location, PlayerTexture tex) : base(location, Constants.playerColor)
        {
            this.tex = tex;
            vertcies = new[]
            {
                new Vector2(location.X * Constants.playerSize, location.Y * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, location.Y * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, (location.Y + 1) * Constants.playerSize),
                new Vector2(location.X * Constants.playerSize, (location.Y + 1) * Constants.playerSize)
            };
        }


        public override void Translate(Vector2 moveVector)
        {
            location += moveVector;
            vertcies = new[]
            {
                new Vector2(location.X * Constants.playerSize, location.Y * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, location.Y * Constants.playerSize),
                new Vector2((location.X + 1) * Constants.playerSize, (location.Y + 1) * Constants.playerSize),
                new Vector2(location.X * Constants.playerSize, (location.Y + 1) * Constants.playerSize)
            };
        }

        public void Move(Vector2 vec)
        {
            location = vec;
        }

        public Player.PlayerFacing GetFacing()
        {
            return facing;
        }

        public void SetFacing(Player.PlayerFacing facing)
        {
            this.facing = facing;
        }

        public void SetAction(Player.PlayerAction action)
        {
            this.action = action;
        }

        public override void Render(bool bounderies = false)
        {



            if (bounderies)
            {
                GL.LineWidth(Constants.tileDebugLineThickness);
                GL.Begin(PrimitiveType.LineLoop);
                GL.Color3(Constants.playerDebugColor);
                GL.Vertex2(vertcies[0]);

                GL.Vertex2(vertcies[1]);

                GL.Vertex2(vertcies[2]);

                GL.Vertex2(vertcies[3]);
                GL.End();

                RenderTexture();


            }
            else
            {
                RenderTexture();
            }
            GL.Color3(new Vector3(1f, 1f, 1f));

        }

        public void RenderTexture()
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
    }
}