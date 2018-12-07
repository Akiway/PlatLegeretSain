using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PlatLegeretSain.Model
{
    sealed class GestionReservationsClientsTables
    {
        // Singleton
        private static GestionReservationsClientsTables GRCT = null;
        public static GestionReservationsClientsTables Instance()
        {
            if (GRCT == null)
                GRCT = new GestionReservationsClientsTables();
            return GRCT;
        }

        private GestionReservationsClientsTables()
        {
        }

        // Creation des objets Client et appel du Maitre d'hotel
        public void CreationClient(int numTable, int nbClient, Thread currentThread)
        {
            List<Client> listClient = new List<Client>();

            int numGroup = Restaurant.groupList.FindLast(n => n < 10000) + 1;
            Restaurant.groupList.Add(numGroup);
            for (int x = 0; x < nbClient; x++)
            {
                Restaurant.Clients.Add(new Client(numGroup));
                listClient.Add(new Client(numGroup));
            }

            // Déplace les nouveaux clients jusqu'à l'accueil
            while (Restaurant.Clients.Find(x => x.groupe == numGroup).Y > 850)
            {
                foreach (Client client in Restaurant.Clients.FindAll(x => x.groupe == numGroup))
                {
                    client.MoveUp(1);
                }
                Thread.Sleep(20); // 0.02sec
            }
            Thread.Sleep(2000); // 2sec

            Restaurant.MH.AccueillirClient(numTable, listClient);
            listClient.Clear();
        }


        //Vérifie si une table est disponible et renvoi son numéro
        public int CheckTableDisponibility(int nbClient)
        {
            bool findTable = false;
            int numTable = 0;
            // Tant que toutes les tables sont pas vérifiées ou qu'une table n'est pas trouvéé :
            for (int i = nbClient; i < 11 && findTable == false; i++)
            {
                List<Table> listTables = new List<Table>();
                listTables = Restaurant.Tables.FindAll(x => x.NbPlace.Equals(i));
                if (listTables.FindAll(x => x.Disponible.Equals(true)).Count != 0)
                {
                    // Récupération de l'objet Table de la table disponible
                    Table table = listTables.Find(x => x.Disponible.Equals(true));
                    // Indique que la table n'est plus disponible
                    table.Disponible = false;
                    findTable = true;
                    numTable = table.Numero;
                }
            }
            return numTable;
        }

        public void TableAssignment(int numTable)
        {
            // Affection du numéro de la table aux clients
            foreach (Client element in Restaurant.Clients.FindAll(x => x.numTable.Equals(0)))
            {
                element.numTable = numTable;
            }

            // Appelle le bon Chef de rang
            if (numTable <= (Restaurant.Tables.Count) / 2)
            {
                Restaurant.CR1.installerClient(numTable);
            }
            else
            {
                Restaurant.CR2.installerClient(numTable);
            }

            //Vérifie s'il reste toujours des places
            if (Restaurant.Tables.FindAll(x => x.Disponible.Equals(true)).Count == 0)
            {
                Restaurant.MH.setState(new TableIndisponible());
            }
            else // A présent, il n'y a plus de places
            {

            }
        }
    }
}
