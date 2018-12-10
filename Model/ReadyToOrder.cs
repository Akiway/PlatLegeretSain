using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class ReadyToOrder : IClientState
    {
        public void ManageClient(Client context)
        {
            int numTable = context.numTable;

            if (numTable <= Restaurant.Tables.Count / 2)
            {
                Restaurant.CR1.takeOrder(numTable);
                View.Game1.Print("Le chef de rang 1 prend la commande de la table "+numTable);
            }
            else
            {
                Restaurant.CR2.takeOrder(numTable);
                View.Game1.Print("Le chef de rang 2 prend la commande de la table " + numTable);
            }
        }
    }
}
