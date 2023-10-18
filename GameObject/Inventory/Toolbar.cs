using System;
using SplashKitSDK;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace SwinFarm
{
    public class Toolbar : Inventory
    {
        //have a list of tools
        private List<Tool> _toolkit = new List<Tool>();

        public Toolbar() : base("Toolbar", "Contains tools, opened from the Player House")
        {
            AddTool(new Shovel());
            AddTool(new Sickle());
        }

        //add a tool into the toolbar
        public void AddTool(Tool t)
        {
            Slot newSlot = GetSlot();
            newSlot.AddItemIntoSlot(t);
            Toolkit.Add(t);
        }

        public override void Operate()
        {
            base.Operate();

            if (IsOpened)
            {
                foreach(Tool t in Toolkit)
                {
                    t.Operate();
                }
            }
        }

        //properties:
        public List<Tool> Toolkit
        {
            get { return _toolkit; }
        }
    }
}

