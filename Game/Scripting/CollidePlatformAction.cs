using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollidePlatformAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollidePlatformAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            List<Actor> platforms = cast.GetActors(Constants.PLATFORM_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            
            foreach (Actor actor in platforms)
            {
                Platform platform = (Platform)actor;
                Body platformBody = platform.GetBody();
                Body ballBody = ball.GetBody();

                if (_physicsService.HasCollided(platformBody, ballBody))
                {
                    ball.BounceY();
                    Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    _audioService.PlaySound(sound);
                    int points = platform.GetPoints();
                    stats.AddPoints(points);
                    cast.RemoveActor(Constants.PLATFORM_GROUP, platform);
                }
            }
        }
    }
}