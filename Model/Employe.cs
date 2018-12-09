using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public abstract class Employe : IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string img;
        public string orientation { get; set; }
        public List<PositionPossible> positionsPossibles { get; set; }
        public string positionActuel { get; set; }


        public void MoveUp(int distance)
        {
            this.orientation = "back";
            this.Y -= distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveDown(int distance)
        {
            this.orientation = "front";
            this.Y += distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveLeft(int distance)
        {
            this.orientation = "left";
            this.X -= distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

        public void MoveRight(int distance)
        {
            this.orientation = "right";
            this.X += distance;
            Console.WriteLine("x: " + this.X + " y: " + this.Y);
        }

    }
}