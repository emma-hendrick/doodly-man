using System.Collections.Generic;
using Unit06.Game.Casting;


namespace Unit06
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Batter";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1280;
        public static int SCREEN_HEIGHT = 840;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";
        public static string GAMEPLAY_SOUND = "Assets/Sounds/Of Far Different Nature - Escape - 01 - Rush (CC-BY).mp3";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string SCORE_GROUP = "score";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";

        // BALL
        public static string BALL_GROUP = "balls";
        public static string BALL_IMAGE = "Assets/Images/000.png";
        public static int BALL_WIDTH = 28;
        public static int BALL_HEIGHT = 28;
        public static int BALL_VELOCITY = 6;

        //CAMERA
        public static string CAMERA_GROUP = "camera";

        // SLIME
        public static string SLIME_GROUP = "slimes";
        
        public static List<string> SLIME_IMAGES
            = new List<string>() {
                "Assets/Images/100.png",
                "Assets/Images/101.png",
                "Assets/Images/102.png"
            };

        public static int SLIME_WIDTH = 106;
        public static int SLIME_HEIGHT = 28;
        public static int SLIME_RATE = 6;
        public static int SLIME_VELOCITY = 7;
        public static int RACKET_WIDTH = 106;
        public static int RACKET_HEIGHT = 28;
        public static int RACKET_RATE = 6;
        public static int RACKET_VELOCITY = 7;
        public static int JUMP_VELOCITY = 24;
        public static int GRAVITY = 1;

        // PLATFORMS
        public static string PLATFORM_GROUP = "platforms";
        public static string ROW_GROUP = "row";
        public static string COLUMN_GROUP = "column";
        
        public static Dictionary<string, Dictionary<string, List<string>>> PLATFORM_IMAGES
            = new Dictionary<string, Dictionary<string, List<string>>>() {
                { "p", new Dictionary<string, List<string>>() {
                    { "l", new List<string>(){
                    "Assets/Images/Platforms/Standard/Left/000.png",
                    }},
                    { "c", new List<string>(){
                    "Assets/Images/Platforms/Standard/Center/000.png",
                    }},
                    { "r", new List<string>(){
                    "Assets/Images/Platforms/Standard/Right/000.png",
                    }},
                    { "o", new List<string>(){
                    "Assets/Images/Platforms/Standard/Only/000.png",
                    }}
                } },
                { "f", new Dictionary<string, List<string>>() {
                    { "l", new List<string>(){
                    "Assets/Images/Platforms/Flying/Left/000.png",
                    "Assets/Images/Platforms/Flying/Left/001.png",
                    "Assets/Images/Platforms/Flying/Left/002.png",
                    "Assets/Images/Platforms/Flying/Left/003.png",
                    "Assets/Images/Platforms/Flying/Left/004.png",
                    "Assets/Images/Platforms/Flying/Left/005.png",
                    "Assets/Images/Platforms/Flying/Left/006.png",
                    "Assets/Images/Platforms/Flying/Left/007.png",
                    }},
                    { "c", new List<string>(){
                    "Assets/Images/Platforms/Flying/Center/000.png",
                    "Assets/Images/Platforms/Flying/Center/001.png",
                    "Assets/Images/Platforms/Flying/Center/002.png",
                    "Assets/Images/Platforms/Flying/Center/003.png",
                    "Assets/Images/Platforms/Flying/Center/004.png",
                    "Assets/Images/Platforms/Flying/Center/005.png",
                    "Assets/Images/Platforms/Flying/Center/006.png",
                    "Assets/Images/Platforms/Flying/Center/007.png",
                    }},
                    { "r", new List<string>(){
                    "Assets/Images/Platforms/Flying/Right/000.png",
                    "Assets/Images/Platforms/Flying/Right/001.png",
                    "Assets/Images/Platforms/Flying/Right/002.png",
                    "Assets/Images/Platforms/Flying/Right/003.png",
                    "Assets/Images/Platforms/Flying/Right/003.png",
                    "Assets/Images/Platforms/Flying/Right/004.png",
                    "Assets/Images/Platforms/Flying/Right/005.png",
                    "Assets/Images/Platforms/Flying/Right/006.png",
                    "Assets/Images/Platforms/Flying/Right/007.png",
                    }},
                    { "o", new List<string>(){
                    "Assets/Images/Platforms/Flying/Only/000.png",
                    "Assets/Images/Platforms/Flying/Only/001.png",
                    "Assets/Images/Platforms/Flying/Only/002.png",
                    "Assets/Images/Platforms/Flying/Only/003.png",
                    "Assets/Images/Platforms/Flying/Only/004.png",
                    "Assets/Images/Platforms/Flying/Only/005.png",
                    "Assets/Images/Platforms/Flying/Only/006.png",
                    "Assets/Images/Platforms/Flying/Only/007.png",
                    }}
                } },
                { "a", new Dictionary<string, List<string>>() {
                    { "i", new List<string>(){
                    "Assets/Images/Air/000.png",
                    }},
                } }
        };

        public static int PLATFORM_WIDTH = 160;
        public static int PLATFORM_HEIGHT = 56;
        public static double PLATFORM_DELAY = 0.5;
        public static int PLATFORM_RATE = 4;
        public static int PLATFORM_POINTS = 50;

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "PREPARING TO LAUNCH";
        public static string WAS_GOOD_GAME = "GAME OVER";

    }
}