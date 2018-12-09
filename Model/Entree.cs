using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Entree : Repas
    {
        public Entree(string nom, Recette recette)
        {
            this.nom = nom;
            this.recette = recette;
        }
    }
}