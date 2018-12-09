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
        private List<Repas> CookNowAnticipation = new List<Repas>();
        private List<Repas> CookLater = new List<Repas>();

        public ChefCuisine()
        {

        }

        public void NewCommande(List<Commande> commandes)
        {
            foreach (Commande element in commandes)
            {
                if (element.entree != "")
                {
                    CookNow.Add(Database.Instance().GetRecette(element.entree, element.numTable));
                    if (element.plat != "")
                    {
                        Repas repas = Database.Instance().GetRecette(element.plat, element.numTable);
                        if (repas.recette.tempsCuisson <= 30)
                        {
                            CookLater.Add(repas);
                        }
                        else
                        {
                            CookNowAnticipation.Add(repas);
                        }
                    }
                    else if (element.dessert != "")
                    {
                        CookLater.Add(Database.Instance().GetRecette(element.dessert, element.numTable));
                    }
                }
                else if (element.plat != null)
                {
                    CookNow.Add(Database.Instance().GetRecette(element.plat, element.numTable));
                    if (element.dessert != "")
                    {
                        CookLater.Add(Database.Instance().GetRecette(element.dessert, element.numTable));
                    }
                }
                else
                {
                    CookNow.Add(Database.Instance().GetRecette(element.dessert, element.numTable));
                }
            }
            //ManageOrder();
        }

        public void ManageOrder()
        {
            List<Repas> listUrgent = new List<Repas>();
            List<Repas> listAnticipation = new List<Repas>();

            if (Restaurant.C1.Occuped == false)
            {
                foreach (Repas element in CookNow)
                {
                    if (element.numTable == CookNow[0].numTable)
                    {
                        listUrgent.Add(element);
                        CookNow.Remove(element);
                    }
                }
            }
            if (Restaurant.C2.Occuped == false)
            {
                foreach (Repas element in CookNowAnticipation)
                {
                    if (element.numTable == CookNowAnticipation[0].numTable)
                    {
                        listUrgent.Add(element);
                        CookNow.Remove(element);
                    }
                }
            }
        }
    }
}