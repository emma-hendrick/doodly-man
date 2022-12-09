using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MoveEraserAction : Action
    {
        public MoveEraserAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Eraser eraser = (Eraser)cast.GetFirstActor(Constants.SLIME_GROUP);
            Body body = eraser.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            position = position.Add(velocity);
            
            if (x < 0)
            {
                eraser.Bounce();
            }
            else if (x > Constants.SCREEN_WIDTH - Constants.SLIME_WIDTH)
            {
                eraser.Bounce();
            }

            body.SetPosition(position);       
        }
    }
}