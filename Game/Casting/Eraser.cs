using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Eraser : Actor
    {
        private Body _body;
        private Animation _animation;
        private bool _active;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Eraser(Body body, Animation animation, bool debug) : base(debug)
        {
            this._body = body;
            this._animation = animation;
            this._active = false;
            
            int velocityX = this._body.GetVelocity().GetX();
            this._body.SetVelocity(new Point(velocityX, -Constants.SCROLL_SPEED));
        }


        /// <summary>
        /// Inverts the X velocity
        /// </summary>
        public void Bounce()
        {
            Point velocity = _body.GetVelocity();
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();
            this._body.SetVelocity(new Point(-velocityX, velocityY));
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
        /// Sets the position.
        /// </summary>
        public void SetPosition(Point position)
        {
            if (_active)
            {
                _body.SetPosition(position);
            }
        }
        
        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetPosition()
        {
            return _body.GetPosition();
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
        /// Gets the current status, whether active or inactive.
        /// </summary>
        /// <returns>The active status.</returns>
        public bool GetActive()
        {
            return _active;
        }


        /// <summary>
        /// Sets the current status to active.
        /// </summary>
        public void Activate()
        {
            _active = true;
        }
    }
}