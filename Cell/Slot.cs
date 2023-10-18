using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class Slot:Cell
    {
        //contains an item
        private Item? _anItem;

        public Slot(double x, double y, double endX, double endY) : base(x, y, endX, endY)
        {
        }

        //determine the position of the Item so that the Item can be positioned in the right corner (Tool and Produce -- so far)
        public void AddItemIntoSlot(Item i)
        {
            _anItem = i;
            i.X = X;
            i.Y = Y;
            i.EndX = EndX;
            i.EndY = EndY;
        }

        //properties:
        public Item Content
        {
            get { return _anItem; }
        }
    }
}

