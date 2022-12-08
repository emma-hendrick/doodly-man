using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawRacketAction : Action
    {
        private VideoService _videoService;
        
        public DrawRacketAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Slime slime = (Slime)cast.GetFirstActor(Constants.SLIME_GROUP);
            Body body = slime.GetBody();

            if (slime.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Animation animation = slime.GetAnimation();
            Image image = animation.NextImage();
            Point position = body.GetPosition();

            if (slime.GetStaticPosition()) 
            {
                _videoService.DrawStaticImage(image, position);
            }
            else {
                _videoService.DrawImage(image, position);
            }
        }
    }
}