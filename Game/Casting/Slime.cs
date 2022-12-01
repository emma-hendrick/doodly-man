namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Slime : Actor
    {
        private Body _body;
        private Animation _animation;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Slime(Body body, Animation animation, bool debug) : base(debug)
        {
            this._body = body;
            this._animation = animation;
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
        /// Moves the Slime to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = _body.GetPosition();
            Point velocity = _body.GetVelocity();
            Point newPosition = position.Add(velocity);
            _body.SetPosition(newPosition);
        }

        /// <summary>
        /// Swings the Slime to the left.
        /// </summary>
        public void SwingLeft()
        {
            Point velocity = new Point(-Constants.SLIME_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the Slime to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = new Point(Constants.SLIME_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the Slime from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
        }
        
    }
}