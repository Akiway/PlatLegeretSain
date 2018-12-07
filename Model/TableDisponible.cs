using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class TableDisponible : IEtatTable
    {
        public TableDisponible()
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
                // S'il reste des places
                if (Restaurant.Tables.FindAll(x => x.Disponible.Equals(true)).Count != 0)
                {
                    int nbClient = clients.Count;
                    int numTable = Restaurant.GRCT.CheckTableDisponibility(nbClient);

                    if (numTable != 0)
                    {
                        Restaurant.GRCT.TableAssignment(numTable);
                    }
                    else
                    {
                        // Plus de place disponible
                        Restaurant.MH.setState(new TableIndisponible());
                    }
                }
            }
        }
    }
}