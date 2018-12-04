using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain
{
    public abstract class Employe
    {
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