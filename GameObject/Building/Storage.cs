using System;
using SplashKitSDK;

namespace SwinFarm
{
    public class Storage : Building
    {
        public Storage() : this("Storage", "Contains stock")
        {
        }

        public Storage(string id, string des) : base(id, des)
        {
            _image = new Bitmap("Storage", "Resources/images/storage.png");
            _hoveredImage = new Bitmap("Storage Hovered", "Resources/images/storage_hovered.png");
            X = 7 * Program.SCREENWIDTH / 12 - Image.Width / 2;
            Y = Program.SCREENHEIGHT / 3 - Program.SCREENHEIGHT / 12;
            EndX = X + Image.Width;
            EndY = Y + Image.Height;
        }
    }
}

