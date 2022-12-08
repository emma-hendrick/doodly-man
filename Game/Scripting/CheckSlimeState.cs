using Unit06.Game.Scripting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting 
{
    public class SlimeState
    {
        public string CheckSlimeState(int velocity) {
            Point velocity = body.GetVelocity();
            
            switch (velocity) {
                case 0:
                    state = "cresting";
                    break;
                case <= 1:
                    state = "falling";
                    break;
                case >= 1:
                    state = "careening";
                    break;
                case >= -1 :
                    state = "peaking";
                    break;
                case <= -1:
                    state = "leaping";
                    break;
            }
        }
    }
}