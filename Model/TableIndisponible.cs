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

        public void AccueillirClient(IEtatTable etatTable, int numReservation, List<Client> clients)
        {
            View.Game1.Print("TestTableInDisponible");
        }
    }
}