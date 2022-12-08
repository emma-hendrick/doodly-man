using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawPlatformsAction : Action
    {
        private VideoService _videoService;
        
        public DrawPlatformsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> platforms = cast.GetActors(Constants.PLATFORM_GROUP);
            foreach (Actor actor in platforms)
            {
                Platform platform = (Platform)actor;
                Body body = platform.GetBody();

                if (platform.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = platform.GetAnimation();
                Image image = animation.NextImage();
                Animation backgroundAnimation = platform.GetBackground();
                Image background = backgroundAnimation.NextImage();
                Point position = body.GetPosition(); 

                if (platform.GetStaticPosition()) 
                {
                    _videoService.DrawStaticImage(background, position);
                    _videoService.DrawStaticImage(image, position);
                }
                else {
                    _videoService.DrawImage(background, position);
                    _videoService.DrawImage(image, position);
                }
            }
        }
    }
}