using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class Serveur : Employe
    {
        private int Carre { get; set; }

        public Serveur(int carre, int x = 1130, int y = 200)
        {
            this.Carre = carre;
            this.X = x;
            this.Y = y;
            this.img = "Serveur_";
            this.Orientation = "left";
            this.Occuped = false;
        }

        public bool Occuped;

        public void debarasser(int numTable)
        {
            this.Occuped = true;

            View.Game1.Print("Un serveur débarasse la table " + numTable);

            this.Occuped = false;
        }

        public void BringDish(int numTable)
        {
            View.Game1.Print(" --------------------------------------------------------------------------- BringDish !");
            
            this.Occuped = true;
            // Deplacement au comptoir 1 sec
            MoveToCuisine();
            Thread.Sleep(Clock.STime(1000));
            List<Repas> listRepas = new List<Repas>();
            listRepas = ComptoirPlatsChauds.Instance().GetDish();

            // Deplacement à la table numéro numTable
            MoveToTable(numTable);
            // Distribution des plats       BUG : listRepas est vide
            ThreadPool.QueueUserWorkItem(Restaurant.Clients.Find(x => x.numTable.Equals(numTable)).Eat, listRepas[0]);
            // Wait at the table 1 sec
            Thread.Sleep(Clock.STime(1000));
            MoveToOrigin();
            View.Game1.Print(ComptoirPlatsChauds.Instance().dishReady.Count.ToString());
            View.Game1.Print(listRepas.Count.ToString());

            foreach (Repas element in listRepas)
            {
                View.Game1.Print(" ----------------------------------------------------------- "+element.nom);
            }

            //ThreadPool.QueueUserWorkItem(Restaurant.Clients.Find(x => x.numTable.Equals(numTable)).Eat, listRepas[0]);

            // Deplacement à la table numéro numTable
            // Distribution des plats
            this.Occuped = false;
        }

        public void MoveToCuisine()
        {
            this.X = 1180;
            this.Y = 250;
            this.Orientation = "right";
        }
    }
}