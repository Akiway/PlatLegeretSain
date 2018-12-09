using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Cuisinier : Employe
    {
        public Cuisinier()
        {
            this.Occuped = false;
        }

        public bool Occuped;
        public List<Repas> repas;
    }
}