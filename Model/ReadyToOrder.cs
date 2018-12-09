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
            }
            else
            {
                Restaurant.CR2.takeOrder(numTable);
            }
        }
    }
}
