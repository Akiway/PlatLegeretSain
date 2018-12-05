using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Commande
    {
        public Entree Entree
        {
            get => default(Entree);
            set
            {
            }
        }

        public Plat Plat
        {
            get => default(Plat);
            set
            {
            }
        }

        public Dessert Dessert
        {
            get => default(Dessert);
            set
            {
            }
        }

        private Table Table
        {
            get => default(Table);
            set
            {
            }
        }
    }
}