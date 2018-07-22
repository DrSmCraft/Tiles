using OpenTK;
using OpenTK.Input;

namespace Tiles
{
    public class Constants
    {
        public static float tileSize = 100f;
        public static Vector2 dim = new Vector2(10, 10);
        public static Vector2 windowSize = new Vector2(dim.X * tileSize, dim.Y * tileSize);

        // Player Constants
        public static Vector3 playerColor = new Vector3(0, 0, 1);
        public static float playerMoveAmount = 0.1f;

        // Keyboard Constants
        public static Key moveLeft = Key.A;
        public static Key moveRight = Key.D;
        public static Key moveUp = Key.W;
        public static Key moveDown = Key.S;

        // Tile Constants
        public static float tileMoveAmount = 0.01f;
        public static Vector3 grassColor = new Vector3(0f, 255f, 0f);
        public static Vector3 stoneColor = new Vector3(0.5f, 0.5f, 0.5f);
    }
}