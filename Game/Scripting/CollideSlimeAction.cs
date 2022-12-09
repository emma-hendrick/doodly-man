using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class CollideSlimeAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideSlimeAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Slime slime = (Slime)cast.GetFirstActor(Constants.SLIME_GROUP);
            Body slimeBody = slime.GetBody();

            List<Actor> finishLines = cast.GetActors(Constants.FINISH_LINE_GROUP);
            foreach (Actor actor in finishLines)
            {
                FinishLine finishLine = (FinishLine)actor;
                Body finishLineBody = finishLine.GetBody();
                if(_physicsService.WillCollide(slimeBody, finishLineBody))
                {
                    Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                    stats.AddLevel();
                    callback.OnNext(Constants.NEXT_LEVEL);
                }
            }

        }
    }
}