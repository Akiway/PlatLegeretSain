using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    sealed class ComptoirPlatsChauds : Employe
    {
        // Singleton
        private static ComptoirPlatsChauds CPC = null;
        public static ComptoirPlatsChauds Instance()
        {
            if (CPC == null)
                CPC = new ComptoirPlatsChauds();
            return CPC;
        }

        List<Repas> dishReady = new List<Repas>();
        private List<Repas> listDishReady;

        public void NewDishReady(Repas repas)
        {
            this.dishReady.Add(repas);
        }

        public List<Repas> GetDish()
        {
            // Copier la liste en local puis la vider
            List<Repas> listDishReady = new List<Repas>();
            listDishReady = dishReady;
            return this.listDishReady;
        }
    }
}