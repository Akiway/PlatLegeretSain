﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class ChefRang : Employe
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

                } else // 4, 8 places
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

            } else // Vertical
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

            ThreadPool.QueueUserWorkItem(DonnerCarte, clients);
            //Thread threadCarte = new Thread(DonnerCarte);
            //threadCarte.Start(clients);
        }

        public void DonnerCarte(object args)
        {
            List<Client> clients = (List<Client>) args;

            //View.Game1.Print("Donne la carte aux clients");
            foreach (Client client in clients)
            {
                client.imgEtat = "carte_";
            }
            // Après 5 min :
            Thread.Sleep(5000);
            foreach (Client client in clients)
            {
                client.imgEtat = "table_";
            }
            // Etat du client = pret pour la commande
            //prendreCommande();
        }

        public void prendreCommande(int numTable)
        {
            //View.Game1.Print("Prend la commande");
        }
    }
}