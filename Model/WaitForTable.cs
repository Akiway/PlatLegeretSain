using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class WaitForTable : IClientState
    {
        public void ManageClient(Client context)
        {
            if(context.numTable <= Restaurant.Tables.Count / 2)
            {
                ThreadPool.QueueUserWorkItem(Restaurant.CR1.installerClient, context.numTable);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(Restaurant.CR2.installerClient, context.numTable);
            }
        }
    }
}
