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

            View.Game1.Print("Table " + numTable + " > Lit le menu");
            List<Client> listClients = Restaurant.Clients.FindAll(x => x.groupe == context.groupe);
            foreach (Client client in listClients)
            {
                client.imgEtat = "carte_";
            }

            View.Game1.Print("Table " + numTable + " > Le commis de salle apporte le pain et l'eau aux clients");
        }
    }
}
