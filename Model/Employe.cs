using System;
using System.Collections.Generic;
using System.Threading;

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
        }

        public void MoveDown(int distance)
        {
            this.Orientation = "front";
            this.Y += distance;
        }

        public void MoveLeft(int distance)
        {
            this.Orientation = "left";
            this.X -= distance;
        }

        public void MoveRight(int distance)
        {
            this.Orientation = "right";
            this.X += distance;
        }

        public virtual void MoveToOrigin(bool teleport = true)
        {
            MoveTo(this.OriginX, this.OriginY, teleport);
            this.Orientation = this.OriginOrientation;
        }

        public virtual void MoveToTable(int numTable, bool teleport = true)
        {
            Table table = Restaurant.Tables.Find(x => x.Numero == numTable);
            int nbPlaces = table.NbPlace;
            int half = nbPlaces / 2;
            int cx = table.X;
            int cy = table.Y;
            int ecart = 46, decalage = ecart / 2;
            int px, py;

            if (table.OrientationHorizontale)
            {
                if (half % 2 != 0) // 2, 6, 10 places
                {
                    px = cx + (half / 2 + 1) * ecart - decalage / 2;
                    py = cy;
                    this.Orientation = "left";
                }
                else // 4, 8 places
                {
                    px = cx + half / 2 * ecart + decalage / 2;
                    py = cy;
                    this.Orientation = "left";
                }
            }
            else
            {
                if (half % 2 != 0) // 2, 6, 10 places
                {
                    px = cx;
                    py = cy + (half / 2 + 1) * ecart - decalage / 2;
                    this.Orientation = "back";
                }
                else // 4, 8 places
                {
                    px = cx;
                    py = cy + half / 2 * ecart + decalage / 2;
                    this.Orientation = "back";
                }
            }
            MoveTo(px, py, teleport);
        }

        public virtual void MoveToEtuve(bool teleport = true)
        {
            MoveTo(1280, 100, teleport);
            this.Orientation = "left";
        }

        public virtual void MoveToFurnace(bool teleport = true)
        {
            MoveTo(1440, 75, teleport);
            this.Orientation = "back";
        }

        public virtual void MoveToReception(bool teleport = true)
        {
            MoveTo(1180, 870, teleport);
            this.Orientation = "right";
        }

        public virtual void MoveToCuisine(bool teleport = true)
        {
            MoveTo(1180, 300, teleport);
            this.Orientation = "right";
        }

        public virtual void MoveToComptoir(bool teleport = true)
        {
            MoveTo(1250, 230, teleport);
            this.Orientation = "left";
        }

        protected void MoveTo(int x, int y, bool teleport)
        {
            if (teleport)
            {
                this.X = x;
                this.Y = y;
            }
            else
            {
                while (x != this.X || y != this.Y)
                {
                    if (x < this.X)
                    {
                        MoveLeft(1);
                    }
                    else if (x > this.X)
                    {
                        MoveRight(1);
                    }
                    if (y < this.Y)
                    {
                        MoveUp(1);
                    }
                    else if (y > this.Y)
                    {
                        MoveDown(1);
                    }

                    Thread.Sleep(Clock.STime(20));
                }
            }
        }
    }
}