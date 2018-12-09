using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public abstract class Repas
    {
        public string nom;
        public int numTable;
        public Recette recette;
    }
}