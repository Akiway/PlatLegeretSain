using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Reservation
    {
        public Reservation()
        {
            this.nbClient = new Random().Next(1, 10);
            // Necessite de vérifier les tables disponibles
            //this.Table = new Random().Next(1, 30);
            this.heure = new DateTime(0001, 1, 1, new Random().Next(0, 24), new Random().Next(0, 60), 0);
        }

        public Table Table
        {
            get => default(Table);
            set
            {
            }
        }

        public DateTime heure
        {
            get => default(DateTime);
            set
            {
            }
        }

        public int nbClient
        {
            get => default(int);
            set
            {
            }
        }
    }
}