using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Table
    {
        public Table(int numero, int rang, int carre, int nbPlace, int x, int y, bool orientation, bool etat)
        {
            this.Numero = numero;
            this.Rang = rang;
            this.Carre = carre;
            this.NbPlace = nbPlace;
            this.X = x;
            this.Y = y;
            this.OrientationHorizontale = orientation;
            this.Etat = etat;
        }

        public int Carre { get; set; }
        public int Rang { get; set; }
        public int NbPlace { get; set; }
        public int Numero { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool OrientationHorizontale { get; set; }
        public bool Etat { get; set; }

        private List<Client> Clients { get; set; }
    }
}