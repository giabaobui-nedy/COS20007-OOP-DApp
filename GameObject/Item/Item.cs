using System;
using SplashKitSDK;
namespace SwinFarm
{
    public abstract class Item:GameObject
    {
        //has a boolean to indicate whether it is picked or not
        private bool _isPicked;
        //a picked Bitmap
        protected Bitmap _pickedImage;

        public Item(string id, string des) : base (id, des)
        {
            _isPicked = false;
        }

        //draw another kind of Bitmap
        public override void Draw()
        {
            base.Draw();

            if (IsPicked())
            {
                SplashKit.DrawBitmap(PickedImage, SplashKit.MouseX() - PickedImage.Width / 2, SplashKit.MouseY() - PickedImage.Height / 2);
            }
        }

        //IPickable interfaces
        public bool IsPicked()
        {
            return _isPicked;
        }

        public void Pick()
        {
            _isPicked = true;
        }

        public void Unpick()
        {
            _isPicked = false;
        }

        //properties:
        public Bitmap PickedImage
        {
            get { return _pickedImage; }
        }
    }
}

