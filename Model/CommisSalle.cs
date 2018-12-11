using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class CommisSalle : Employe
    {
        public CommisSalle()
        {
            this.Occuped = false;
        }

        public bool Occuped;

        public void servir()
        {
            
        }

        public void aider()
        {
            
        }

        public void BringBread(int numTable)
        {
            this.Occuped = true;
            // Apporter le pain et l'eau à la table numTable
            if (Restaurant.Tables.Find(x => x.Numero.Equals(numTable)).NbPlace > 6)
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
    }
}