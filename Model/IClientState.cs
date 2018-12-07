using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public interface IClientState
    {
        void ManageClient(Client context);
    }
}