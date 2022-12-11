using Unit06.Game.Scripting;
using Unit06.Game.Services;
using Unit06.Game.Assets;

namespace Unit06.Game.Scripting 
{
    public class UpdateSprite
    {
        string state = CheckSlimeState(velocity);

        public string UpdateSprite(string state) {
            
            if ("cresting") {
                return "sprite_018.png";
            }
            if ("careening") {
                return "sprite_025.png";
            }
            if ("falling") {
                return "sprite_000.png";
            }
            if ("peaking") {
                return "sprite_022.png";
            }
            if ("leaping") {
                return "sprite_024.png";
            }
        }
    }
}
