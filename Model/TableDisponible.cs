using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class TableDisponible : IFreeTable
    {
        public void AccueillirClient(IFreeTable etatTable, int numeroTable, List<Client> clients)
        {
            // Si le groupe a une réservation
            if (numeroTable != 0)
            {
                Restaurant.GRCT.TableAssignment(numeroTable, clients);
            }
            else
            {
                // S'il reste des places
                if (Restaurant.Tables.FindAll(x => x.Disponible.Equals(true)).Count != 0)
                {
                    int nbClient = clients.Count;
                    numeroTable = Restaurant.GRCT.CheckTableDisponibility(nbClient);

                    // Si une table libre adaptée a été trouvé
                    if (numeroTable != 0)
                    {
                        Restaurant.GRCT.TableAssignment(numeroTable, clients);
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