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
        public static ChefRang CR1, CR2;
        public static Serveur Serveur1, Serveur2;

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

            foreach (var res in Reservations)
            {
                View.Game1.Print(res.nbClient.ToString());
                View.Game1.Print(res.heure.ToString());
            }

            Thread threadReservation = new Thread(new ThreadStart(ThreadReservation));
            //threadReservation.Start();
        }

        public static void ThreadReservation()
        {
            while(true)
            {
                Clients.Add(new Client());
                Thread.Sleep(500);
            }
        }

        private static void GenererReservation()
        {
            int nbReservation = new Random().Next(1, 3);
            for (int i = 0; i < nbReservation; i++)
            {
                Reservations.Add(new Reservation());
            }
        }
    }
}
