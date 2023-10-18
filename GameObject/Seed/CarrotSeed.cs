using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class CarrotSeed : Seed
    {
        public CarrotSeed():base()
        {
        }

        public CarrotSeed(Bitmap img, Bitmap hoveredImg):base("Carrot Seed", "", img, hoveredImg)
        {
            _growingTime = 15;
        }
    }
}

