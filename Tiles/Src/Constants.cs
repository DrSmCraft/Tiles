using System;
using System.Drawing;
using System.Resources;
using Gwen.Skin;
using OpenTK;
using OpenTK.Input;
using Tiles.Properties;

namespace Tiles
{
    public class Constants
    {
        public static string baseDirectory = AppContext.BaseDirectory;
        public static string defaultLogPath = baseDirectory + @"\Log.txt";

        public static float tileSize = 60f; // tile size in pixels default: 100f
        public static int chunkSize = 15; // chunk size in tiles
        public static Vector2 dim = new Vector2(100, 100); // Full dimenstions of map
        public static int chunksVisable = 1;

        public static Vector2 windowSize = new Vector2(chunkSize * tileSize, chunkSize * tileSize);
//        public static Vector2 windowSize = new Vector2(800, 600);

        // Terrian Generator Constants
        public static int seed = 1000;
        public static float generatorZoom = 0.1f;
        public static float biomeGeneratorZoom = 0.01f;

        public static int maxEntityNumber = 10;


        // Player Constants
        public static Vector3 playerColor = new Vector3(1f, 0, 0);
        public static float playerMoveAmount = tileSize * 0.003f;
        public static float playerSneakAmount = playerMoveAmount * 0.1f;
        public static float playerSize = tileSize;
        public static Vector2 playerStartPosition = new Vector2(5, 5);
        public static double attackDelay = 100;
        public static int playerHealth = 10;




        // Website used to generate charecter sprite
        // http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/#
        // http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/#?clothes=longsleeve_brown&legs=pants_teal&mail=chain&nose=straight&ears=big&shoes=boots_golden&weapon=none&hair=plain_dark_blonde&belt=leather&hat=cap_leather

        public static EntityTexture playerTexture = new EntityTexture(
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerFront"), 100),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerBack"), 101),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerLeft"), 102),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerRight"), 103),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerAttackFront"), 104),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerAttackBack"), 105),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerAttackLeft"), 106),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("PlayerAttackRight"), 107));

        // Orc Constants
        public static int orcHealth = (int) (playerHealth * 1.5);
        public static EntityTexture orcTexture = new EntityTexture(
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcFront"), 111),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcBack"), 111),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcLeft"), 112),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcRight"), 113),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcAttackFront"), 114),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcAttackBack"), 115),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcAttackLeft"), 116),
            new Texture((Bitmap) Resources.ResourceManager.GetObject("OrcAttackRight"), 117));

        // Keyboard Constants
        public static Key moveLeft = Key.A;
        public static Key moveRight = Key.D;
        public static Key moveUp = Key.W;
        public static Key moveDown = Key.S;
        public static Key sneak = Key.ShiftLeft;
        public static Key debug = Key.Tilde;
        public static MouseButton attackKey = MouseButton.Left;

        // Tile Constants
        public static float tileMoveAmount = 0.01f;
        public static Vector3 grassColor = new Vector3(0, 1f, 0);
        public static Vector3 stoneColor = new Vector3(0.5f, 0.5f, 0.5f);
        public static Vector3 waterColor = new Vector3(0, 0, 1f);
        public static Vector3 pathColor = new Vector3(.5f, .2f, 0f);

        public static float treeGenerationFreq = 0.01f;


        // Debug Constants
        public static Color tilesDebugColor = Color.Khaki;
        public static Color playerDebugColor = Color.Red;
        public static Color chunkDebugColor = Color.Crimson;
        public static float tileDebugLineThickness = 3.0f;

        // Texture Constants

        public static Texture grassTexture = new Texture((Bitmap) Resources.ResourceManager.GetObject("GrassTile"), 1);
        public static Texture stoneTexture = new Texture((Bitmap) Resources.ResourceManager.GetObject("StoneTile"), 2);
        public static Texture waterTexture = new Texture((Bitmap) Resources.ResourceManager.GetObject("WaterTile"), 3);
        public static Texture dirtTexture = new Texture((Bitmap) Resources.ResourceManager.GetObject("DirtTile"), 4);
        public static Texture woodTexture = new Texture((Bitmap) Resources.ResourceManager.GetObject("WoodTile"), 5);

        public static Texture leavesTexture =
            new Texture((Bitmap) Resources.ResourceManager.GetObject("LeavesTile"), 6);


        public static Texture treeTexture =
            new Texture((Bitmap) Resources.ResourceManager.GetObject("TreeStructure"), 10);
    }
}