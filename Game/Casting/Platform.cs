namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Platform : Actor
    {
        private Body _body;
        private Animation _animation;
        private Animation _background;
        private int _points;
        private bool _collideable;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Platform(Body body, Animation animation, Animation background, int points, bool collideable, bool debug) : base(debug)
        {
            this._body = body;
            this._animation = animation;
            this._background = background;
            this._points = points;
            this._collideable = collideable;
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
        /// Gets the background.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetBackground()
        {
            return _background;
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
        /// Gets the collideability status.
        /// </summary>
        /// <returns>The collideability status.</returns>
        public bool CanCollide()
        {
            return _collideable;
        }

        /// <summary>
        /// Gets the points.
        /// </summary>
        /// <returns>The points.</returns>
        public int GetPoints()
        {
            return _points;
        }
        
    }
}