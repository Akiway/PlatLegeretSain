using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class AttendDessert : IClientState
    {
        public AttendDessert()
        {
            this.semaphoreCommisCuisine = new Semaphore(1, 1);
        }

        public Semaphore semaphoreCommisCuisine;

        public void ManageClient(Client context)
        {
            List<Repas> repas = Restaurant.tableChaude.GetDish("dessert", context.numTable);

            semaphoreCommisCuisine.WaitOne();
            foreach (Repas element in repas)
            {
                Restaurant.commisCuisine.EmmenerPlatComptoir(element);
            }
            Restaurant.commisCuisine.callWaiter(context.numTable);
            semaphoreCommisCuisine.Release();
        }
    }
}
