using System;
using SplashKitSDK;
namespace SwinFarm
{
    public class Program
    {
        public const int SCREENWIDTH = 600;
        public const int SCREENHEIGHT = 480;
        public static Timer GameTimer = new Timer("Game Timer");
        
        public static void Main(string[] args)
        {
            World newWorld = new World();
            Window window = new Window("Swin Farm", SCREENWIDTH, SCREENHEIGHT);
            Font _gameFont = new Font("To The Point", "Resources/fonts/gamefont.ttf");
            GameTimer.Start();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                newWorld.Operate();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}