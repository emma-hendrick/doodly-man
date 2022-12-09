using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    public class Eraser : Actor
    {
        private Body _body;
        private bool _active;
        public Eraser(Body body, bool debug) : base(debug)
        {
            this._body = body;
            this._active = false;
            
            int velocityX = this._body.GetVelocity().GetX();
            this._body.SetVelocity(new Point(velocityX, 1));
        }

        public void Bounce()
        {
            Point velocity = _body.GetVelocity();
            int velocityX = velocity.GetX();
            int velocityY = velocity.GetY();
            this._body.SetVelocity(new Point(-velocityX, velocityY));
        }
        
        public void SetPosition(Point position)
        {
            if (_active)
            {
                _body.SetPosition(position);
            }
        }
        
        public Point GetPosition()
        {
            return _body.GetPosition();
        }
        
        public Body GetBody()
        {
            return _body;
        }

        public bool GetActive()
        {
            return _active;
        }

        public void Activate()
        {
            _active = true;
        }
    }
}