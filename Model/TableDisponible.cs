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
                View.Game1.Print("MH > groupe " + clients[0].groupe + " a une réservation");
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
                        View.Game1.Print("MH > groupe " + clients[0].groupe + " a une table libre");
                        Restaurant.GRCT.TableAssignment(numeroTable, clients);
                    }
                    else // Plus de table assez grande
                    {
                        View.Game1.Print("MH > groupe " + clients[0].groupe + " n'a plus de table assez grande");
                        View.Game1.Print("Client > notre groupe de " + clients.Count + " sort");
                        foreach (Client client in clients)
                        {
                            client.QuitterRestaurant();
                        }
                    }
                }
                else // Plus de table libre
                {
                    View.Game1.Print("MH > groupe " + clients[0].groupe + " restaurant plein");
                    Restaurant.MH.setState(new TableIndisponible());
                }
            }
        }
    }
}