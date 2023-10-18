using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class Shovel:Tool
    {
        public Shovel():base("Shovel", "Used to create soil")
        {
            _image = new Bitmap("Shovel Icon", "Resources/images/shovelIcon.png");
            _hoveredImage = new Bitmap("Hovered Shovel Icon ", "Resources/images/shovelIcon_hovered.png");
            _pickedImage = new Bitmap("Picked Shovel", "Resources/images/shovel.png");
        }

        public override void Function()
        {
            Expanse.GenerateSoil();
        }
    }
}

