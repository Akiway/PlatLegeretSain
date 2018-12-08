using System;

namespace PlatLegeretSain.Model
{
    public class Reservation
    {

        public int numTable { get; set; }
        public int NbClient { get; set; }
        public DateTime Heure { get; set; }
        private static Random rng = new Random(new Random().Next());

        public Reservation()
        {
            this.NbClient = rng.Next(1, 10);
            this.numTable = Restaurant.GRCT.CheckTableDisponibility(NbClient);
            this.Heure = new DateTime(2018, 1, 1, rng.Next(10, 13), rng.Next(0, 59), 0);

            //Database.Instance().ReserverTable(this.numTable);
        }
    }
}