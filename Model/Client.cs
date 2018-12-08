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
        }

        public void ManageClient()
        {
            clientState.ManageClient(this);
        }

        public void setState(IClientState newState)
        {
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
            ThreadPool.QueueUserWorkItem(Sortir);
            //Thread threadQuitterRestaurant = new Thread(new ThreadStart(Sortir));
            //threadQuitterRestaurant.Start();
        }

        public void Sortir(object args)
        {
            while (client.X > 1220)
            {
                client.MoveLeft(1);
                Thread.Sleep(20);
            }
            while (client.Y < 1020)
            {
                client.MoveDown(1);
                Thread.Sleep(20);
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
            Commande commande = new Commande(entree, plat, dessert);
            return commande;
        }
    }
}