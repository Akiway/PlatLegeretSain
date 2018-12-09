using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    sealed class ChefCuisine : Employe
    {
        // Singleton
        private static ChefCuisine CC = null;
        public static ChefCuisine Instance()
        {
            if (CC == null)
                CC = new ChefCuisine();
            return CC;
        }

        private List<Repas> CookNow = new List<Repas>();
        private List<Repas> CookLater = new List<Repas>();

        public ChefCuisine()
        {
            //throw new System.NotImplementedException();
        }

        public void NewCommande(List<Commande> commandes)
        {
            foreach (Commande element in commandes)
            {
                if (element.entree != "")
                {
                    AddCookNow(Database.Instance().GetRecette(element.entree));
                    if (element.plat != "")
                    {
                        Repas repas = Database.Instance().GetRecette(element.plat);
                        if (repas.recette.tempsCuisson <= 30)
                        {
                            AddCookLater(repas);
                        }
                        else
                        {
                            AddCookNow(repas);
                        }
                    }
                    else if (element.dessert != "")
                    {
                        AddCookLater(Database.Instance().GetRecette(element.dessert));
                    }
                }
                else if (element.plat != null)
                {
                    AddCookNow(Database.Instance().GetRecette(element.plat));
                    if (element.dessert != "")
                    {
                        AddCookLater(Database.Instance().GetRecette(element.dessert));
                    }
                }
                else
                {
                    AddCookNow(Database.Instance().GetRecette(element.dessert));
                }
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
    }
}