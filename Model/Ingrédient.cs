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

        private string nomProduit
        {
            get => default(string);
            set
            {
            }
        }

        private int quantite
        {
            get => default(int);
            set
            {
            }
        }
    }
}