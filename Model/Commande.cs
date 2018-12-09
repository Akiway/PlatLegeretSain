using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Commande
    {
        public Commande(String entree, String plat, String dessert, int numTable)
        {
            this.entree = entree;
            this.plat = plat;
            this.dessert = dessert;
            this.numTable = numTable;
        }

        public string entree { get; set; }
        public string plat { get; set; }
        public string dessert { get; set; }
        public int numTable { get; set; }
    }
}