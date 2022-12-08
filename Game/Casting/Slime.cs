using System;
namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Slime : Actor
    {
        private Body _body;
        private Animation _animation;
        private bool _staticPosition;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Slime(Body body, Animation animation, bool staticPosition, bool debug) : base(debug)
        {
            this._body = body;
            this._animation = animation;
            this._staticPosition = staticPosition;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetAnimation()
        {
            return _animation;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return _body;
        }

        /// <summary>
        /// Gets the bool storing whether the position is static in the video engine.
        /// </summary>
        /// <returns>The bool.</returns>
        public bool GetStaticPosition()
        {
            return _staticPosition;
        }

        /// <summary>
        /// Moves the Slime to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = _body.GetPosition();
            Point velocity = _body.GetVelocity();
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();

            Point newPosition = position.Add(velocity);
            _body.SetPosition(newPosition);
        }

        /// <summary>
        /// Swings the Slime to the left.
        /// </summary>
        public void SwingLeft()
        {
            Point velocity = _body.GetVelocity();
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();
            Point newerVelocity = ApplyGravity(new Point(-Constants.SLIME_SPEED, velocityY));
            _body.SetVelocity(newerVelocity);
        }

        /// <summary>
        /// Swings the Slime to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = _body.GetVelocity();
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();
            Point newerVelocity = ApplyGravity(new Point(Constants.SLIME_SPEED, velocityY));
            _body.SetVelocity(newerVelocity);
        }

        /// <summary>
        /// Stops the Slime from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = _body.GetVelocity();
            int velocityY = velocity.GetY();
            Point newVelocity = ApplyGravity(new Point(0, velocityY));
            _body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Allows the slime to jump
        /// </summary>
        public void Jump()
        {
            Point velocity = _body.GetVelocity();
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();
            Point newerVelocity = new Point(velocityX, -Constants.JUMP_VELOCITY);
            _body.SetVelocity(newerVelocity);
        }

        private Point ApplyGravity(Point velocity)
        {
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();
            int newVelocityY = velocityY + Constants.GRAVITY;
            int limitedVelocityY = Math.Abs(newVelocityY) < Constants.TERMINAL_VELOCITY ? newVelocityY: Math.Sign(velocityY) * Constants.TERMINAL_VELOCITY;
            return new Point(velocityX, limitedVelocityY);
        }
        
    }
}