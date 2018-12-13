using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Plat : Repas
    {
        public Plat(string nom, Recette recette, int numTable, string type)
        {
            this.nom = nom;
            this.numTable = numTable;
            this.recette = recette;
            this.type = type;
        }
    }
}