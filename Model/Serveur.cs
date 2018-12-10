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