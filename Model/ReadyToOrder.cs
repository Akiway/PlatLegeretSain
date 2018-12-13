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
            View.Game1.Print("Table " + numTable + " débute de la prise de la commande à " + DateTime.Now.TimeOfDay);

            View.Game1.Print("Table " + numTable + " > Le commis de salle apporte le pain et l'eau aux clients");
            List<Client> listClients = Restaurant.Clients.FindAll(x => x.groupe == context.groupe);
            foreach (Client client in listClients)
            {
                client.imgEtat = "table_";
            }

            if (numTable <= Restaurant.Tables.Count / 2)
            {
                View.Game1.Print("CR1 > Je prend la commande de la table " + numTable);
                Restaurant.CR1.takeOrder(numTable);
            }
            else
            {
                View.Game1.Print("CR2 > Je prend la commande de la table " + numTable);
                Restaurant.CR2.takeOrder(numTable);
            }
        }
    }
}
