using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class Client : IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string img { get; set; }
        public string imgEtat { get; set; }
        public string orientation { get; set; }
        private int vitesse { get; set; }
        public int groupe { get; set; }
        public int numTable = 0;
        public Commande Commande { get; set; }
        private Reservation Reservation { get; set; }
        public Client client;
        public IClientState clientState { get; set; }
        public Semaphore disponibiliteServeurCarre1;
        public Semaphore disponibiliteServeurCarre2;

        public Client(int numGroup)
        {
            this.groupe = numGroup;
            this.X = 1240;
            this.Y = 1000;
            this.img = "Client_";
            this.imgEtat = "";
            this.orientation = "back";
            this.client = this;
            this.clientState = new WaitForTable();
            disponibiliteServeurCarre1 = new Semaphore(2, 2);
            disponibiliteServeurCarre2 = new Semaphore(2, 2);
        }

        public void ManageClient()
        {
            clientState.ManageClient(this);
        }

        public void setState(IClientState newState)
        {
            this.clientState = newState;
            ManageClient();
        }

        public void MoveUp(int distance)
        {
            this.Y -= distance;
            this.orientation = "back";
        }

        public void MoveDown(int distance)
        {
            this.Y += distance;
            this.orientation = "front";
        }

        public void MoveLeft(int distance)
        {
            this.X -= distance;
            this.orientation = "left";
        }

        public void MoveRight(int distance)
        {
            this.X += distance;
            this.orientation = "right";
        }

        public void QuitterRestaurant()
        {
            //ThreadPool.QueueUserWorkItem(Sortir);
            Thread threadQuitterRestaurant = new Thread(Sortir);
            threadQuitterRestaurant.Start();
        }

        public void Sortir(object args)
        {
            while (client.X > 1220)
            {
                client.MoveLeft(1);
                Thread.Sleep(Clock.STime(20));
            }
            while (client.Y < 1020)
            {
                client.MoveDown(1);
                Thread.Sleep(Clock.STime(20));
            }
            Restaurant.Clients.Remove(client);
            client = null;
        }

        public Commande ChoixCommande(int vitesseManger, int UnDeuxFois, int random1, int random2, int random3)
        {
            List<String> listChoix = new List<string>(new String[] { "Entree", "Plat", "Dessert" });

            if (UnDeuxFois == 2)
            {
                listChoix.Remove("Dessert");
                vitesseManger -= 1;
            }

            String entree = "", plat = "", dessert = "";

            for (int i = 0; i < vitesseManger; i++)
            {
                int index = new Random().Next(listChoix.Count);
                //string randomResult = listChoix[index];
                string randomResult = "Entree";

                switch (randomResult)
                {
                    case "Entree":
                        entree = Restaurant.listEntrees[random1];
                        listChoix.Remove("Entree");
                        break;
                    case "Plat":
                        plat =  Restaurant.listPlats[random2];
                        listChoix.Remove("Plat");
                        break;
                    case "Dessert":
                        dessert = Restaurant.listDesserts[random3];
                        listChoix.Remove("Dessert");
                        break;
                }
            }
            Commande commande = new Commande(entree, plat, dessert, this.numTable);
            this.Commande = commande;
            return commande;
        }

        public void Eat(object args)
        {
            Repas repas = (Repas)args;
            int tempsAttente = 0;

            switch (repas.nom)
            {
                case "entree":
                    tempsAttente = 15;
                    break;
                case "plat":
                    tempsAttente = 25;
                    break;
                case "dessert":
                    tempsAttente = 10;
                    break;
            }

            View.Game1.Print("Les clients de la table " + this.numTable + " mange leur " + repas.nom);

            Thread.Sleep(Clock.STime(tempsAttente * 1000)); // Multiplier par 3600 pour temps reel

            if (numTable <= Restaurant.Tables.Count / 2)
            {
                disponibiliteServeurCarre1.WaitOne();
                if (Restaurant.Serveur1.Occuped == false)
                {
                    Restaurant.Serveur1.debarasser(numTable);
                }
                else if (Restaurant.Serveur2.Occuped == false)
                {
                    Restaurant.Serveur2.debarasser(numTable);
                }
                disponibiliteServeurCarre1.Release();
            }
            else
            {
                disponibiliteServeurCarre2.WaitOne();
                if (Restaurant.Serveur3.Occuped == false)
                {
                    Restaurant.Serveur3.debarasser(numTable);
                }
                else if (Restaurant.Serveur4.Occuped == false)
                {
                    Restaurant.Serveur4.debarasser(numTable);
                }
                disponibiliteServeurCarre2.Release();
            }
        }
    }
}