using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class CheckOrder : IClientState
    {
        public void ManageClient(Client context)
        {
            if (context.numTable <= Restaurant.Tables.Count / 2)
            {
                Restaurant.CR1.prendreCommande(context.numTable);
            }
            else
            {
                Restaurant.CR2.prendreCommande(context.numTable);
            }
        }
    }
}
