using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    sealed class ComptoirPlatsChauds
    {
        // Singleton
        private static ComptoirPlatsChauds CPC = null;
        public static ComptoirPlatsChauds Instance()
        {
            if (CPC == null)
                CPC = new ComptoirPlatsChauds();
            return CPC;
        }

        public List<Repas> dishReady = new List<Repas>();

        public void NewDishReady(Repas repas)
        {
            this.dishReady.Add(repas);
        }

        public List<Repas> GetDish(int numTable)
        {
            List<Repas> listDishReady = new List<Repas>();
            listDishReady = this.dishReady.FindAll(x => x.numTable.Equals(numTable));

            foreach(Repas element in listDishReady)
            {
                this.dishReady.Remove(element);
            }
            return listDishReady;
        }
    }
}