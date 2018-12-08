using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public interface IFreeTable
    {
        void AccueillirClient(IFreeTable etatTable, int numeroTable, List<Client> clients);
    }
}