using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class ChefRang : Employe
    {
        private int Carre { get; set; }
        public List<Commande> commandes { get; set; }
        public bool Occuped;
        public Semaphore CRPool;

        public ChefRang(int carre, int x = 1130, int y = 500)
        {
            this.Carre = carre;
            this.X = x;
            this.Y = y;
            this.img = "Cr_";
            this.Orientation = "left";
            this.Occuped = false;
            CRPool = new Semaphore(1, 1);
        }

        public void installerClient(object args)
        {
            int numTable = (int)args;
            Table table = Restaurant.Tables.Find(x => x.Numero.Equals(numTable));
            int nbClientAPlacer = Restaurant.Clients.FindAll(x => x.numTable.Equals(numTable)).Count;

            this.CRPool.WaitOne();
            MoveToReception();
            // Wait 1 at the MH stand
            Thread.Sleep(Clock.STime(1000));

            List<Client> clients = Restaurant.Clients.FindAll(x => x.numTable.Equals(table.Numero));
            foreach (Client client in Restaurant.Clients.FindAll(x => x.numTable.Equals(table.Numero)))
            {
                client.imgEtat = "table_";
            }
            int nbPlaces = table.NbPlace;
            int half = nbPlaces / 2;
            int cx = table.X;
            int cy = table.Y;
            int clx, cly;
            int tour = 0;
            int clientActuel = 0;
            int ecart = 45, decalage = ecart / 2;

            if (table.OrientationHorizontale) // Horizontal
            {
                if (half % 2 != 0) // 2, 6, 10 places
                {
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        cly = cy - decalage;
                        clx = cx - (ecart * half / 2 - decalage) + ecart * tour;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "front";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        cly = cy + decalage;
                        clx = cx - (ecart * half / 2 - decalage) + ecart * tour + 1;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "back";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }

                }
                else // 4, 8 places
                {
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        cly = cy - decalage;
                        clx = cx + decalage + (tour - half / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "front";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        cly = cy + decalage;
                        clx = cx + decalage + (tour - half / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "back";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                }

            }
            else // Vertical
            {
                if (half % 2 != 0) // 2, 6, 10 places
                {
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        clx = cx + decalage;
                        cly = cy - (tour - (half - 1) / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "left";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        clx = cx - decalage;
                        cly = cy - (tour - (half - 1) / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "right";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                }
                else // 4, 8 places
                {
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        clx = cx + decalage;
                        cly = cy + decalage + (tour - half / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "left";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        clx = cx - decalage;
                        cly = cy + decalage + (tour - half / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].Orientation = "right";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                }
            }
            DonnerCarte(clients);
        }

        private void DonnerCarte(object args)
        {
            List<Client> listClients = (List<Client>) args;
            int numTable = listClients[0].numTable;
            MoveToTable(numTable);

            listClients[0].setState(new LookMenu());
            // CR stay at table 1 min
            Thread.Sleep(Clock.STime(1000));
            MoveToOrigin();
            this.CRPool.Release();
            // CR go away 4 min :
            Thread.Sleep(Clock.STime(4000));
            
            this.CRPool.WaitOne();
            MoveToTable(numTable);

            listClients[0].setState(new ReadyToOrder());
            // CR stay at table 1 min
            Thread.Sleep(Clock.STime(1000));
            MoveToCuisine();
            // CR give the new ticket to the kitchen 1 min
            Thread.Sleep(Clock.STime(1000));
            MoveToOrigin();
            this.CRPool.Release();

            CommisSalle.CommisSallePool.WaitOne();
            Restaurant.commisSalle.BringBread(numTable);
            CommisSalle.CommisSallePool.Release();
        }

        public void takeOrder(int numTable)
        {
            List<Commande> commandes = new List<Commande>();
            List<Client> clients = new List<Client>();

            Random r = new Random();

            clients = Restaurant.Clients.FindAll(x => x.numTable.Equals(numTable));

            //int vitesseManger = new Random().Next(1, 4); // (1, 4) pour chiffre compris entre 1 et 3
            int vitesseManger = 1;
            //int UnDeuxFois = new Random().Next(1, 3); // (1, 3) pour chiffre compris entre 1 et 2
            int UnDeuxFois = 1;

            View.Game1.Print("============= Commandes de la table "+ numTable +" =============");

            foreach (Client element in clients)
            {
                Commande commande = element.ChoixCommande(vitesseManger, UnDeuxFois, r.Next(0, Restaurant.listEntrees.Count), r.Next(0, Restaurant.listPlats.Count), r.Next(0, Restaurant.listDesserts.Count));
                commandes.Add(commande);
            }

            if(UnDeuxFois == 2)
            {
                Restaurant.Tables.Find(x => x.Numero.Equals(numTable)).DessertApres = true;
            }
            else
            {
                Restaurant.Tables.Find(x => x.Numero.Equals(numTable)).DessertApres = false;
            }

            View.Game1.Print("vitesseManger : " + vitesseManger + " / UnDeuxFois : " + UnDeuxFois);
            foreach (Commande element in commandes)
            {
                View.Game1.Print(element.entree+" / "+ element.plat+" / "+ element.dessert);
            }

            ThreadPool.QueueUserWorkItem(Restaurant.CC.NewCommande, commandes);
        }

        public void MoveToReception()
        {
            this.X = 1180;
            this.Y = 870;
            this.Orientation = "right";
        }

        public void MoveToCuisine()
        {
            this.X = 1180;
            this.Y = 300;
            this.Orientation = "right";
        }
    }
}