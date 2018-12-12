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
            this.img = "Cc_";
        }

        public void NewCommande(object args)
        {
            List<Commande> commandes = (List<Commande>)args;
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
            ManageOrder();
        }

        public void ManageOrder()
        {
            List<Repas> listUrgent = new List<Repas>();
            List<Repas> listAnticipation = new List<Repas>();

            if (Restaurant.C1.Occuped == false && CookNow != null)
            {
                foreach (Repas element in CookNow)
                {
                    int numTableCookNow = CookNow[0].numTable;
                    if (element.numTable == numTableCookNow)
                    {
                        listUrgent.Add(element); 
                    }
                }
                foreach(Repas element in listUrgent)
                {
                    CookNow.Remove(element);
                }
            }

            if (Restaurant.C2.Occuped == false && CookNowAnticipation != null)
            {
                foreach (Repas element in CookNowAnticipation)
                {
                    int numTaleCookNowAnticipation = CookNowAnticipation[0].numTable;
                    if (element.numTable == numTaleCookNowAnticipation)
                    {
                        listAnticipation.Add(element);
                    }
                }
                foreach(Repas element in listAnticipation)
                {
                    CookNowAnticipation.Remove(element);
                }
            }

            Restaurant.C1.Cuisiner(listUrgent);
            Restaurant.C2.Cuisiner(listAnticipation);
        }
    }
}