using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class TableIndisponible : IEtatTable
    {
        public TableIndisponible()
        {
            //throw new System.NotImplementedException();
        }

        public void AccueillirClient(IEtatTable etatTable, int numeroTable, List<Client> clients)
        {
            if (numeroTable != 0)
            {
                Restaurant.GRCT.TableAssignment(numeroTable);
            }
            else
            {
                foreach (Client client in clients)
                {
                    client.QuitterRestaurant();
                }
                View.Game1.Print("TableIndisponible");
            }
        }
    }
}