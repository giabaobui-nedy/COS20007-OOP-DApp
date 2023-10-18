using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class Soil : Cell
    {
        //contains a seed
        private Seed? _seed;

        public Soil(double x, double y, double endX, double endY) : base(x, y, endX, endY)
        {
        }

        //determines the position of a seed to be drawn on the screen
        public void OccupySeed(Seed s)
        {
            _seed = s;
            _seed.X = X;
            _seed.Y = Y;
            _seed.EndX = EndX;
            _seed.EndY = EndY;
        }

        //grows the seed (to allow the seed to grow itself)
        public void GrowSeed()
        {
            _seed.Operate();
        }

        //if the seed has been harvest (remove the seed)
        public void RemoveSeed()
        {
            _seed = null;
        }

        //properties:
        public bool SeedOccupied
        {
            get
            {
                if (_seed != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool SeedReadyToHarvest
        {
            get
            {
                return _seed.ReadyToHarvest;
            }
        }

        public Seed HarvestableSeed
        {
            get
            {
                return _seed.HarvestableSeed;
            }
        }
    }
}

