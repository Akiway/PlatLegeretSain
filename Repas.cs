using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain
{
    public abstract class Repas
    {
        public string nom
        {
            get => default(int);
            set
            {
            }
        }

        private string etat
        {
            get => default(int);
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