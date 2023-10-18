using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class TomatoSeed:Seed
    {
        public TomatoSeed() : base()
        {
        }

        public TomatoSeed(Bitmap img, Bitmap hoveredImg) : base("Tomato Seed", "", img, hoveredImg)
        {
            _growingTime = 30;
        }
    }
}

