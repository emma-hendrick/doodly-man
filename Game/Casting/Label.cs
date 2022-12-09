namespace Unit06.Game.Casting
{
    /// <summary>
    /// A label to be displayed.
    /// </summary>
    public class Label : Actor
    {
        private Text _text;
        private Point _position;
        private bool _staticPosition;

        /// <summary>
        /// Constructs a new instance of Label.
        /// </summary>
        public Label(Text text, Point position, bool staticPosition) : base(false)
        {
            this._text = text;
            this._position = position;
            this._staticPosition = staticPosition;
        }

        /// <summary>
        /// Gets the label's text.
        /// </summary>
        /// <returns>The text.</returns>
        public Text GetText()
        {
            return _text;
        }

        /// <summary>
        /// Gets the label's position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// Gets the bool storing whether the position is static in the video engine.
        /// </summary>
        /// <returns>The bool.</returns>
        public bool GetStaticPosition()
        {
            return _staticPosition;
        }
    }
}