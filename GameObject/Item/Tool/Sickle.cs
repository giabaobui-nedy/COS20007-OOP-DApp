using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class Sickle : Tool
    { 
        public Sickle():base("Sickle", "Used to harvest produce")
        {
            _image = new Bitmap("Sickle Icon", "Resources/images/sickleIcon.png");
            _hoveredImage = new Bitmap("Sickle Icon Hover", "Resources/images/sickleIcon_hovered.png");
            _pickedImage = new Bitmap("Picked Sickle", "Resources/images/sickle.png");
        }

        public override void Function()
        {
            Expanse.Harvest();
        }
    }
}

