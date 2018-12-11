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

        public void EnChauffe(Cuisinier cuisinier)
        {
            Thread threadWaitTime = new Thread(new ParameterizedThreadStart(WaitTime));
            threadWaitTime.Start(cuisinier);
        }

        public void WaitTime(object args)
        {
            Cuisinier cuisinier = (Cuisinier)args;
            //Thread.Sleep(Clock.STime(this.recette.tempsCuisson));
            Thread.Sleep(Clock.STime(5000));
            this.ready = true;
            cuisinier.DishReady(this);
        }
    }
}