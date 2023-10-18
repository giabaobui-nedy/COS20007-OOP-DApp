using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using SplashKitSDK;

namespace SwinFarm
{
    public class Stock : Inventory
    {
        //has a static list of Produces to provide interface to update the stock
        private Bitmap _producePlaceholderImg = new Bitmap("Produce Placeholder", "Resources/images/produce_placeholder.png");
        private static List<Produce> _produces = new List<Produce>();

        public Stock(): base("Stock", "Contain seeds")
        {
            AddProduce(new Carrot());
            AddProduce(new Tomato());
        }

        //have a dedicate placeholder (just for game graphics)
        public override void Draw()
        {
            base.Draw();
            SplashKit.DrawBitmap(PlaceholderImage, X + OFFSETX, Y + OFFSETY);
        }

        public override void Operate()
        {
            base.Operate();

            if (IsOpened)
            {
                foreach (Produce p in Produces)
                {
                    p.Operate();
                }
            }
        }

        //add a type of produce into stock
        public void AddProduce(Produce p)
        {
            Slot newSlot = GetSlot();
            newSlot.AddItemIntoSlot(p);
            Produces.Add(p);
        }

        //update the stock (called by the Expanse)
        public static void UpdateStock(Seed s)
        {
            foreach (Produce p in Produces)
            {
                p.UpdateStock(s);
            }
        }

        //properties:
        public Bitmap PlaceholderImage
        {
            get { return _producePlaceholderImg; }
        }

        public static List<Produce> Produces
        {
            get { return _produces; }
        }
    }
}

