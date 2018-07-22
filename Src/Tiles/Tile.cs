using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Tiles.Tiles
{
    public class Tile
    {
        private Vector2 location;
        private Vector3 color;
        private Vector2[] vertcies;
        private float size = Constants.tileSize;

        public Tile(Vector2 location, Vector3 color)
        {
            this.location = location;
            this.color = color;
            vertcies = new[]
            {
                new Vector2((location.X) * Constants.tileSize, (location.Y) * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, (location.Y) * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, (location.Y + 1)* Constants.tileSize),
                new Vector2((location.X) * Constants.tileSize, (location.Y + 1)* Constants.tileSize)
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

        public void Translate(Vector2 moveVector)
        {
            location += moveVector;
            vertcies = new[]
            {
                new Vector2((location.X) * Constants.tileSize, (location.Y) * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, (location.Y) * Constants.tileSize),
                new Vector2((location.X + 1) * Constants.tileSize, (location.Y + 1)* Constants.tileSize),
                new Vector2((location.X) * Constants.tileSize, (location.Y + 1)* Constants.tileSize)
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

        public void Render()
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
        }

        public override string ToString()
        {
            return "Tile at <" + location.X + ", " + location.Y + ">";
        }


    }
}