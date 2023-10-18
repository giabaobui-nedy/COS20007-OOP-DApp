using System;
using SplashKitSDK;
namespace SwinFarm
{
    public class PlayerHouse : Building 
    {
        public PlayerHouse() : this ("Player House", "Contains toolbar")
        {
        }

        public PlayerHouse(string id, string des) : base(id, des)
        {
            _image = new Bitmap("Player House", "Resources/images/player_house.png");
            _hoveredImage = new Bitmap("Player House Hovered", "Resources/images/player_house_hovered.png");
            X = Program.SCREENWIDTH / 3 + (Program.SCREENWIDTH / 12 - Image.Width / 2);
            Y = Program.SCREENHEIGHT / 3 - Program.SCREENHEIGHT / 12;
            EndX = X + Image.Width;
            EndY = Y + Image.Height;
        }     
    }
}

