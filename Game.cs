using System;
using System.Collections.Generic;
using LibNoise;
using LibNoise.Filter;
using LibNoise.Modifier;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using LibNoise.Primitive;
using Tiles.Tiles;


namespace Tiles
{
    public class Game : GameWindow
    {
        private Player player = new Player();
        private KeyboardState keyboardState, lastKeyboardState;

        private int seed;
        private SimplexPerlin simplexPerlin;
        private Voronoi voronoi;


        private List<List<Tile>> tiles = new List<List<Tile>>();

        public Game() : base((int) Constants.windowSize.X, (int) Constants.windowSize.Y, GraphicsMode.Default, "Tiles Game")
        {
            VSync = VSyncMode.On;
            SetupGL();
            seed = 1000;
            simplexPerlin = new SimplexPerlin(seed, NoiseQuality.Fast);

            voronoi = new Voronoi();
            voronoi.Primitive3D = simplexPerlin;
            voronoi.Distance = false;

            GenerateTiles();
        }

        private void SetupGL()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(0, Constants.windowSize.X, 0, Constants.windowSize.Y, -1, 1);
            GL.Viewport(0, 0, (int) Constants.windowSize.X, (int) Constants.windowSize.Y);
        }

        private void GenerateTiles()
        {
            for (int i = 0; i < Constants.dim.Y; i++)
            {
                List<Tile> tempList = new List<Tile>();
                for (int j = 0; j < Constants.dim.X; j++)
                {
                    Vector2 vec = new Vector2(i, j);
                    float z = (simplexPerlin.GetValue(i, j) + 1) / 2;
//                    float v = voronoi.GetValue(i, j, z);


                    if (z < 0.05)
                    {
                        tempList.Add(new WaterTile(vec));
                    }
                    else if (z > 0.05 && z < 0.8)
                    {
                        tempList.Add(new GrassTile(vec));
                    }
                    else if (z > 0.8)
                    {
                        tempList.Add(new StoneTile(vec));
                    }



                }

                tiles.Add(tempList);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Width = (int) Constants.windowSize.X;
            Height = (int) Constants.windowSize.Y;
            player.Translate(new Vector2(8, 8));

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Black and opaque
//            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            foreach (var list in tiles)
            {
                foreach (var tile in list)
                {
//                    Console.Out.WriteLine(tile.ToString());
                    tile.Render();
                }
            }
            player.Render();

            SwapBuffers();

            base.OnRenderFrame(e);


        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState[Constants.moveLeft] && lastKeyboardState[Constants.moveLeft])
            {
                player.MoveLeft();
            }
            if (keyboardState[Constants.moveRight] && lastKeyboardState[Constants.moveRight])
            {
                player.MoveRight();
            }
            if (keyboardState[Constants.moveUp] && lastKeyboardState[Constants.moveUp])
            {
                player.MoveUp();
            }
            if (keyboardState[Constants.moveDown] && lastKeyboardState[Constants.moveDown])
            {
                player.MoveDown();
            }


            lastKeyboardState = keyboardState;

//            Console.Out.WriteLine("Player at <" + player.GetLocation().X + ", " + player.GetLocation().Y + ">");
            base.OnUpdateFrame(e);
        }

//        private bool KeyPress(Key key)
//        {
//            return (keyboardState [key] && (keyboardState [key] != lastKeyboardState [key]) );
//        }


    }
}