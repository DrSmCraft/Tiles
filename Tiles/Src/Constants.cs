using System;
using System.IO;
using OpenTK;
using OpenTK.Input;

namespace Tiles
{
    public class Constants
    {
        public static string baseDirectory = AppContext.BaseDirectory;

        public static float tileSize = 100f; // tile size in pixels
        public static int chunkSize = 10; // chunk size in tiles
        public static Vector2 dim = new Vector2(100, 100); // Full dimenstions of map
        public static int chunksVisable = 1;

        public static Vector2 windowSize = new Vector2(chunkSize * tileSize, chunkSize * tileSize);
//        public static Vector2 windowSize = new Vector2(800, 600);

        // Terrian Generator Constants
        public static int seed = 1000;
        public static float generatorZoom = 0.1f;
        public static float biomeGeneratorZoom = 0.01f;


        // Player Constants
        public static Vector3 playerColor = new Vector3(1f, 0, 0);
        public static float playerMoveAmount = 0.1f;
        public static float playerSize = tileSize;
        public static Vector2 playerStartPosition = new Vector2(chunkSize / 2, chunkSize / 2);
        public static double attackDelay = 0.1;

        // Website used to generate charecter sprite
        // http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/#
        // http://gaurav.munjal.us/Universal-LPC-Spritesheet-Character-Generator/#?clothes=longsleeve_brown&legs=pants_teal&mail=chain&nose=straight&ears=big&shoes=boots_golden&weapon=none&hair=plain_dark_blonde&belt=leather&hat=cap_leather
        public static PlayerTexture playerTexture = new PlayerTexture(
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\PlayerFront.png"), 100),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\PlayerBack.png"), 101),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\PlayerLeft.png"), 102),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\PlayerRight.png"), 103),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\AttackFront.png"), 104),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\AttackBack.png"), 105),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\AttackLeft.png"), 106),
            new Texture(Path.Combine(baseDirectory, @"Assets\\Player\\AttackRight.png"), 107));

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

        public static float treeGenerationFreq = 0.01f;


        // Texture Constants
        public static Texture grassTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Tiles\GrassTile.png"), 1);

        public static Texture stoneTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Tiles\StoneTile.png"), 2);

        public static Texture waterTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Tiles\WaterTile.png"), 3);

        public static Texture dirtTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Tiles\DirtTile.png"), 4);

        public static Texture woodTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Tiles\WoodTile.png"), 5);

        public static Texture leavesTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Tiles\LeavesTile.png"), 6);

        public static Texture treeTexture =
            new Texture(Path.Combine(baseDirectory, @"Assets\Structures\TreeStructure.png"), 10);
    }
}