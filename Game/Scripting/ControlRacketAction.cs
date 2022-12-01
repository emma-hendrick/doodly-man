using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlRacketAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlRacketAction(KeyboardService keyboardService)
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