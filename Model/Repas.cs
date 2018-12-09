using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public abstract class Repas
    {
        public string nom;
        public int numTable;
        public Recette recette;

        public void EnChauffe(Cuisinier cuisinier)
        {
            Thread.Sleep(Clock.STime(this.recette.tempsCuisson));
            cuisinier.DishReady(this);
        }
    }
}