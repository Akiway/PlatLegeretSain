using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class ChefCuisine : Employe
    {
        private IEtatCommande etatCommande;
        private List<Repas> CookNow;
        private List<Repas> CookLater;

        public ChefCuisine()
        {
            //throw new System.NotImplementedException();
        }

        public void NewCommande(List<Commande> commandes)
        {
            foreach(Commande element in commandes)
            {
                if(element.Entree != null)
                {
                    if(element.Plat != null)
                    {
                        this.etatCommande = new StarterAndDish();
                    }
                    else
                    {
                        this.etatCommande = new StarterWithoutDish();
                    }
                }
                else
                {
                    if(element.Plat != null)
                    {
                        this.etatCommande = new DishAlone();
                    }
                }
                Splite(element);
            }
        }

        public void AddCookNow(Repas repas)
        {
            CookNow.Add(repas);
        }

        public void AddCookLater(Repas repas)
        {
            CookLater.Add(repas);
        }

        public void Splite(Commande commande)
        {
            etatCommande.Splite(this, commande);
        }
    }
}