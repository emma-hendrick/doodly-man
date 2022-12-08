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

            ((RaylibVideoService)_videoService).SetPosition(camera.GetPosition());
        }
    }
}