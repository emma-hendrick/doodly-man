using System;
using System.Collections.Generic;
using System.IO;
using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.WHITE);
        private int _rows = 0;

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddCamera(cast);
            AddStats(cast);
            AddLevel(cast);
            AddScore(cast);
            AddLives(cast);
            AddPlatforms(cast);
            AddSlime(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.GAMEPLAY_SOUND);
            script.AddAction(Constants.OUTPUT, sa);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void ActivateCamera(Cast cast)
        {
            Camera camera = (Camera)cast.GetFirstActor(Constants.CAMERA_GROUP);
            camera.Activate();
        }

        private void PrepareNextLevel(Cast cast, Script script)
        {
            AddCamera(cast);
            AddPlatforms(cast);
            AddSlime(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PrepareTryAgain(Cast cast, Script script)
        {
            AddCamera(cast);
            AddSlime(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();
            
            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);
            
            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            ActivateCamera(cast);
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();

            ControlRacketAction action = new ControlRacketAction(KeyboardService);
            script.AddAction(Constants.INPUT, action);

            AddUpdateActions(script);    
            AddOutputActions(script);
        
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddSlime(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddCamera(Cast cast)
        {
            cast.ClearActors(Constants.CAMERA_GROUP);

            Point position = new Point(0, 0);
            Camera camera = new Camera(position, false);

            cast.AddActor(Constants.CAMERA_GROUP, camera);
        }

        private void AddPlatforms(Cast cast)
        {
            cast.ClearActors(Constants.PLATFORM_GROUP);

            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            int level = stats.GetLevel() % Constants.BASE_LEVELS;
            string filename = string.Format(Constants.LEVEL_FILE, level);
            List<List<string>> rows = LoadLevel(filename);

            _rows = rows.Count;

            for (int r = 0; r < rows.Count; r++)
            {
                cast.ClearActors(Constants.ROW_GROUP + r);

                for (int c = 0; c < rows[r].Count; c++)
                {
                    int x = Constants.FIELD_LEFT + c * Constants.PLATFORM_WIDTH;
                    int y = Constants.FIELD_TOP + (r - rows.Count) * Constants.PLATFORM_HEIGHT + Constants.SCREEN_HEIGHT - Constants.HUD_MARGIN * 2;

                    string type = rows[r][c][0].ToString();
                    string direction = rows[r][c][1].ToString();
                    int frames = (int)Char.GetNumericValue(rows[r][c][2]);
                    int points = Constants.PLATFORM_POINTS;

                    Point position = new Point(x, y);
                    Point size = new Point(Constants.PLATFORM_WIDTH, Constants.PLATFORM_HEIGHT);
                    Point velocity = new Point(0, 0);
                    List<string> images = Constants.PLATFORM_IMAGES[type][direction].GetRange(0, frames);

                    Body body = new Body(position, size, velocity);
                    Animation animation = new Animation(images, Constants.PLATFORM_RATE, 0);
                    Animation background = new Animation(Constants.BACKGROUND_IMAGES, Constants.PLATFORM_RATE, 0);
                    
                    Platform platform = new Platform(body, animation, background, points, (type == "a") ? false: true, false, false);
                    cast.AddActor(Constants.PLATFORM_GROUP, platform);
                    cast.AddActor(Constants.ROW_GROUP + r, platform);
                }
            }
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.BLACK);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Label label = new Label(text, position, true);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddLevel(Cast cast)
        {
            cast.ClearActors(Constants.LEVEL_GROUP);

            Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.BLACK);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position, true);
            cast.AddActor(Constants.LEVEL_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.BLACK);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position, true);
            cast.AddActor(Constants.LIVES_GROUP, label);   
        }

        private void AddSlime(Cast cast)
        {
            cast.ClearActors(Constants.SLIME_GROUP);
        
            int x = Constants.CENTER_X - Constants.SLIME_WIDTH / 2;
            int y = Constants.SCREEN_HEIGHT/2 - Constants.SLIME_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.SLIME_WIDTH, Constants.SLIME_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Animation animation = new Animation(Constants.SLIME_IMAGES, Constants.SLIME_RATE, 0);
            Slime slime = new Slime(body, animation, false, false);
        
            cast.AddActor(Constants.SLIME_GROUP, slime);
        }

        private void AddScore(Cast cast)
        {
            cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.BLACK);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position, true);
            cast.AddActor(Constants.SCORE_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    if (row == "" || row.Substring(0, 2) == "--") {
                    }
                    else {
                        List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                        data.Add(columns);
                    }
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPlatformsAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRacketAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MoveCameraAction(VideoService));
            script.AddAction(Constants.UPDATE, new MoveRacketAction());
            script.AddAction(Constants.UPDATE, new CollidePlatformAction(PhysicsService, AudioService, _rows));
            script.AddAction(Constants.UPDATE, new CollideRacketAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}