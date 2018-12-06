using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Reservation
    {

        public int Table { get; set; }
        public int NbClient { get; set; }
        public DateTime Heure { get; set; }
        static Random rng = new Random(new Random().Next());

        public Reservation()
        {
            View.Game1.Print(rng.Next(1, 11).ToString());
            this.NbClient = rng.Next(1, 10);
            // Necessite de vérifier les tables disponibles
            this.Table = rng.Next(1, 32);
            this.Heure = new DateTime(2018, 1, 1, rng.Next(10, 13), rng.Next(0, 59), 0);

            Database.Instance().ReserverTable(this.Table);
        }
    }
}