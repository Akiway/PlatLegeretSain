using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain
{
    public class ChefCuisine : Employe
    {
        public ChefCuisine()
        {
            throw new System.NotImplementedException();
        }

        public List<Commande> commandes
        {
            get => default(List<Commande>);
            set
            {
            }
        }
    }
}