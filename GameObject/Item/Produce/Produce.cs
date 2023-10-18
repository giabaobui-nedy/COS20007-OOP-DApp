using System;
using SplashKitSDK;

namespace SwinFarm
{

    public abstract class Produce:Item
    {
        //the number of seeds in stock (can be planted)
        private int _stock;
        //the Bitmap of the seed (illustrating all the stages of developing) & its hovered version
        protected Bitmap _seedImage;
        protected Bitmap _hoveredSeedImage;
        //used to compare to the harvested seed
        protected Seed _modelSeed;

        public Produce(string id, string des): base(id, des)
        {
            _stock = 5;
            UpdateDescription();
        }

        public override void Operate()
        {
            base.Operate();
            PlantSeed();
        }

        //SEED GENERATOR: the key of Abstract Factory pattern
        public abstract Seed GenerateSeed();

        //Based on the type of Produce and the chosen soil, plant the picked type of seed in the soil
        public void PlantSeed()
        {
            if (IsPicked() && SplashKit.MouseClicked(MouseButton.LeftButton) && Stock > 0 && !MouseOver())
            {
                Soil thatSoil = Expanse.GetSoil();

                if (thatSoil != null && !thatSoil.SeedOccupied)
                {
                    Expanse.PlantSeed(GenerateSeed(), thatSoil);
                    UseStock();
                }
            }
        }

        //called by the Stock object
        public void UpdateStock(Seed s)
        {
            if (s.GetType() == TypeOfSeed)
            {
                AddStock();
            }
        }

        //when planting a seed, reduce the number of stock available
        private void UseStock()
        {
            _stock = _stock - 1;
            Console.WriteLine("You have used 1 " + ID + " seed" + ". In stock: " + _stock.ToString());
            UpdateDescription();
        }

        //when harvesting the seeds, increment the stock by 5
        private void AddStock()
        {
            _stock = _stock + 5;
            Console.WriteLine("You have harvested 5 " + ID + " seed" + ". In stock: " + _stock.ToString());
            UpdateDescription();
        }

        //update the number of seed in the stock to be displayed
        private void UpdateDescription()
        {
            Description = ID + ". In stock: " + Stock.ToString();
        }

        //properties:
        public int Stock
        {
            get { return _stock; }
        }

        public Bitmap SeedImage
        {
            get { return _seedImage; }
        }

        public Bitmap HoveredSeedImage
        {
            get { return _hoveredSeedImage; }
        }

        public Type TypeOfSeed
        {
            get { return _modelSeed.GetType(); }
        }
    }
}

