using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class LookMenu : IClientState
    {
        public void ManageClient(Client context)
        {
            int numTable = context.numTable;

            if(numTable <= Restaurant.Tables.Count / 2)
            {
                Restaurant.Serveur1.BringBread(numTable);
            }
            else
            {
                Restaurant.Serveur2.BringBread(numTable);
            }
        }
    }
}
