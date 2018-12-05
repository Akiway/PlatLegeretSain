using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class StarterWithoutDish:IEtatCommande
    {
        public void Splite(ChefCuisine context, Commande commande)
        {
            context.AddCookNow(commande.Entree);
        }
    }
}
