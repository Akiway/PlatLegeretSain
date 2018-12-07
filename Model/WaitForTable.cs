using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class WaitForTable : IClientState
    {
        public void ManageClient(Client context)
        {
            Restaurant.CR1.installerClient(context.numTable);
        }
    }
}
