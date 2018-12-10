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
            Restaurant.commisSalle.BringBread(numTable);
            View.Game1.Print("Le commis de salle apporte le pain et l'eau aux clients");
        }
    }
}
