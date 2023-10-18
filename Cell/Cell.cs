using System;
using SplashKitSDK;

namespace SwinFarm
{
    public abstract class Cell : IReferable
    {
        //Cells have coordination to locate its self
        private Point2D _coordination;
        private Point2D _endCoordination;
        //has a boolean to be restrict for a particular purpose
        private bool _restricted;

        public Cell(double x, double y, double endX, double endY)
        {
            _coordination.X = x;
            _coordination.Y = y;
            _endCoordination.X = endX;
            _endCoordination.Y = endY;
            _restricted = false;
        }

        //can be detected by mouse
        public bool MouseOver()
        {
            if ((SplashKit.MouseX() > X) && (SplashKit.MouseY() > Y) && (SplashKit.MouseX() < EndX) && (SplashKit.MouseY() < EndY))
            {
                return true;
            }
            return false;
        }

        //Cell does not have any description
        public void Hovered()
        {
        }

        //restrict the cell
        public void RestrictCell()
        {
            _restricted = true;
        }

        //properties:
        public double X
        {
            get { return _coordination.X; }
        }

        public double Y
        {
            get { return _coordination.Y; }
        }

        public double EndX
        {
            get { return _endCoordination.X; }
        }

        public double EndY
        {
            get { return _endCoordination.Y; }
        }

        public bool Restricted
        {
            get { return _restricted; }
        }
    }
}

