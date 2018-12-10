using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<Repas> repas;

        public Boolean Occuped;

        public void BringBread(int numTable)
        {
            this.Occuped = true;
            // Apporter le pain et l'eau à la table numTable
            if(Restaurant.Tables.Find(x => x.Numero.Equals(numTable)).NbPlace > 6)
            {
                Restaurant.console.nbBouteilleEau -= 2;
                Restaurant.console.nbCorbeillePain -= 2;
            }
            else
            {
                Restaurant.console.nbBouteilleEau -= 1;
                Restaurant.console.nbCorbeillePain -= 1;
            }
            this.Occuped = false;
        }

        public void debarasser()
        {
           
        }

        public void BringDish(int numTable)
        {
            this.Occuped = true;
            List<Repas> listRepas = new List<Repas>();
            listRepas = ComptoirPlatsChauds.Instance().GetDish();
        }
    }
}