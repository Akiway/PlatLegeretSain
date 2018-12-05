using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public abstract class Employe
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string img;

        public string positionActuel
        {
            get => default(string);
            set
            {
            }
        }

        public List<PositionPossible> positionsPossibles
        {
            get => default(List<PositionPossible>);
            set
            {
            }
        }
    }
}