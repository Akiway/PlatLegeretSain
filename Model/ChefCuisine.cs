using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class ChefCuisine : Employe
    {
        private List<Repas> CookNow;
        private List<Repas> CookLater;

        public ChefCuisine()
        {
            //throw new System.NotImplementedException();
        }

        public void NewCommande(List<Commande> commandes)
        {

        }

        public void AddCookNow(Repas repas)
        {
            CookNow.Add(repas);
        }

        public void AddCookLater(Repas repas)
        {
            CookLater.Add(repas);
        }
    }
}