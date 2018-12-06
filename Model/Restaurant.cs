using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace PlatLegeretSain.Model
{
    sealed class Restaurant
    {
        // Singleton
        private static Restaurant resto = null;
        public static Restaurant Instance()
        {
            if (resto == null)
                resto = new Restaurant();
            return resto;
        }

        public static MaitreHotel MH;
        public static List<Employe> Employes = new List<Employe>();
        public static List<Client> Clients = new List<Client>();
        public static List<Reservation> Reservations = new List<Reservation>();
        public static List<Table> Tables = new List<Table>();
        public static ChefRang CR1, CR2;
        public static Serveur Serveur1, Serveur2;
        public static string Time { get; set; }

        private Restaurant()
        {
            MH = MaitreHotel.Instance();
            Employes.Add(MH);
            CR1 = new ChefRang(1, 1130, 520);
            CR2 = new ChefRang(2, 1130, 480);
            Employes.Add(CR1);
            Employes.Add(CR2);
            Serveur1 = new Serveur(1, 1130, 240);
            Serveur2 = new Serveur(2, 1130, 200);
            Employes.Add(Serveur1);
            Employes.Add(Serveur2);

            MH.appelerChefRang();

            GenererReservation();

            View.Game1.Print(Reservations.Count.ToString());
            foreach (var res in Reservations)
            {
                View.Game1.Print("Res : " + res.NbClient + " clients à " + res.Heure);
            }

            //View.Game1.Print(Reservations.Find(x => x.Table.Equals("front")).GetType().Name.ToString());

            Thread threadReservation = new Thread(new ThreadStart(ThreadReservation));
            threadReservation.Start();
        }


        public static void ThreadReservation()
        {
            int NbReservation = Reservations.Count;
            while(NbReservation > 0)
            {
                foreach (Reservation res in Reservations)
                {
                    if ((res.Heure.Hour + ":" + res.Heure.Minute) == Time)
                    {
                        View.Game1.Print("ILS ARRIVENT !!!!!!! " + res.NbClient + " clients pour la table n°" + res.Table);
                        NbReservation--;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private static void GenererReservation()
        {
            for (int i = 0; i < new Random().Next(1, 5); i++)
            {
                Reservations.Add(new Reservation());
            }
        }
    }
}
