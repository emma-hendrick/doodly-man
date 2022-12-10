using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawErasersAction : Action
    {
        private VideoService _videoService;
        
        public DrawErasersAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> erasers = cast.GetActors(Constants.ERASER_GROUP);
            foreach (Actor actor in erasers)
            {
                Eraser eraser = (Eraser)actor;
                Body body = eraser.GetBody();

                if (eraser.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = eraser.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition(); 
                
                _videoService.DrawImage(image, position);
            }
        }
    }
}