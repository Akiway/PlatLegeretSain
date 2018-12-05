using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    public interface IEtatCommande
    {
        void Splite(ChefCuisine context, Commande commande);
    }
}
