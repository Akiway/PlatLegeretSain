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

        public static List<int> groupList = new List<int>();

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

            for(int x = 1; x < 11; x++)
            {
                Tables.Add(new Table(2, x, "disponible"));
            }
            for (int x = 11; x < 21; x++)
            {
                Tables.Add(new Table(4, x, "disponible"));
            }
            for (int x = 21; x < 26; x++)
            {
                Tables.Add(new Table(6, x, "disponible"));
            }
            for (int x = 26; x < 31; x++)
            {
                Tables.Add(new Table(8, x, "disponible"));
            }
            Tables.Add(new Table(10, 31, "disponible"));
            Tables.Add(new Table(10, 32, "disponible"));

            MH.appelerChefRang();

            GenererReservation();

            View.Game1.Print(Reservations.Count.ToString());
            foreach (var res in Reservations)
            {
                View.Game1.Print("Res : " + res.NbClient + " clients à " + res.Heure);
            }

            //View.Game1.Print(Reservations.Find(x => x.Table.Equals("front")).GetType().Name.ToString());

            Thread threadReservation = new Thread(new ThreadStart(ThreadReservation));
            Thread threadClientAleatoire = new Thread(new ThreadStart(ThreadClientAleatoire));
            threadClientAleatoire.Start();

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

        public static void ThreadClientAleatoire()
        {
            while (true)
            {
                //Thread.Sleep(300000); // 5 min

                Thread.Sleep(5000); // 30 sec
                Random random = new Random();
                bool boolValue = Convert.ToBoolean(random.Next() % 2);

                if(boolValue == true)
                {
                    List<Client> listClient = new List<Client>();

                    int nbClient = new Random().Next(1, 10);
                    int numGroup = groupList.FindLast(n => n < 10000) + 1;
                    groupList.Add(numGroup);
                    for (int x = 0; x < nbClient; x++)
                    {
                        Clients.Add(new Client(numGroup));
                        listClient.Add(new Client(numGroup));
                    }

                    Restaurant.MH.AccueillirClient(0, listClient);
                    listClient.Clear();
                    //int test = Clients.FindAll(client => client.groupe.Equals(1)).Count;
                }


            }
        }

        private static void GenererReservation()
        {
            for (int i = 0; i < new Random().Next(1, 5); i++)
            {
                Reservations.Add(new Reservation());
            }
        }

        public static Table GetTable(int numTable)
        {
            Table table = Restaurant.Tables.Find(x => x.numero.Equals(numTable));
            return table;
        }
    }
}
