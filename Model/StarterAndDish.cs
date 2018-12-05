using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class StarterAndDish:IEtatCommande
    {
        public void Splite(ChefCuisine context, Commande commande)
        {
            context.AddCookNow(commande.Entree);

            if(commande.Entree.Recette.tempsCuisson <= 30)
            {
                context.AddCookLater(commande.Plat);
            }
            else
            {
                context.AddCookNow(commande.Plat);
            }
        }
    }
}
