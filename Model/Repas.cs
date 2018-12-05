using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public abstract class Repas
    {
        public string nom
        {
            get => default(string);
            set
            {
            }
        }

        private string etat
        {
            get => default(string);
            set
            {
            }
        }

        private Recette Recette
        {
            get => default(Recette);
            set
            {
            }
        }

        public Commande Commande
        {
            get => default(Commande);
            set
            {
            }
        }
    }
}