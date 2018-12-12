﻿using System.Collections.Generic;
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
            Serveur1 = new Serveur(1);
            Serveur1.SetOrigin(1130, 320, "left", true);
            Serveur2 = new Serveur(1);
            Serveur2.SetOrigin(1130, 280, "left", true);
            Serveur3 = new Serveur(2);
            Serveur3.SetOrigin(1130, 240, "left", true);
            Serveur4 = new Serveur(2);
            Serveur4.SetOrigin(1130, 200, "left", true);
            Employes.Add(Serveur1);
            Employes.Add(Serveur2);
            Employes.Add(Serveur3);
            Employes.Add(Serveur4);
            // Nyancat magique de l'espace
            Nyancat nyancat = Nyancat.Instance();
            Employes.Add(nyancat);

            GRCT = GestionReservationsClientsTables.Instance();
            CPC = ComptoirPlatsChauds.Instance();
            console = ConsoleTable.Instance();

            Database.Instance().GetRecettesNames();

            Tables = Database.Instance().GetTables();

            GenererReservation();
            foreach (var res in Reservations)
            {
                View.Game1.Print("Reservation : " + res.NbClient + " clients à " + res.Heure);
            }

            ThreadPool.QueueUserWorkItem(ThreadReservation);
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

                if (boolValue == true)
                {
                    int nbClient = new Random().Next(1, 11);
                    GRCT.CreationClient(0, nbClient, Thread.CurrentThread);
                }
                Thread.Sleep(Clock.STime(3000)); // 3 sec
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
