using System;
using SplashKitSDK;

namespace SwinFarm
{
    public abstract class Building : GameObject
    {
        //have an inventory
        private Inventory _inventory;

        public Building(string id, string des):base(id, des)
        {
        }
        
        public override void Operate()
        {
            base.Operate();
            OpenInventory();
        }

        //open its own Inventory
        private void OpenInventory()
        {
            if (MouseOver() && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Inventory.Open();
            }
        }

        //properties:
        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
    }
}

