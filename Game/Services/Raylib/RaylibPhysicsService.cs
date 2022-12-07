using System.Numerics;
using Raylib_cs;
using Unit06.Game.Casting;
using System;


namespace Unit06.Game.Services
{
    public class RaylibPhysicsService : PhysicsService
    {
        /// </inheritdoc>
        public bool HasCollided(Body subject, Body agent)
        {
            Raylib_cs.Rectangle subjectRectangle = ToRectangle(subject);
            Raylib_cs.Rectangle agentRectangle = ToRectangle(agent);
            return Raylib.CheckCollisionRecs(subjectRectangle, agentRectangle);
        }

        public bool WillCollide(Body subject, Body agent)
        {
            Raylib_cs.Rectangle subjectRectangle = ToVelocityRectangle(subject);
            Raylib_cs.Rectangle agentRectangle = ToVelocityRectangle(agent);
            return Raylib.CheckCollisionRecs(subjectRectangle, agentRectangle);
        }

        public Raylib_cs.Rectangle ToRectangle(Body body)
        {
            int x = body.GetPosition().GetX();
            int y = body.GetPosition().GetY();
            int width = body.GetSize().GetX();
            int height = body.GetSize().GetY();
            return new Raylib_cs.Rectangle(x, y, width, height);
        }

        public Raylib_cs.Rectangle ToVelocityRectangle(Body body)
        {
            int velocityX = body.GetVelocity().GetX();
            int velocityY = body.GetVelocity().GetY();
            int positionX = body.GetPosition().GetX() + ((velocityX < 0) ? velocityX: 0);
            int positionY = body.GetPosition().GetY() + ((velocityY < 0) ? velocityY: 0);
            int width = body.GetSize().GetX() + Math.Abs(velocityX);
            int height = body.GetSize().GetY() + Math.Abs(velocityY);
            return new Raylib_cs.Rectangle(positionX, positionY, width, height);
        }
    }
}