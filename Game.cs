using System;
using System.Collections.Generic;
using LibNoise;
using LibNoise.Filter;
using LibNoise.Primitive;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Tiles.Tiles;

namespace Tiles
{
    public class Game : GameWindow
    {
        private KeyboardState keyboardState, lastKeyboardState;
        private World world;


        public Game() : base((int) Constants.windowSize.X, (int) Constants.windowSize.Y, GraphicsMode.Default,
            "Tiles Game")
        {
            world = new World();
            VSync = VSyncMode.On;
            SetupGL();


        }

        private void SetupGL()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(0, Constants.windowSize.X, 0, Constants.windowSize.Y, -1, 1);
            GL.Viewport(0, 0, (int) Constants.windowSize.X, (int) Constants.windowSize.Y);
        }




        protected override void OnLoad(EventArgs e)
        {
            Width = (int) Constants.windowSize.X;
            Height = (int) Constants.windowSize.Y;
            world.GetPlayer().Translate(new Vector2(8, 8));

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Black and opaque
//            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            world.Render();
            world.GetPlayer().Render();

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState[Key.Escape])
            {
                Exit();
            }
            if (keyboardState[Constants.moveLeft] && lastKeyboardState[Constants.moveLeft]) world.GetPlayer().MoveLeft();
            if (keyboardState[Constants.moveRight] && lastKeyboardState[Constants.moveRight]) world.GetPlayer().MoveRight();
            if (keyboardState[Constants.moveUp] && lastKeyboardState[Constants.moveUp]) world.GetPlayer().MoveUp();
            if (keyboardState[Constants.moveDown] && lastKeyboardState[Constants.moveDown]) world.GetPlayer().MoveDown();


            Console.Out.WriteLine(IsOutsideWindow(world.GetPlayer().GetLocation()));
            Console.Out.WriteLine(world.GetPlayer().GetLocation());




            lastKeyboardState = keyboardState;

            base.OnUpdateFrame(e);
        }

        protected bool IsOutsideWindow(Vector2 vec)
        {
            if (vec.X > Constants.dim.X * 2 || vec.X < 0)
            {
                return true;
            }
            else if (vec.Y > Constants.dim.Y * 2 || vec.Y < 0)
            {
                return true;
            }

            return false;
        }

//        private bool KeyPress(Key key)
//        {
//            return (keyboardState [key] && (keyboardState [key] != lastKeyboardState [key]) );
//        }
    }
}