using OpenTK;
using OpenTK.Input;

namespace Tiles
{
    public class Constants
    {
        public static float tileSize = 100f;
        public static int chunkSize = 10;
        public static Vector2 dim = new Vector2(100, 100);
        public static Vector2 dimVisible = new Vector2(10, 10);
        public static Vector2 windowSize = new Vector2(dimVisible.X * tileSize, dimVisible.Y * tileSize);
//        public static Vector2 windowSize = new Vector2(800, 600);

        public static float generatorZoom = 0.1f;

        // Player Constants
        public static Vector3 playerColor = new Vector3(1f, 0, 0);
        public static float playerMoveAmount = 0.1f;
        public static float playerSize = 100f;
        public static Vector2 playerStartPosition = new Vector2(chunkSize / 2, chunkSize / 2);
        public static PlayerTexture playerTexture = new PlayerTexture("C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Player\\PlayerFront.png", 100, "C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Player\\PlayerBack.png", 101, "C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Player\\PlayerLeft.png", 102, "C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Player\\PlayerRight.png", 103);

        // Keyboard Constants
        public static Key moveLeft = Key.A;
        public static Key moveRight = Key.D;
        public static Key moveUp = Key.W;
        public static Key moveDown = Key.S;

        // Tile Constants
        public static float tileMoveAmount = 0.01f;
        public static Vector3 grassColor = new Vector3(0, 1f, 0);
        public static Vector3 stoneColor = new Vector3(0.5f, 0.5f, 0.5f);
        public static Vector3 waterColor = new Vector3(0, 0, 1f);
        public static Vector3 pathColor = new Vector3(.5f, .2f, 0f);


        // Texture Constants
        public static Texture grassTexture =
            new Texture("C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Tiles\\GrassTile.png", 1);
        public static Texture stoneTexture =
            new Texture("C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Tiles\\StoneTile.png", 2);
        public static Texture waterTexture =
            new Texture("C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Tiles\\WaterTile.png", 3);
        public static Texture dirtTexture =
            new Texture("C:\\Users\\Notebook\\Desktop\\Tiles\\Assets\\Tiles\\DirtTile.png", 4);
    }
}