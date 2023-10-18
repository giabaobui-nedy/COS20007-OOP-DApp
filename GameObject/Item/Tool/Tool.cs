using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace SwinFarm
{
    public abstract class Tool: Item
    {
        public Tool(string id, string des):base(id, des)
        {
        }

        public override void Operate()
        {
            base.Operate();

            if (IsPicked() && SplashKit.MouseClicked(MouseButton.LeftButton) && !MouseOver())
            {
                Function();
            }
        }

        //Tool has a function
        public abstract void Function();
    }
}

