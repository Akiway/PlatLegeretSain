using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Ingredient
    {
        public Ingredient(String nomProduit, int quantite)
        {
            this.nomProduit = nomProduit;
            this.quantite = quantite;
        }

        public string nomProduit;
        public int quantite;
        public String etat;
        
    }
}