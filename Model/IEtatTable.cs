using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public interface IEtatTable
    {
        void AccueillirClient(IEtatTable etatTable, int numReservation, List<Client> clients);
    }
}