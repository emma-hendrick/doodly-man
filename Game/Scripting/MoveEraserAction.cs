using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveEraserAction : Action
    {
        public MoveEraserAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {

            List<Actor> actors = cast.GetActors(Constants.ERASER_GROUP);
            foreach (Actor actor in actors)
            {
                Eraser eraser = (Eraser)actor;

                if (eraser.GetActive())
                {
                    Body body = eraser.GetBody();
                    Point position = body.GetPosition();
                    int x = position.GetX();
                    
                    if (x < 0)
                    {
                        eraser.Bounce();
                    }
                    else if (x > Constants.SCREEN_WIDTH - Constants.ERASER_WIDTH)
                    {
                        eraser.Bounce();
                    }
                    
                    Point velocity = body.GetVelocity();
                    position = position.Add(velocity);

                    body.SetPosition(position);
                }       
            }
        }
    }
}