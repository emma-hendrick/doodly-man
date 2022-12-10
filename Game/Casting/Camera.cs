using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    public class Camera : Actor
    {
        private Point _position;
        private Point _lowPosition;
        private bool _active;
        public Camera(Point position, bool debug) : base(debug)
        {
            this._position = position;
            this._lowPosition = position;
            this._active = false;
        }
        
        public void SetPosition(Point position)
        {
            if (_active)
            {
                _position = position;
            }
        }
        
        public Point GetPosition()
        {
            return _lowPosition.GetY() < _position.GetY() ? _lowPosition: _position;
        }
        
        public Point GetLowPosition()
        {
            return _lowPosition;
        }

        public void ScrollDown()
        {
            if (_active)
            {
                int X = _lowPosition.GetX();
                int Y = _lowPosition.GetY();
                _lowPosition = new Point(X, Y - 1);
            }
        }

        public void Activate()
        {
            _active = true;
        }
    }
}