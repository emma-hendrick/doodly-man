using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;
using System;

namespace Unit06.Game.Scripting
{
    public class CollidePlatformAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        private int _rowCount;
        
        public CollidePlatformAction(PhysicsService physicsService, AudioService audioService, int rowCount)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
            this._rowCount = rowCount;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Slime slime = (Slime)cast.GetFirstActor(Constants.SLIME_GROUP);
            Body slimeBody = slime.GetBody();
            int slimeVelocityY = slimeBody.GetVelocity().GetY();
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            List<Actor> collisionPlatforms = GetCollisionPlatforms(cast, slimeBody);
            
            foreach (Actor actor in collisionPlatforms)
            {
                Platform platform = (Platform)actor;
                Body platformBody = platform.GetBody();

                // Only jump when falling, and about to collide with a platform
                if (platform.CanCollide() && _physicsService.WillCollide(slimeBody, platformBody) && slimeVelocityY > 0)
                {
                    int slimePositionX = slimeBody.GetPosition().GetX();
                    int platformPositionY = platformBody.GetPosition().GetY();
                    int platformSizeY = platformBody.GetSize().GetY();
                    Point newPosition = new Point(slimePositionX, platformPositionY - platformSizeY);

                    slimeBody.SetPosition(newPosition);
                    slime.Jump();
                    Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    _audioService.PlaySound(sound);
                }
            }
        }

        private List<Actor> GetCollisionPlatforms(Cast cast, Body slimeBody)
        {
            int slimePositionY = slimeBody.GetPosition().GetY();
            int slimeVelocityY = slimeBody.GetVelocity().GetY();
            List<Actor> collisionPlatforms = new List<Actor>();

            int slimeStartRow = ((slimePositionY + (Constants.HUD_MARGIN * 2) - (Constants.SCREEN_HEIGHT + Constants.FIELD_TOP)) / Constants.PLATFORM_HEIGHT) + _rowCount;
            int slimeEndRow = ((slimePositionY + slimeVelocityY + (Constants.HUD_MARGIN * 2) - (Constants.SCREEN_HEIGHT + Constants.FIELD_TOP)) / Constants.PLATFORM_HEIGHT) + _rowCount;

            for (int r = slimeStartRow; r < slimeEndRow; r++)
            {
                collisionPlatforms.AddRange(cast.GetActors(Constants.ROW_GROUP + r));
            }

            //Console.WriteLine(collisionPlatforms.Count);

            return collisionPlatforms;
        }
    }
}