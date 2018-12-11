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

        public ChefRang(int carre, int x = 1130, int y = 500)
        {
            this.Carre = carre;
            this.X = x;
            this.Y = y;
            this.img = "Cr_";
            this.orientation = "left";
            this.Occuped = false;
        }


        public void installerClient(int numTable)
        {
            int nbClient = Restaurant.Clients.FindAll(x => x.numTable.Equals(numTable)).Count;
            //View.Game1.Print("----------------------------");
            //View.Game1.Print("Je place "+nbClient+" client à la table numéro : "+numTable);

            DeplacerClient(Restaurant.Tables.Find(x => x.Numero.Equals(numTable)), nbClient);
        }

        private void DeplacerClient(Table table, int nbClientAPlacer)
        {
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
            int ecart = 46, decalage = ecart / 2;

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
                        clients[clientActuel].orientation = "front";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < half && nbClientAPlacer > 0)
                    {
                        cly = cy + decalage;
                        clx = cx - (ecart * half / 2 - decalage) + ecart * tour;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "back";
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
                        clients[clientActuel].orientation = "front";
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
                        clients[clientActuel].orientation = "back";
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
                        clients[clientActuel].orientation = "left";
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
                        clients[clientActuel].orientation = "right";
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
                        clients[clientActuel].orientation = "left";
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
                        clients[clientActuel].orientation = "right";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                }
            }

            //ThreadPool.QueueUserWorkItem(DonnerCarte, clients);
            if (this.Occuped == false)
            {
                Thread threadCarte = new Thread(new ParameterizedThreadStart(DonnerCarte));
                threadCarte.Start(clients);
            }
        }

        public void DonnerCarte(object args)
        {
            this.Occuped = true;
            List<Client> listClients = (List<Client>) args;
            int numTable = listClients[0].numTable;

            foreach (Client client in listClients)
            {
                client.imgEtat = "carte_";
            }
            View.Game1.Print("Chef raaaaaaaaaaaaaaaaaaaaaaaaaaaaang");
            listClients[0].setState(new LookMenu());
            // After 5 min :
            Thread.Sleep(Clock.STime(5000));
            listClients[0].setState(new ReadyToOrder());
            foreach (Client client in listClients)
            {
                client.imgEtat = "table_";
            }
            this.Occuped = false;
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
            donnerCommande(commandes);
        }

        public void donnerCommande(List<Commande> commandes)
        {
            Restaurant.CC.NewCommande(commandes);
        }
    }
}