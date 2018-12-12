using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class Serveur : Employe
    {
        public int Carre { get; set; }

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
            MoveToTable(numTable);
            View.Game1.Print("Un serveur débarasse la table " + numTable);
            // Récupère la vaiselle
            Thread.Sleep(Clock.STime(1000));
            Restaurant.Tables.Find(x => x.Numero == numTable).ImgState = "";
            MoveToCuisine();
            // Dépose la vaiselle
            Thread.Sleep(Clock.STime(1000));
            this.Occuped = false;
        }

        public void BringDish(int numTable)
        {
            View.Game1.Print("Le serveur amene un plat à la table " + numTable);
            this.Occuped = true;
            // Deplacement au comptoir 1 sec
            MoveToCuisine();
            Thread.Sleep(Clock.STime(1000));
            // Deplacement à la table numéro numTable
            MoveToTable(numTable);
            // Wait at the table 1 sec
            Thread.Sleep(Clock.STime(1000));
            MoveToOrigin();

            List<Repas> listRepas = new List<Repas>();
            listRepas = Restaurant.CPC.GetDish(numTable);

            ThreadPool.QueueUserWorkItem(Restaurant.Clients.Find(x => x.numTable.Equals(numTable)).Eat, listRepas[0]);

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