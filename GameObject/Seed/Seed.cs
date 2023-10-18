using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace SwinFarm
{
    public abstract class Seed : GameObject
    {
        private const int IMAGEFIXEDSIZE = 20;
        //has a specific growing time (different among types of Produce)
        protected uint _growingTime;
        //when initialized, the program time will be recorded as the starting mark for the seeds' growing
        private uint _startingTimePoint;
        //a boolean indicating whether it can be harvested or not
        private bool _readyToHarvest;

        public Seed():base("Model seed", "for efficient updating stocks")
        {
        }

        public Seed(string id, string des, Bitmap img, Bitmap hoveredImg) : base(id, des)
        {
            _startingTimePoint = Program.GameTimer.Ticks / 1000;
            _readyToHarvest = false;
            _image = img;
            _image.SetCellDetails(IMAGEFIXEDSIZE, IMAGEFIXEDSIZE, 5, 1, 5);
            _hoveredImage = hoveredImg;
            _hoveredImage.SetCellDetails(IMAGEFIXEDSIZE, IMAGEFIXEDSIZE, 5, 1, 5);
        }

        //has a specific Drawing Option (for drawing each cell in the Bitmap)
        public override void Draw()
        {
            DrawingOptions opt;
            opt = SplashKit.OptionWithBitmapCell(GetGrowingStage());

            SplashKit.DrawBitmap(Image, X, Y, opt);

            if (MouseOver())
            {
                SplashKit.DrawBitmap(HoveredImage, X, Y, opt);
            }
        }

        public override void Operate()
        {
            base.Operate();
            UpdateDescription();
        }

        //return the growing stage based on the time passed since the starting time that the seed had been grown
        private int GetGrowingStage()
        {
            uint currentTime = Program.GameTimer.Ticks / 1000;

            if ((currentTime  - StartTime ) < GrowTime / Image.CellCount)
            {
                return 0;
            }

            if ((currentTime - StartTime) < 2 * GrowTime / Image.CellCount)
            {
                return 1;
            }

            if ((currentTime - StartTime) < 3 * GrowTime / Image.CellCount)
            {
                return 2;
            }

            if ((currentTime - StartTime) < 4 * GrowTime / Image.CellCount)
            {
                return 3;
            }

            if ((currentTime - StartTime) == GrowTime)
            {
                _readyToHarvest = true;
                return 4;
            }

            return 4;
        }

        //update the time left before harvesting
        private void UpdateDescription()
        {
            
            uint currentTime = Program.GameTimer.Ticks / 1000;
            uint timePass = currentTime - StartTime;
            uint timeLeft = GrowTime - timePass;

            if (!ReadyToHarvest)
            {
                if (timePass < 1)
                {
                    Description = "";
                }

                if (timePass >= 1 && timeLeft <= GrowTime)
                {
                    Description = "can be harvested in: " + timeLeft.ToString();
                }
            }
            else
            {
                Description = "Ready to be harvest!!!";
            }

        }

        //properties:
        public uint GrowTime
        {
            get { return _growingTime; }
        }

        public uint StartTime
        {
            get { return _startingTimePoint; }
        }

        public bool ReadyToHarvest
        {
            get { return _readyToHarvest; }
        }

        public Seed HarvestableSeed
        {
            get
            {
                if (ReadyToHarvest)
                {
                    return this;
                }
                return null;
            }
        }
    }
}

