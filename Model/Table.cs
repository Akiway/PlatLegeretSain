using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Table
    {
        public Table(int nbPlace, int numero, String etat)
        {
            this.numero = numero;
            this.etat = etat;
            this.nbPlace = nbPlace;
        }

        private int carre { get; set; }

        private int rang { get; set; }

        public int nbPlace { get; set; }

        public int numero { get; set; }

        public string etat { get; set; }

        private List<Client> clients { get; set; }
    }
}