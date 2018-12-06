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

        public Client()
        {

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

        private int vitesse
        {
            get => default(int);
            set
            {
            }
        }

        private int groupe
        {
            get => default(int);
            set
            {
            }
        }

        public Commande Commande
        {
            get => default(Commande);
            set
            {
            }
        }

        private Reservation Reservation
        {
            get => default(Reservation);
            set
            {
            }
        }

        private Table Table
        {
            get => default(Table);
            set
            {
            }
        }

        public Observateur Observateur
        {
            get => default(Observateur);
            set
            {
            }
        }

        public void NotifierObservateur()
        {
            throw new System.NotImplementedException();
        }
    }
}