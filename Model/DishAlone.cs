using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class DishAlone:IEtatCommande
    {
        public void Splite(ChefCuisine context, Commande commande)
        {
            context.AddCookLater(commande.Plat);
        }
    }
}
