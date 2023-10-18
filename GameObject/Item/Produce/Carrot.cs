using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class Carrot : Produce
    {
        public Carrot():base("Carrot", "")
        {
            _image = new Bitmap("Carrot Icon", "Resources/images/carrotIcon.png");
            _hoveredImage = new Bitmap("Hovered Carrot Icon", "Resources/images/carrotIcon_hovered.png");
            _pickedImage = new Bitmap("Picked Carrot", "Resources/images/carrotPicked.png");
            _seedImage = new Bitmap("Carrot Seed graphics", "Resources/images/carrot.png");
            _hoveredSeedImage = new Bitmap("Hovered Carrot Seed graphics", "Resources/images/carrot_hovered.png");
            _modelSeed = new CarrotSeed();
        }

        //generate a Carrot seed with the same source of Bitmap (inspired by Flyweight patterns)
        public override Seed GenerateSeed()
        {
            return new CarrotSeed(SeedImage, HoveredSeedImage);
        }
    }
}

