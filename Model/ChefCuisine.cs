using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

        private List<Repas> EntreeEtPlatCourt = new List<Repas>();
        private List<Repas> PlatLongetDessert = new List<Repas>();
        public Semaphore semaphoreCuisinier1;
        public Semaphore semaphoreCuisinier2;

        public ChefCuisine()
        {
            this.img = "Cc_";
            semaphoreCuisinier1 = new Semaphore(1, 1);
            semaphoreCuisinier2 = new Semaphore(1, 1);
        }

        public void NewCommande(object args)
        {
            List<Commande> commandes = (List<Commande>)args;

            foreach (Commande element in commandes)
            {
                if (element.entree != "")
                {
                    EntreeEtPlatCourt.Add(Database.Instance().GetRecette(element.entree, element.numTable));
                }

                if (element.plat != "")
                {
                    Repas repas = Database.Instance().GetRecette(element.plat, element.numTable);
                    if (repas.recette.tempsCuisson <= 30)
                    {
                        EntreeEtPlatCourt.Add(repas);
                    }
                    else
                    {
                        PlatLongetDessert.Add(repas);
                    }
                }

                if (element.dessert != "")
                {
                    PlatLongetDessert.Add(Database.Instance().GetRecette(element.dessert, element.numTable));
                }

                ManageOrder();
            }
        }

        public void ManageOrder()
        {
            List<Repas> listEntreeEtPlatCourt = new List<Repas>();
            List<Repas> listPlatLongetDessert = new List<Repas>();

            if (EntreeEtPlatCourt != null)
            {
                foreach (Repas element in EntreeEtPlatCourt)
                {
                    int numTableEntreeEtPlatCourt = EntreeEtPlatCourt[0].numTable;
                    if (element.numTable == numTableEntreeEtPlatCourt)
                    {
                        listEntreeEtPlatCourt.Add(element);
                    }
                }
                foreach (Repas element in listEntreeEtPlatCourt)
                {
                    EntreeEtPlatCourt.Remove(element);
                }
            }

            if (PlatLongetDessert != null)
            {
                foreach (Repas element in PlatLongetDessert)
                {
                    int numTablePlatLongetDessert = PlatLongetDessert[0].numTable;
                    if (element.numTable == numTablePlatLongetDessert)
                    {
                        listPlatLongetDessert.Add(element);
                    }
                }
                foreach (Repas element in listPlatLongetDessert)
                {
                    PlatLongetDessert.Remove(element);
                }
            }

            semaphoreCuisinier1.WaitOne();
            Restaurant.C1.Cuisiner(listEntreeEtPlatCourt);
            semaphoreCuisinier1.Release();

            semaphoreCuisinier2.WaitOne();
            Restaurant.C2.Cuisiner(listPlatLongetDessert);
            semaphoreCuisinier2.Release();
        }
    }
}