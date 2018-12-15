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
        public string Orientation { get; set; }
        private int vitesse { get; set; }
        public int groupe { get; set; }
        public int numTable = 0;
        public Commande Commande { get; set; }
        private Reservation Reservation { get; set; }
        public Client client;
        public IClientState clientState { get; set; }

        public Client(int numGroup)
        {
            this.groupe = numGroup;
            this.X = 1240;
            this.Y = 1000;
            this.img = "Client_";
            this.imgEtat = "";
            this.Orientation = "back";
            this.client = this;
            this.clientState = new WaitForTable();
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
            this.Orientation = "back";
        }

        public void MoveDown(int distance)
        {
            this.Y += distance;
            this.Orientation = "front";
        }

        public void MoveLeft(int distance)
        {
            this.X -= distance;
            this.Orientation = "left";
        }

        public void MoveRight(int distance)
        {
            this.X += distance;
            this.Orientation = "right";
        }

        public void QuitterRestaurant()
        {
            //ThreadPool impossible or every clients in the group will leave one by one instead of all together
            Thread threadQuitterRestaurant = new Thread(Sortir);
            threadQuitterRestaurant.Start();
        }

        public void Sortir(object args)
        {
            while (this.X > 1220)
            {
                this.MoveLeft(1);
                Thread.Sleep(Clock.STime(20));
            }
            while (this.Y < 1020)
            {
                this.MoveDown(1);
                Thread.Sleep(Clock.STime(20));
            }
            Restaurant.Clients.Remove(this);
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
                string randomResult = listChoix[index];

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

            switch (repas.type)
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
            View.Game1.Print("Les clients de la table " + this.numTable + " mange leur " + repas.type);

            Thread.Sleep(Clock.STime(tempsAttente * 1000)); // Multiplier par 3600 pour temps reel

            bool libererTable = false;
            // Les clients quittent le restaurant s'ils ont fini de manger
            if ((this.Commande.dessert != null && repas.type == "dessert") || (this.Commande.plat != null && this.Commande.dessert == null && repas.type == "plat") || (this.Commande.entree != null && this.Commande.plat == null && this.Commande.dessert == null && repas.type == "entree"))
            {
                View.Game1.Print("La table " + this.numTable + " a fini de manger et va partir");
                foreach (Client client in Restaurant.Clients.FindAll(x => x.numTable == this.numTable))
                {
                    client.Partir();
                    libererTable = true;
                }
            }

                // Les clients appelent le serveur pour debarasser
                List<Serveur> Serveurs;
            if (numTable <= Restaurant.Tables.Count / 2)
            {
                Serveurs = Restaurant.Serveurs.FindAll(x => x.Carre == 1);
                Restaurant.disponibiliteServeurCarre1.WaitOne();
                foreach (Serveur serveur in Serveurs)
                {
                    serveur.debarasser(numTable, libererTable);
                }
                Restaurant.disponibiliteServeurCarre1.Release();
            }
            else
            {
                Serveurs = Restaurant.Serveurs.FindAll(x => x.Carre == 2);
                Restaurant.disponibiliteServeurCarre2.WaitOne();
                foreach (Serveur serveur in Serveurs) 
                {
                    serveur.debarasser(numTable, libererTable);
                }
                Restaurant.disponibiliteServeurCarre2.Release();
            }

            // Changement d'état
            if (tempsAttente == 15 && this.Commande.plat != null)
            {
                this.setState(new AttendPlat());
            }
            else if( ( tempsAttente == 15 || tempsAttente == 25 ) && this.Commande.dessert != null)
            {
                this.setState(new AttendDessert());
            }
        }

        public void Partir()
        {
            this.X = 1220;
            this.Y = 850;
            this.Orientation = "back";
            this.imgEtat = "";
            Thread threadQuitterRestaurant = new Thread(Sortir);
            threadQuitterRestaurant.Start();
        }
    }
}