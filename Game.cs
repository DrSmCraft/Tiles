using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Tiles
{
    public class Game : GameWindow
    {
        protected Debugger debugger;
        protected bool displayDebug = true;
        private KeyboardState keyboardState, lastKeyboardState;
        private Vector2 lastPlayerLocation;
        public World world;


        public Game() : base((int) Constants.windowSize.X, (int) Constants.windowSize.Y, GraphicsMode.Default,
            "Tiles Game")
        {
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
            world.GetPlayer().Translate(Constants.playerStartPosition);
            world.GenerateChunk(world.GetPlayer().GetLocation());
            lastPlayerLocation = world.GetPlayer().GetLocation();
//            Console.Out.WriteLine(world.GetPlayer().GetLocation());
//            Console.Out.WriteLine(world.IsChunkGenerated(0, 0));


            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Black and opaque
//            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            world.Render();
            world.GetPlayer().Render();

            if (displayDebug) debugger.DisplayInformation();


            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            keyboardState = Keyboard.GetState();
            world.SetPlayerInChunk();
            if (keyboardState[Key.Escape])
            {
                Exit();
            }

            if (keyboardState[Constants.moveLeft] && lastKeyboardState[Constants.moveLeft])
                world.GetPlayer().MoveLeft();
            if (keyboardState[Constants.moveRight] && lastKeyboardState[Constants.moveRight])
                world.GetPlayer().MoveRight();
            if (keyboardState[Constants.moveUp] && lastKeyboardState[Constants.moveUp]) world.GetPlayer().MoveUp();
            if (keyboardState[Constants.moveDown] && lastKeyboardState[Constants.moveDown])
                world.GetPlayer().MoveDown();


            if (keyboardState[Key.B] && lastKeyboardState[Key.B] || IsOutsideWindow(world.GetPlayer().GetLocation()))
                world.GetPlayer().Move(Constants.playerStartPosition);

            var vec = -1 * (world.GetPlayer().GetLocation() - lastPlayerLocation);
            var vec1 = new Vector3(vec.X * Constants.tileSize, vec.Y * Constants.tileSize, 0);
            GL.Translate(vec1);

            if (!world.GetChunkAtPlayer().IsChunkGenerated()) world.GenerateChunk(world.GetPlayer().GetLocation());


            lastKeyboardState = keyboardState;
            lastPlayerLocation = world.GetPlayer().GetLocation();

            base.OnUpdateFrame(e);
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
    }
}