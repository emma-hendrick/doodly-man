using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideRacketAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideRacketAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            Slime slime = (Slime)cast.GetFirstActor(Constants.SLIME_GROUP);
            Body ballBody = ball.GetBody();
            Body slimeBody = slime.GetBody();

            if (_physicsService.HasCollided(slimeBody, ballBody))
            {
                ball.BounceY();
                Sound sound = new Sound(Constants.BOUNCE_SOUND);
                _audioService.PlaySound(sound);
            }
        }
    }
}