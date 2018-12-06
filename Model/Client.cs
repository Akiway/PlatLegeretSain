using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Client
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Client(int numGroup)
        {
            this.groupe = numGroup;
        }

        public void MoveUp(int distance)
        {
        }

        public void MoveDown(int distance)
        {
        }

        public void MoveLeft(int distance)
        {
        }

        public void MoveRight(int distance)
        {
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
    }
}