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
            this.orientation = "left";
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
            this.Occuped = true;
            List<Repas> listRepas = new List<Repas>();
            listRepas = ComptoirPlatsChauds.Instance().GetDish();

            ThreadPool.QueueUserWorkItem(Restaurant.Clients.Find(x => x.numTable.Equals(numTable)).Eat, listRepas[0]);
            // Deplacement à la table numéro numTable
            // Distribution des plats
            this.Occuped = false;
        }

    }
}