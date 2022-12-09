using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawFinishLineAction : Action
    {
        private VideoService _videoService;
        
        public DrawFinishLineAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> finishLines = cast.GetActors(Constants.FINISH_LINE_GROUP);
            foreach (Actor actor in finishLines)
            {
                FinishLine finishLine = (FinishLine)actor;
                Body body = finishLine.GetBody();

                if (finishLine.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = finishLine.GetAnimation();
                Image image = animation.NextImage();
                Animation backgroundAnimation = finishLine.GetBackground();
                Image background = backgroundAnimation.NextImage();
                Point position = body.GetPosition(); 

                _videoService.DrawImage(background, position);
                _videoService.DrawImage(image, position);
            }
        }
    }
}