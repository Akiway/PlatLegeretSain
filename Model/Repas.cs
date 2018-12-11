using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public abstract class Repas
    {
        public Repas()
        {
            this.ready = false;
        }

        public string nom;
        public int numTable;
        public Recette recette;
        public bool ready;

        public void Conception(object args)
        {
            Cuisinier cuisinier = (Cuisinier)args;
            Thread.Sleep(Clock.STime(this.recette.tempsCuisson * 100));
            this.ready = true;
            cuisinier.DishReady(this);
        }
    }
}