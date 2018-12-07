using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Commande
    {
        public Commande(String entree, String plat, String dessert)
        {
            this.e = entree;
            this.p = plat;
            this.d = dessert;
        }

        public string e;
        public string p;
        public string d;

        public Entree Entree { get; set; }

        public Plat Plat { get; set; }

        public Dessert Dessert { get; set; }

        private Table Table
        {
            get => default(Table);
            set
            {
            }
        }
    }
}