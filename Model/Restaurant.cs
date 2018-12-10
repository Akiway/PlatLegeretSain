using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Clock = PlatLegeretSain.Model.Clock;

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
        public static ChefCuisine CC;
        public static Cuisinier C1, C2;
        public static CommisSalle commisSalle;
        public static CommisCuisine commisCuisine;
        public static ComptoirPlatsChauds CPC;
        public static GestionReservationsClientsTables GRCT;
        public static List<Employe> Employes = new List<Employe>();
        public static List<Client> Clients = new List<Client>();
        public static ConsoleTable console;
        public static List<Reservation> Reservations = new List<Reservation>();
        public static List<Table> Tables = null;
        public static List<String> listEntrees = new List<string>();
        public static List<String> listPlats = new List<string>();
        public static List<String> listDesserts = new List<string>();
        public static ChefRang CR1, CR2;
        public static Serveur Serveur1, Serveur2, Serveur3, Serveur4;
        public static string Time { get; set; }

        public static List<Commande> commandes = new List<Commande>();

        public static List<int> groupList = new List<int>();

        private Restaurant()
        {
            Nyancat nyancat = Nyancat.Instance();
            Employes.Add(nyancat);
            MH = MaitreHotel.Instance();
            CC = ChefCuisine.Instance();
            commisSalle = new CommisSalle();
            console = ConsoleTable.Instance();
            C1 = new Cuisinier("C1");
            C2 = new Cuisinier("C2");
            commisCuisine = new CommisCuisine();
            Employes.Add(MH);
            GRCT = GestionReservationsClientsTables.Instance();
            CPC = ComptoirPlatsChauds.Instance();
            CR1 = new ChefRang(1, 1130, 520);
            CR2 = new ChefRang(2, 1130, 480);
            Employes.Add(CR1);
            Employes.Add(CR2);
            Serveur1 = new Serveur(1, 1130, 320);
            Serveur2 = new Serveur(1, 1130, 280);
            Serveur3 = new Serveur(2, 1130, 240);
            Serveur4 = new Serveur(2, 1130, 200);
            Employes.Add(Serveur1);
            Employes.Add(Serveur2);
            Employes.Add(Serveur3);
            Employes.Add(Serveur4);

            Database.Instance().GetRecettesNames();

            Tables = Database.Instance().GetTables();

            MH.appelerChefRang();

            GenererReservation();
            
            foreach (var res in Reservations)
            {
                View.Game1.Print("Res : " + res.NbClient + " clients à " + res.Heure);
            }

            //View.Game1.Print(Reservations.Find(x => x.Table.Equals("front")).GetType().Name.ToString());

            ThreadPool.QueueUserWorkItem(ThreadReservation);
            //Thread threadReservation = new Thread(ThreadReservation);
            //threadReservation.Start();
            ThreadPool.QueueUserWorkItem(ThreadClientAleatoire);
            //Thread threadClientAleatoire = new Thread(ThreadClientAleatoire);
            //threadClientAleatoire.Start();

        }
        //View.Game1.Print(res.NbClient + "clients pour la table " + res.numTable);
        

        public static void ThreadReservation(object args)
        {
            int NbReservation = Reservations.Count;
            // Tant qu'il reste des réservations et que le thread actuel est vivant
            while(NbReservation > 0 && Thread.CurrentThread.IsAlive)
            {
                foreach (Reservation res in Reservations)
                {
                    if (res.Heure.Hour == (Clock.Minutes + 10) && res.Heure.Minute == Clock.Seconds)
                    {
                        View.Game1.Print("La réservation de la table " + res.numTable + " pour " + res.NbClient + " personnes vient d'arriver");
                        GRCT.CreationClient(res.numTable, res.NbClient, Thread.CurrentThread);
                        NbReservation--;
                    }
                }
                Thread.Sleep(Clock.STime(1000));
            }
        }

        public static void ThreadClientAleatoire(object args)
        {
            // Tant que le thread actuel est vivant
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(Clock.STime(1000)); // 1 sec
                Random random = new Random();
                bool boolValue = Convert.ToBoolean(random.Next() % 2);

                if (boolValue == true)
                {
                    int nbClient = new Random().Next(1, 11);
                    GRCT.CreationClient(0, nbClient, Thread.CurrentThread);
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
            Table table = Restaurant.Tables.Find(x => x.Numero.Equals(numTable));
            return table;
        }
    }
}
