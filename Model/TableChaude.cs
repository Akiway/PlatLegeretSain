using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    sealed class TableChaude
    {
        // Singleton
        private static TableChaude tableChaude = null;
        public static TableChaude Instance()
        {
            if (tableChaude == null)
                tableChaude = new TableChaude();
            return tableChaude;
        }

        List<Repas> dishWaiting = new List<Repas>();

        public void NewDishWaiting(Repas repas)
        {
            this.dishWaiting.Add(repas);
        }

        public List<Repas> GetDish(String name, int numTable)
        {
            List<Repas> listDishWaiting = new List<Repas>();
            listDishWaiting = dishWaiting.FindAll(x => x.nom.Equals(name) && x.numTable.Equals(numTable));
            foreach(Repas element in listDishWaiting)
            {
                dishWaiting.Remove(element);
            }
            return listDishWaiting;
        }
    }
}
