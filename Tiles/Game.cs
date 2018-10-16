using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Tiles
{
    public class Game : GameWindow
    {
        public DateTime attackTime;
        protected Debugger debugger;
        protected bool displayDebug;
//        private KeyboardState Keyboard, Keyboard;
        private Vector2 lastPlayerLocation;
//        private MouseState Mouse;
        public double renderTime, updateTime;
        public DateTime startTime;
        public DateTime time;
        public World world;



        public Game() : base((int) Constants.windowSize.X, (int) Constants.windowSize.Y, GraphicsMode.Default,
            "Tiles Game")
        {
            Logger.Log("Game Class Initializing");
            startTime = DateTime.Now;
            time = DateTime.Now;


            world = new World();
            VSync = VSyncMode.On;
            SetupGL();
            debugger = new Debugger(this);
        }

        private void SetupGL()
        {
            Logger.Log("Setting Up OpenGL");
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(0, Width, 0, Height, -1, 1);
            GL.Viewport(0, 0, Width, Height);




        }


        protected override void OnLoad(EventArgs e)
        {
            Logger.Log("Initializing OpenGL");

            Width = (int) Constants.windowSize.X;
            Height = (int) Constants.windowSize.Y;
//            world.player.Translate(Constants.playerStartPosition);
            world.GenerateChunk(world.player.GetLocation());
            lastPlayerLocation = world.player.GetLocation();
            world.Update();


            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Black and opaque
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Logger.Log("Rendering Frame");
            renderTime = e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            world.Render(displayDebug);
            world.player.Render(displayDebug);
            foreach (Entity entity in world.entities)
            {
                entity.Render();
            }

            if (displayDebug)
            {
                debugger.DisplayInformation();
                Logger.Log("Debug Information Enabled");
            }



            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected void ChangeWindowState()
        {
            WindowState current = WindowState;
            if (current == WindowState.Normal)
            {
                WindowState = WindowState.Fullscreen;
                Logger.Log("WindowState Changed: " + WindowState);
                GL.Viewport(0, 0, Width, Height);
                return;
            }

            if (current == WindowState.Fullscreen)
            {
                WindowState = WindowState.Normal;
                Logger.Log("WindowState Changed: " + WindowState);
                GL.Viewport(0, 0, Width, Height);
                return;
            }


        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Logger.Log("Updating Frame");
            updateTime = e.Time;

            time = DateTime.Now;

            world.SetBoolPlayerInChunk();
            world.Update();

            if (Keyboard[Key.Escape]) Exit();
            if (Keyboard[Key.F11])
            {
                ChangeWindowState();
            }


            if (Keyboard[Constants.debug] && Keyboard[Constants.debug]) displayDebug = !displayDebug;

            if (Keyboard[Constants.moveLeft] && Keyboard[Constants.moveLeft])
            {
                if (Keyboard[Constants.sneak] && Keyboard[Constants.sneak])
                    world.player.SneakLeft();
                else
                    world.player.MoveLeft();
            }

            if (Keyboard[Constants.moveRight] && Keyboard[Constants.moveRight])
            {
                if (Keyboard[Constants.sneak] && Keyboard[Constants.sneak])
                    world.player.SneakRight();
                else
                    world.player.MoveRight();
            }

            if (Keyboard[Constants.moveUp] && Keyboard[Constants.moveUp])
            {
                if (Keyboard[Constants.sneak] && Keyboard[Constants.sneak])
                    world.player.SneakUp();
                else
                    world.player.MoveUp();
            }

            if (Keyboard[Constants.moveDown] && Keyboard[Constants.moveDown])
            {
                if (Keyboard[Constants.sneak] && Keyboard[Constants.sneak])
                    world.player.SneakDown();
                else
                    world.player.MoveDown();
            }

            if (Mouse[Constants.attackKey])
            {
                attackTime = time;
                world.player.Attack();
            }

            if (CheckElapsedTimeSeconds(attackTime, Constants.attackDelay))
                world.player.SetAction(Entity.EntityAction.Walking);

            if (Keyboard[Constants.sneak]) world.player.SetAction(Entity.EntityAction.Sneaking);


            if (Keyboard[Key.B] && Keyboard[Key.B] || IsOutsideWindow(world.player.GetLocation()))
                world.player.Move(Constants.playerStartPosition);

//            Console.Out.WriteLine(world.player.GetLocation());
//                Console.WriteLine(world.GetTileAtPlayer());



            var vec = -1 * (world.player.GetLocation() - lastPlayerLocation);
            var vec1 = new Vector3(vec.X * Constants.tileSize, vec.Y * Constants.tileSize, 0);
            GL.Translate(vec1);

            if (!world.GetChunkAtPlayer().IsChunkGenerated()) world.GenerateChunk(world.player.GetLocation());


//            lastKeyboardState = keyboardStae;
            lastPlayerLocation = world.player.GetLocation();

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

        private bool CheckElapsedTimeSeconds(DateTime t, double milliseconds)
        {
            var ti = t.AddMilliseconds(milliseconds);
            if (time.Millisecond > ti.Millisecond) return true;

            return false;
        }

        public override void Exit()
        {
            Logger.WriteToFile(Constants.defaultLogPath);
            base.Exit();
            Environment.Exit(0);
        }
    }
}