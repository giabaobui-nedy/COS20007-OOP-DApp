using System;
using SplashKitSDK;

namespace SwinFarm
{
    public abstract class GameObject : IDrawable, IReferable
    {
        //for Hovered method
        private const int OFFSETFORDESCRIPTION = 10;
        private const uint HOVEREDEFFECTIVETIME = 2;
        private uint _count;
        //identifiers
        private string _identifier;
        private string _description;
        //IReferable
        private Point2D _coordination;
        private Point2D _endCoordination;
        //IDrawable
        protected Bitmap _image;
        protected Bitmap _hoveredImage;

        public GameObject(string id, string des)
        {
            _identifier = id;
            _description = des;
            Console.WriteLine("A new " + ID + " is created!");
        }

        //draw the Bitmap and its Hovered version
        public virtual void Draw()
        {
            SplashKit.DrawBitmap(Image, X, Y);

            if (MouseOver())
            {
                SplashKit.DrawBitmap(HoveredImage, X, Y);
            }
        }

        //locate the Game Object by mouse
        public virtual bool MouseOver()
        {
            if ((SplashKit.MouseX() > X) && (SplashKit.MouseY() > Y) && (SplashKit.MouseX() < EndX) && (SplashKit.MouseY() < EndY))
            {
                return true;
            }

            return false;
        }

        //display the description if the mouse hover on this game object for an amount of time
        public virtual void Hovered()
        {
            if (!MouseOver())
            {
                _count = Program.GameTimer.Ticks;
            }

            if (MouseOver())
            {
                if ((Program.GameTimer.Ticks - _count)/1000 >= HOVEREDEFFECTIVETIME)
                {
                    SplashKit.DrawText(_description, SplashKit.ColorBeige(), EndX, Y - OFFSETFORDESCRIPTION);
                }
            }
        }

        public virtual void Operate()
        {
            Draw();
            Hovered();
        }

        //for debugging
        public void PrintCoordination()
        {
            Console.WriteLine(_identifier + " is at X = " + X.ToString() + " Y = " + Y.ToString() + " EndX = " + EndX.ToString() + " EndY = " + EndY.ToString());
        }


        //properties:
        public double X
        {
            get { return _coordination.X; }
            set { _coordination.X = value; }
        }

        public double Y
        {
            get { return _coordination.Y; }
            set { _coordination.Y = value; }
        }

        public double EndX
        {
            get { return _endCoordination.X; }
            set { _endCoordination.X = value; }
        }

        public double EndY
        {
            get { return _endCoordination.Y; }
            set { _endCoordination.Y = value; }
        }

        public Bitmap Image
        {
            get { return _image; }
        }

        public Bitmap HoveredImage
        {
            get { return _hoveredImage; }
        }

        public string ID
        {
            get { return _identifier; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}

