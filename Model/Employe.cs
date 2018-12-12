using System;
using System.Collections.Generic;

namespace PlatLegeretSain.Model
{
    public abstract class Employe : IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string img;
        public string Orientation { get; set; }
        public List<PositionPossible> PositionsPossibles { get; set; }
        public string PositionActuel { get; set; }
        public int OriginX { get; set; }
        public int OriginY { get; set; }
        public string OriginOrientation { get; set; }

        protected Employe()
        {

        }

        public void SetOrigin(int x, int y, string orientation, bool move)
        {
            this.OriginX = x;
            this.OriginY = y;
            this.OriginOrientation = orientation;
            if (move)
                MoveToOrigin();
        }


        public void MoveUp(int distance)
        {
            this.Orientation = "back";
            this.Y -= distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveDown(int distance)
        {
            this.Orientation = "front";
            this.Y += distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveLeft(int distance)
        {
            this.Orientation = "left";
            this.X -= distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveRight(int distance)
        {
            this.Orientation = "right";
            this.X += distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveToOrigin()
        {
            this.X = this.OriginX;
            this.Y = this.OriginY;
            this.Orientation = this.OriginOrientation;
        }

        public void MoveToTable(int numTable)
        {
            Table table = Restaurant.Tables.Find(x => x.Numero == numTable);
            int nbPlaces = table.NbPlace;
            int half = nbPlaces / 2;
            int cx = table.X;
            int cy = table.Y;
            int ecart = 46, decalage = ecart / 2;

            if (table.OrientationHorizontale)
            {
                if (half % 2 != 0) // 2, 6, 10 places
                {
                    this.X = cx + (half / 2 + 1) * ecart - decalage / 2;
                    this.Y = cy;
                    this.Orientation = "left";
                }
                else // 4, 8 places
                {
                    this.X = cx + half / 2 * ecart + decalage / 2;
                    this.Y = cy;
                    this.Orientation = "left";
                }
            }
            else
            {
                if (half % 2 != 0) // 2, 6, 10 places
                {
                    this.X = cx;
                    this.Y = cy + (half / 2 + 1) * ecart - decalage / 2;
                    this.Orientation = "back";
                }
                else // 4, 8 places
                {
                    this.X = cx;
                    this.Y = cy + half / 2 * ecart + decalage / 2;
                    this.Orientation = "back";
                }
            }
        }

    }
}