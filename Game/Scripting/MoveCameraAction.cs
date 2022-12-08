using Unit06.Game.Casting;
using Unit06.Game.Services;
using System;
namespace Unit06.Game.Scripting
{
    public class MoveCameraAction : Action
    {
        private VideoService _videoService;
        public MoveCameraAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Camera camera = (Camera)cast.GetFirstActor(Constants.CAMERA_GROUP);
            camera.ScrollDown();

            Slime slime = (Slime)cast.GetFirstActor(Constants.SLIME_GROUP);
            Point slimePosition = slime.GetBody().GetPosition();

            Point newPosition = new Point(0, (Constants.SCREEN_HEIGHT / 2) - slimePosition.GetY());

            camera.SetPosition(newPosition);

            ((RaylibVideoService)_videoService).SetPosition(camera.GetPosition());
        }
    }
}