using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlSlimeAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlSlimeAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Slime slime = (Slime)cast.GetFirstActor(Constants.SLIME_GROUP);
            if (_keyboardService.IsKeyDown(Constants.LEFT))
            {
                slime.SwingLeft();
            }
            else if (_keyboardService.IsKeyDown(Constants.RIGHT))
            {
                slime.SwingRight();
            }
            else
            {
                slime.StopMoving();
            }
        }
    }
}