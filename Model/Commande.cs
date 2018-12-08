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

        public string e { get; set; }
        public string p { get; set; }
        public string d { get; set; }

        private Table Table
        {
            get => default(Table);
            set
            {
            }
        }
    }
}