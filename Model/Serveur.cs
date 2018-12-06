using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Serveur : Employe, IObservateur
    {
        private int Carre { get; set; }

        public Serveur(int carre, int x = 1130, int y = 200)
        {
            this.Carre = carre;
            this.X = x;
            this.Y = y;
            this.img = "Serveur_";
            this.orientation = "left";
        }

        public List<Repas> repas
        {
            get => default(List<Repas>);
            set
            {
            }
        }

        public Boolean etat
        {
            get => default(Boolean);
            set
            {
            }
        }

        public void debarasser()
        {
            throw new System.NotImplementedException();
        }

        public void notifier()
        {
            throw new System.NotImplementedException();
        }
    }
}