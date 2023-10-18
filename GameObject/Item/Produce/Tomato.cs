using System;
using SplashKitSDK;namespace SwinFarm{
    public class Tomato:Produce
    {
        public Tomato() : base("Tomato", "")
        {
            _image = new Bitmap("Tomato Icon", "Resources/images/tomatoIcon.png");
            _hoveredImage = new Bitmap("Hovered Tomato Icon", "Resources/images/tomatoIcon_hovered.png");
            _pickedImage = new Bitmap("Picked Tomato", "Resources/images/tomatoPicked.png");
            _seedImage = new Bitmap("Tomato Seed graphics", "Resources/images/tomato.png");
            _hoveredSeedImage = new Bitmap("Hovered Tomato Seed graphics", "Resources/images/tomato_hovered.png");
            _modelSeed = new TomatoSeed();
        }

        //generate a Tomato seed with the same source of Bitmap (inspired by Flyweight patterns)
        public override Seed GenerateSeed()
        {
            return new TomatoSeed(SeedImage, HoveredSeedImage);
        }
    }
}

