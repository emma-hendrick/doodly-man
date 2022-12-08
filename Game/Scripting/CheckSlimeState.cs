using Unit06.Game.Scripting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting 
{
    public class SlimeState
    {
        public string CheckSlimeState(int velocity) {
            
            if (velocity == 0) {
                return "cresting";
            }
            if (velocity >= 1) {
                return "careening";
            }
            if (velocity <= 1 && velocity >= 0) {
                return "falling";
            }
            if (velocity >= -1 && velocity <= 0) {
                return "peaking";
            }
            if (velocity <= -1) {
                return "leaping";
            }            
            else {
                return "leaping";
            }
        }
    }
}