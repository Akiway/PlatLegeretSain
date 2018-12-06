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

        public void AccueillirClient(IEtatTable etatTable, int numReservation, List<Client> clients)
        {
            if (numReservation != 0)
            {

            }
            else
            {
                // S'il reste des places
                if (Restaurant.Tables.FindAll(x => x.etat.Equals("disponible")).Count != 0)
                {
                    int nbClient = clients.Count;
                    bool findTable = false;

                    // Tant que toutes les tables sont pas vérifiées ou qu'une table n'est pas trouvéé :
                    for (int i = nbClient; i < 11 && findTable == false; i++)
                    {
                        List<Table> listTables = new List<Table>();
                        listTables = Restaurant.Tables.FindAll(x => x.nbPlace.Equals(i));
                        if (listTables.FindAll(x => x.etat.Equals("disponible")).Count != 0)
                        {
                            // Récupération de l'objet Table de la table disponible
                            Table table = listTables.Find(x => x.etat.Equals("disponible"));
                            // Affection du numéro de la table aux clients
                            foreach (Client element in Restaurant.Clients.FindAll(x => x.numTable.Equals(0)))
                            {
                                element.numTable = table.numero;
                            }
                            // Appelle le bon Chef de rang
                            if (table.numero <= (Restaurant.Tables.Count) / 2)
                            {
                                Restaurant.CR1.installerClient(table.numero);
                            }
                            else
                            {
                                Restaurant.CR2.installerClient(table.numero);
                            }
                            findTable = true;
                        }
                    }

                    //Vérifie s'il reste toujours des places
                    if (Restaurant.Tables.FindAll(x => x.etat.Equals("disponible")).Count == 0)
                    {
                        Restaurant.MH.setState(new TableIndisponible());
                    }
                    else // S'il n'y a plus de places
                    {

                    }
                }
            }
        }
    }
}