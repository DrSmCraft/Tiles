using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Tiles
{
    public class Game : GameWindow
    {
        protected Debugger debugger;
        protected bool displayDebug = false;
        private KeyboardState keyboardState, lastKeyboardState;
        private MouseState mouseState;
        private Vector2 lastPlayerLocation;
        public World world;
        public DateTime startTime;
        public DateTime time;
        public DateTime attackTime;


        public Game() : base((int) Constants.windowSize.X, (int) Constants.windowSize.Y, GraphicsMode.Default,
            "Tiles Game")
        {

            startTime = DateTime.Now;
            time = DateTime.Now;

            world = new World();
            VSync = VSyncMode.On;
            SetupGL();
            debugger = new Debugger(this);
            Console.Out.WriteLine(Constants.baseDirectory);
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
            world.player.Translate(Constants.playerStartPosition);
            world.GenerateChunk(world.player.GetLocation());
            lastPlayerLocation = world.player.GetLocation();
            world.Update();


            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Black and opaque
//            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            world.Render();
            world.player.Render();

            if (displayDebug) debugger.DisplayInformation();


            SwapBuffers();

//            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            time = DateTime.Now;
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            world.SetPlayerInChunk();
            world.Update();
            if (keyboardState[Key.Escape])
            {
                Exit();
            }

            if (keyboardState[Constants.moveLeft] && lastKeyboardState[Constants.moveLeft])
                world.player.MoveLeft();
            if (keyboardState[Constants.moveRight] && lastKeyboardState[Constants.moveRight])
                world.player.MoveRight();
            if (keyboardState[Constants.moveUp] && lastKeyboardState[Constants.moveUp])
                world.player.MoveUp();
            if (keyboardState[Constants.moveDown] && lastKeyboardState[Constants.moveDown])
                world.player.MoveDown();

            if (mouseState[MouseButton.Left])
            {
                attackTime = time;
                world.player.Attack();
            }

            if (CheckElapsedTimeSeconds(attackTime, Constants.attackDelay))
            {
                world.player.SetAction(Player.PlayerAction.Walking);
            }



            if (keyboardState[Key.B] && lastKeyboardState[Key.B] || IsOutsideWindow(world.player.GetLocation()))
                world.player.Move(Constants.playerStartPosition);

            var vec = -1 * (world.player.GetLocation() - lastPlayerLocation);
            var vec1 = new Vector3(vec.X * Constants.tileSize, vec.Y * Constants.tileSize, 0);
            GL.Translate(vec1);

            if (!world.GetChunkAtPlayer().IsChunkGenerated()) world.GenerateChunk(world.player.GetLocation());


            lastKeyboardState = keyboardState;
            lastPlayerLocation = world.player.GetLocation();

//            base.OnUpdateFrame(e);
        }

        protected bool IsOutsideWindow(Vector2 vec)
        {
            if (vec.X > Constants.dim.X * 2 || vec.X < 0)
                return true;
            if (vec.Y > Constants.dim.Y * 2 || vec.Y < 0)
                return true;

            return false;
        }

        protected void FocusOnChunk(Chunk chunk)
        {
            var x = (int) (chunk.GetCoord().X * Constants.tileSize);
            var y = (int) (chunk.GetCoord().Y * Constants.tileSize);
            GL.Ortho(x, y, (int) Constants.windowSize.X + x, (int) Constants.windowSize.Y + y, -1, 1);
        }

        private bool CheckElapsedTimeSeconds(DateTime t, double seconds)
        {
            DateTime ti = t.AddSeconds(seconds);
            if (time.Second > ti.Second)
            {
                return true;
            }

            return false;
        }
    }
}