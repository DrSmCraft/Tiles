using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tiles.Tiles
{
    public class Tile
    {
        protected Vector3 color;
        public bool drawTexture;
        protected Vector2 location;
        private float size = Constants.tileSize;
        protected Texture tex;
        protected Vector2[] vertcies;

        public Tile(Vector2 location, Vector3 color, Texture tex)
        {
            this.location = location;
            this.color = color;
            this.tex = tex;
            drawTexture = true;
            vertcies = new[]
            {
                new Vector2(location.X * Constants.tileSize, location.Y * Constants.tileSize), // Top Left
                new Vector2((location.X + 1) * Constants.tileSize, location.Y * Constants.tileSize), // Top Right
                new Vector2((location.X + 1) * Constants.tileSize,
                    (location.Y + 1) * Constants.tileSize), // Bottom Right
                new Vector2(location.X * Constants.tileSize, (location.Y + 1) * Constants.tileSize) // Bottom Left
            };
        }

        public Tile(Vector2 location, Vector3 color)
        {
            this.location = location;
            this.color = color;
            drawTexture = false;
            vertcies = new[]
            {
                new Vector2(location.X * Constants.tileSize, location.Y * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, location.Y * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, (location.Y + 1) * Constants.tileSize),
                new Vector2(location.X * Constants.tileSize, (location.Y + 1) * Constants.tileSize)
            };
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public Vector3 GetColor()
        {
            return color;
        }

        public void SetColor(Vector3 vec)
        {
            color = vec;
        }

        public void SetColor(float r, float g, float b)
        {
            color = new Vector3(r, g, b);
        }

        public virtual void Translate(Vector2 moveVector)
        {
            location += moveVector;
            vertcies = new[]
            {
                new Vector2(location.X * Constants.tileSize, location.Y * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, location.Y * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, (location.Y + 1) * Constants.tileSize),
                new Vector2(location.X * Constants.tileSize, (location.Y + 1) * Constants.tileSize)
            };
        }

        public void MoveUp()
        {
            Translate(new Vector2(0, Constants.tileMoveAmount));
        }

        public void MoveDown()
        {
            Translate(new Vector2(0, -Constants.tileMoveAmount));
        }

        public void MoveLeft()
        {
            Translate(new Vector2(-Constants.tileMoveAmount, 0));
        }

        public void MoveRight()
        {
            Translate(new Vector2(Constants.tileMoveAmount, 0));
        }

        public virtual void Render(bool bounderies = false)
        {
            if (!drawTexture)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(color);
                GL.Vertex2(vertcies[0]);

                GL.Color3(color);
                GL.Vertex2(vertcies[1]);

                GL.Color3(color);
                GL.Vertex2(vertcies[2]);

                GL.Color3(color);
                GL.Vertex2(vertcies[3]);
                GL.End();
                GL.Color3(new Vector3(1f, 1f, 1f));
            }
            else
            {
                RenderTexture();
            }

            if (bounderies)
            {
                RenderTexture();

                GL.LineWidth(Constants.tileDebugLineThickness);
                GL.Begin(PrimitiveType.LineLoop);
                GL.Color3(Constants.tilesDebugColor);
                GL.Vertex2(vertcies[0]);

                GL.Vertex2(vertcies[1]);

                GL.Vertex2(vertcies[2]);

                GL.Vertex2(vertcies[3]);
                GL.End();
            }
            GL.Color3(new Vector3(1f, 1f, 1f));

        }

        private void RenderTexture()
        {
            tex.Load();
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);
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

        public override string ToString()
        {
            return "Tile at <" + location.X + ", " + location.Y + ">";
        }
    }
}