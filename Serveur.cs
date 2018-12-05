using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain
{
    public class Serveur : Employe, IObservateur
    {
        public List<Repas> repas
        {
            get => default(int);
            set
            {
            }
        }

        public Boolean etat
        {
            get => default(int);
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