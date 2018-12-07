using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class ChefRang : Employe, IObservateur
    {
        private int Carre { get; set; }

        public ChefRang(int carre, int x = 1130, int y = 500)
        {
            this.Carre = carre;
            this.X = x;
            this.Y = y;
            this.img = "Cr_";
            this.orientation = "left";
        }

        public List<Commande> commandes
        {
            get => default(List<Commande>);
            set
            {
            }
        }

        public void installerClient(int numTable)
        {
            int nbClient = Restaurant.Clients.FindAll(x => x.numTable.Equals(numTable)).Count;
            View.Game1.Print("----------------------------");
            View.Game1.Print("Je place "+nbClient+" client à la table numéro : "+numTable);

            DeplacerClient(Restaurant.Tables.Find(x => x.Numero.Equals(numTable)), nbClient);
            foreach (Client client in Restaurant.Clients.FindAll(x => x.numTable.Equals(numTable)))
            {
                //Restaurant.Tables.Find(x => x.Numero.Equals(numTable));
            }
        }

        private void DeplacerClient(Table table, int nbClientAPlacer)
        {
            List<Client> clients = Restaurant.Clients.FindAll(x => x.numTable.Equals(table.Numero));
            //foreach (Client client in Restaurant.Clients.FindAll(x => x.numTable.Equals(table.Numero)))
            //{
            int nbPlaces = table.NbPlace;
            int haut = nbPlaces / 2;
            int bas = nbPlaces / 2;
            int cx = table.X;
            int cy = table.Y;
            int clx, cly;
            int tour = 0;
            int clientActuel = 0;

                
            if (table.OrientationHorizontale) // Horizontal
            {
                int ecart = 46, decalage = -12;
                if (haut % 2 != 0) // 2, 6, 10 places
                {
                    while (tour < haut && nbClientAPlacer > 0)
                    {
                        cly = cy - ecart;
                        clx = cx - (ecart * haut / 2 + decalage) + ecart * tour;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "front";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < bas && nbClientAPlacer > 0)
                    {
                        cly = cy + decalage;
                        clx = cx - (ecart * bas / 2 + decalage) + ecart * tour;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "back";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }

                } else // 4, 8 places
                {
                    int ecart2 = 14;
                    while (tour < haut && nbClientAPlacer > 0)
                    {
                        cly = cy - ecart;
                        clx = cx + ecart2 + (tour - haut / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "front";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < bas && nbClientAPlacer > 0)
                    {
                        cly = cy + decalage;
                        clx = cx + ecart2 + (tour - bas / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "back";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                }

            } else // Vertical
            {
                int ecart = 46, decalageX = 14, decalageX2 = 38;
                if (haut % 2 != 0) // 2, 6, 10 places
                {
                    int decalage = 14;
                    while (tour < haut && nbClientAPlacer > 0)
                    {
                        clx = cx + decalageX;
                        cly = cy - decalage - (tour - (haut - 1) / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "left";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < bas && nbClientAPlacer > 0)
                    {
                        clx = cx - decalageX2;
                        cly = cy - decalage - (tour - (bas - 1) / 2) * ecart;
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
                    int decalage = 4;
                    while (tour < haut && nbClientAPlacer > 0)
                    {
                        clx = cx + decalageX;
                        cly = cy + decalage + (tour - bas / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "left";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                    tour = 0;
                    while (tour < bas && nbClientAPlacer > 0)
                    {
                        clx = cx - decalageX2;
                        cly = cy + decalage + (tour - bas / 2) * ecart;
                        clients[clientActuel].X = clx;
                        clients[clientActuel].Y = cly;
                        clients[clientActuel].orientation = "right";
                        tour++;
                        nbClientAPlacer--;
                        clientActuel++;
                    }
                }
            }
            //}
        }

        public void donnerCarte()
        {
            throw new System.NotImplementedException();
        }

        public void prendreCommande()
        {
            throw new System.NotImplementedException();
        }

        public void notifier()
        {
            throw new System.NotImplementedException();
        }
    }
}