using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    public class Camera : Actor
    {
        private Point _position;
        private bool _active;
        public Camera(Point position, bool debug) : base(debug)
        {
            this._position = position;
            this._active = false;
        }
        
        public void SetPosition(int x, int y)
        {
            if (_active)
            {
                _position = new Point(x, y);
            }
        }
        
        public Point GetPosition()
        {
            return _position;
        }

        public void ScrollDown()
        {
            if (_active)
            {
                int X = _position.GetX();
                int Y = _position.GetY();
                _position = new Point(X, Y + 1);
            }
        }

        public void Activate()
        {
            _active = true;
        }
    }
}