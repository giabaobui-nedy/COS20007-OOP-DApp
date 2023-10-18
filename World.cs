using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace SwinFarm
{
    public class World
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        public World()
        {
            SetUp();
        }

        private void SetUp()
        {
            Expanse gameExpanse = new Expanse();
            PlayerHouse gamePlayerHouse = new PlayerHouse();
            Storage gameStorage = new Storage();
            Toolbar gameToolbar = new Toolbar();
            Stock gameStock = new Stock();
            gamePlayerHouse.Inventory = gameToolbar;
            gameStorage.Inventory = gameStock;
            AddObject(gameExpanse);
            AddObject(gamePlayerHouse);
            AddObject(gameStorage);
            AddObject(gameToolbar);
            AddObject(gameStock);
        }

        private void AddObject(GameObject thing)
        {
            _gameObjects.Add(thing);
        }

        public void Operate()
        {
            foreach (GameObject thing in _gameObjects)
            {
                thing.Operate();
            }
        }
    }
}

