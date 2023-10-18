using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace SwinFarm
{
    public abstract class Inventory : GameObject
    {
        protected const double OFFSETX = 6;
        protected const double OFFSETY = 6;
        protected const double ICONFIXEDSIZE = 18;
        //list of slots for items
        private List<Slot> _placeholders = new List<Slot>();
        //a boolean to indicate whether the Inventory is opened or not
        private bool _isOpened;

        public Inventory(string id, string des) : base(id, des)
        {
            _image = new Bitmap("Inventory", "Resources/images/inventory.png");
            X = Program.SCREENWIDTH / 3 + ((Program.SCREENWIDTH / 3 - Image.Width) / 2);
            Y = Program.SCREENHEIGHT - Image.Height;
            EndX = X + Image.Width;
            EndY = Y + Image.Height;
            _isOpened = false;
        }

        //Inventory does not need a hovered Image
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X, Y);
        }

        //Inventory does not need to show description
        public override void Hovered()
        {
        }

        public override void Operate()
        {
            if (IsOpened)
            {
                base.Operate();

                ControlPickableItem();
            }
            else
            {
                UnpickAll();
            }
        }

        //automatically generate the first and the adjacent slots
        public Slot GetSlot()
        {
            Slot newSlot = new Slot((Placeholders.Count * ICONFIXEDSIZE) + X + OFFSETX, Y + OFFSETY, ((Placeholders.Count * ICONFIXEDSIZE) + X + OFFSETX) + ICONFIXEDSIZE, EndY - OFFSETY);
            Placeholders.Add(newSlot);
            return newSlot;
        }

        //open & close the Inventory
        public void Open()
        {
            if (!IsOpened)
            {
                _isOpened = true;
            }
            else
            {
                _isOpened = false;
            }
        }

        //to unpick all the item in Inventory
        private void UnpickAll()
        {
            foreach (Slot s in Placeholders)
            {
                s.Content.Unpick();
            }
        }

        //ensure there is only one item picked at a time
        private void ControlPickableItem()
        {
            if (MouseOver() && SplashKit.MouseClicked(MouseButton.LeftButton))
            { 
                foreach (Slot s in Placeholders)
                {
                    s.Content.Unpick();

                    if (s.MouseOver())
                    {
                        s.Content.Pick();
                    }
                }
            }
        }

        //properties:
        public List<Slot> Placeholders
        {
            get { return _placeholders; }
        }

        public bool IsOpened
        {
            get { return _isOpened; }
        }
    }
}

