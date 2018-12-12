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
                Client newClient = new Client(numGroup);
                Restaurant.Clients.Add(newClient);
                listClient.Add(newClient);
            }

            // Déplace les nouveaux clients jusqu'à l'accueil
            // A FAIRE : Dupliquer la liste en locale pour éviter le platage du a une modification de la liste PS: listclient est déjà locale héhé je suis débile à pas l'utiliser...
            while (listClient[listClient.Count - 1].Y > 850)
            {
                foreach (Client client in listClient)
                {
                    client.MoveUp(1);
                }
                Thread.Sleep(Clock.STime(20)); // 0.02sec
            }
            Thread.Sleep(Clock.STime(2000)); // 2sec

            Restaurant.MH.AccueillirClient(numTable, listClient);
            listClient.Clear();
        }

        //Vérifie si une table est disponible et renvoi son numéro
        public int CheckTableDisponibility(int nbClient)
        {
            bool findTable = false;
            int numTable = 0;
            // Tant que toutes les tables sont pas vérifiées ou qu'une table n'est pas trouvée :
            for (int i = nbClient; i < 11 && findTable == false; i++)
            {
                List<Table> listTables = new List<Table>();
                listTables = Restaurant.Tables.FindAll(x => x.NbPlace.Equals(i));
                if (listTables.FindAll(x => x.Disponible.Equals(true)).Count != 0)
                {
                    listTables = listTables.FindAll(x => x.Disponible.Equals(true));
                    // Récupération de l'objet Table de la table disponible
                    Table table = listTables[0];
                    // Indique que la table n'est plus disponible
                    table.Disponible = false;
                    findTable = true;
                    numTable = table.Numero;
                }
            }
            return numTable;
        }

        public void TableAssignment(int numTable, List<Client> clients)
        {
            // Affectation du numéro de la table aux clients et modification de leur état en "AttenteTable"
            foreach (Client client in clients) {
                client.numTable = numTable;
            }
            clients[0].setState(new WaitForTable());

            // Vérifie s'il reste toujours des places
            if (Restaurant.Tables.FindAll(x => x.Disponible.Equals(true)).Count == 0)
            {
                Restaurant.MH.setState(new TableIndisponible());
            }
        }
    }
}
