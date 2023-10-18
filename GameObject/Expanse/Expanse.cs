using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace SwinFarm
{
    public class Expanse : GameObject
    {
        private const double CELLFIXEDSIZE = 20;
        private Bitmap _grassImage = new Bitmap("Grass", "Resources/images/grass.png");
        private Bitmap _hoveredGrassImage = new Bitmap("Hovered Grass", "Resources/images/grass_hovered.png");
        private Bitmap _soilImage = new Bitmap("Soil", "Resources/images/soil.png");
        private Bitmap _hoveredSoilImage = new Bitmap("Hovered Soil", "Resources/images/soil_hovered.png");
        private static List<Cell> _cellMap = new List<Cell>();
        private static List<Soil> _soilMap = new List<Soil>();
        
        public Expanse():base("Expanse", "Keeps track of cells")
        {
            X = 0;
            Y = 0;
            EndX = Program.SCREENWIDTH;
            EndY = Program.SCREENHEIGHT;
            GenerateGrass();
            RestrictArea();
        }

        //everytime the game initializes, the expanse will contains every Cell type Grass
        private void GenerateGrass()
        {
            for (int x = 0; x < EndX; x += GrassImage.Width)
            {
                for (int y = 0; y < EndY; y += GrassImage.Height)
                {
                    Cells.Add(new Grass(x, y, x + GrassImage.Width, y + GrassImage.Height));
                }
            }
        }

        //restrict specific area
        private void RestrictArea()
        {
            foreach (Cell c in Cells)
            {
                if (c.X >= Program.SCREENWIDTH / 3 && c.X < 2 * Program.SCREENWIDTH / 3 && c.Y >= Program.SCREENHEIGHT - 2 * CELLFIXEDSIZE)
                {
                    c.RestrictCell();
                }

                if (c.X >= Program.SCREENWIDTH / 3 && c.X < 2 * Program.SCREENWIDTH / 3 && c.Y >= Program.SCREENHEIGHT / 6 && c.Y < Program.SCREENHEIGHT / 2)
                {
                    c.RestrictCell();
                }
            }
        }

        //draw the terrain
        public override void Draw()
        {
            foreach(Cell c in Cells)
            {
                if (c is Grass)
                {
                    SplashKit.DrawBitmap(GrassImage, c.X, c.Y);

                    if (c.MouseOver())
                    {
                        SplashKit.DrawBitmap(HoveredGrassImage, c.X, c.Y);
                    }
                }

                if (c is Soil)
                {
                    SplashKit.DrawBitmap(SoilImage, c.X, c.Y);

                    if (c.MouseOver())
                    {
                        SplashKit.DrawBitmap(HoveredSoilImage, c.X, c.Y);
                    }

                    if (((Soil)c).SeedOccupied)
                    {
                        SplashKit.DrawBitmap(SoilImage, c.X, c.Y);
                    }
                }
            }
        }

        //cannot locate Expanse as a whole
        public override bool MouseOver()
        {
            return false;
        }

        public override void Operate()
        {
            base.Operate();
            GrowSeed();
        }

        //for the Shovel tool (is called by the Shovel)
        public static void GenerateSoil()
        {
            Cell referredCell = GetCell();

            if ((referredCell != null) && (referredCell is Grass))
            {
                Soil newSoil = new Soil(referredCell.X, referredCell.Y, referredCell.EndX, referredCell.EndY);
                Cells.Remove(referredCell);
                Cells.Add(newSoil);
                Soils.Add(newSoil);
            }
        }

        //for the Sickle tool (is called by a Sickle)
        public static void Harvest()
        {
            Soil referredCell = GetSoil();

            if ((referredCell != null) && referredCell.SeedOccupied)
            {
                if (referredCell.SeedReadyToHarvest)
                {
                    Seed s = referredCell.HarvestableSeed;
                    Stock.UpdateStock(s);
                    referredCell.RemoveSeed();
                }
            }
        }

        //for the Produce objects (called by a Produce object)
        public static void PlantSeed(Seed thatSeed, Soil thatSoil)
        {
            thatSoil.OccupySeed(thatSeed);
        }

        //get a specific Cell
        public static Cell GetCell()
        {
            Console.WriteLine("looping in GetCell()");

            foreach (Cell c in Cells)
            {
                if (c.MouseOver() && !c.Restricted)
                {
                    return c;
                }
            }

            return null;
        }

        //get a specific Soil
        public static Soil GetSoil()
        {

            if (Soils.Count == 0)
            {
                return null;
            }

            Console.WriteLine("looping in GetSoil()");

            foreach (Soil s in Soils)
            {
                if (s.MouseOver())
                {
                    return s;
                }
            }

            return null;
        }

        //Expanse has the information of every Soil, it will know if there is any Seed in Soil and grow it
        private void GrowSeed()
        {
            if (Soils.Exists(HaveSeed))
            {
                foreach (Soil s in Soils)
                {
                    if (s.SeedOccupied)
                    {
                        s.GrowSeed();
                    }
                }
            }
        }

        //Predicate
        private bool HaveSeed(Soil s)
        {
            return s.SeedOccupied;
        }

        //properties:
        public static List<Cell> Cells
        {
            get { return _cellMap; }
        }

        public static List<Soil> Soils
        {
            get { return _soilMap; }
        }

        public Bitmap GrassImage
        {
            get { return _grassImage; }
        }

        public Bitmap HoveredGrassImage
        {
            get { return _hoveredGrassImage; }
        }

        public Bitmap SoilImage
        {
            get { return _soilImage; }
        }

        public Bitmap HoveredSoilImage
        {
            get { return _hoveredSoilImage; }
        }
    }
}

