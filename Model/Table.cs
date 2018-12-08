using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Table
    {
        public Table(int numero, int rang, int carre, int nbPlace, int x, int y, bool orientation, bool disponibilite)
        {
            this.Numero = numero;
            this.Rang = rang;
            this.Carre = carre;
            this.NbPlace = nbPlace;
            this.X = x;
            this.Y = y;
            this.OrientationHorizontale = orientation;
            this.Disponible = disponibilite;
        }

        public int Carre { get; set; }
        public int Rang { get; set; }
        public int NbPlace { get; set; }
        public int Numero { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool OrientationHorizontale { get; set; }
        public bool Disponible { get; set; }

        public bool DessertApres { get; set; }

        private List<Client> clients { get; set; }
    }
}