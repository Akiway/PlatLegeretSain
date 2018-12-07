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
        public string orientation { get; set; }
        public Client client;

        public Client(int numGroup)
        {
            this.groupe = numGroup;
            this.X = 1220;
            this.Y = 1000;
            this.img = "Client_";
            this.orientation = "back";
            this.client = this;
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

        private int vitesse { get; set; }
        public int groupe { get; set; }
        public int numTable = 0;
        public Commande Commande { get; set; }
        private Reservation Reservation { get; set; }

        public Observateur Observateur { get; set; }

        public void NotifierObservateur()
        {
            throw new System.NotImplementedException();
        }

        public void QuitterRestaurant()
        {
            Thread threadClientAleatoire = new Thread(new ThreadStart(Sortir));
            threadClientAleatoire.Start();
        }

        public void Sortir()
        {
            while (client.X > 1200)
            {
                client.MoveLeft(1);
                Thread.Sleep(20);
            }
            while (client.Y < 1000)
            {
                client.MoveDown(1);
                Thread.Sleep(20);
            }
            client = null;
        }

    }
}