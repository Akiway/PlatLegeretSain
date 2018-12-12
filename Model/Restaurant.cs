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
        public static Plongeur Plongeur;
        public static ComptoirPlatsChauds CPC;
        public static TableChaude tableChaude;
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
        public static List<Serveur> Serveurs = new List<Serveur>();
        public static string Time { get; set; }

        public static List<Commande> commandes = new List<Commande>();

        public static List<int> groupList = new List<int>();

        private Restaurant()
        {
            // Maître d'Hôtel
            MH = MaitreHotel.Instance();
            MH.SetOrigin(1230, 780, "front", true);
            Employes.Add(MH);
            // Chef de Cuisine
            CC = ChefCuisine.Instance();
            CC.SetOrigin(1250, 200, "front", true);
            Employes.Add(CC);
            // Commis de Salle
            commisSalle = new CommisSalle();
            commisSalle.SetOrigin(1240, 600, "left", true);
            Employes.Add(commisSalle);
            // Cuisiniers
            C1 = new Cuisinier("C1");
            C1.SetOrigin(1300, 150, "front", true);
            C2 = new Cuisinier("C2");
            C2.SetOrigin(1300, 250, "front", true);
            Employes.Add(C1);
            Employes.Add(C2);
            // Commis de Cuisine
            commisCuisine = new CommisCuisine();
            commisCuisine.SetOrigin(1450, 300, "front", true);
            Employes.Add(commisCuisine);
            // Plongeur
            Plongeur = new Plongeur();
            Plongeur.SetOrigin(1400, 550, "front", true);
            Employes.Add(Plongeur);
            // Chefs de Rangs
            CR1 = new ChefRang(1);
            CR1.SetOrigin(1130, 520, "left", true);
            CR2 = new ChefRang(2);
            CR2.SetOrigin(1130, 480, "left", true);
            Employes.Add(CR1);
            Employes.Add(CR2);
            // Serveurs
            for (int i = 0; i < Parameters.Serveur; i++)
            {
                Serveur Serveur = new Serveur(i < Parameters.Serveur/2 ? 1 : 2);
                Serveur.SetOrigin(1130, 320 - (40 * i), "left", true);
                Employes.Add(Serveur);
                Serveurs.Add(Serveur);
            }
            // Nyancat magique de l'espace
            Nyancat nyancat = Nyancat.Instance();
            Employes.Add(nyancat);

            GRCT = GestionReservationsClientsTables.Instance();
            CPC = ComptoirPlatsChauds.Instance();
            console = ConsoleTable.Instance();
            tableChaude = TableChaude.Instance();

            Database.Instance().GetRecettesNames();

            Tables = Database.Instance().GetTables();

            GenererReservation();
            foreach (var res in Reservations)
            {
                View.Game1.Print("Reservation : " + res.NbClient + " clients à " + res.Heure);
            }

            //ThreadPool.QueueUserWorkItem(ThreadReservation);
            ThreadPool.QueueUserWorkItem(ThreadClientAleatoire);
        }
        

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
                Random random = new Random();
                bool boolValue = Convert.ToBoolean(random.Next() % 2);

                Thread.Sleep(Clock.STime(6000)); // 3 sec

                if (boolValue == true)
                {
                    if (Restaurant.Clients.Count < 20)
                    {
                        int nbClient = new Random().Next(1, 11);
                        GRCT.CreationClient(0, nbClient, Thread.CurrentThread);
                    }
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
