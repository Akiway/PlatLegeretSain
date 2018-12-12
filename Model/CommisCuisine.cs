using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class CommisCuisine : Employe
    {
        public Semaphore disponibiliteServeurCarre1;
        public Semaphore disponibiliteServeurCarre2;

        public CommisCuisine()
        {
            disponibiliteServeurCarre1 = new Semaphore(2, 2);
            disponibiliteServeurCarre2 = new Semaphore(2, 2);
            this.img = "CommisCuisine_";
        }

        public void eplucher()
        {
            
        }

        public void chercher()
        {
            
        }

        public void EmmenerPlatComptoir(Repas repas)
        {
            Restaurant.CPC.NewDishReady(repas);
            View.Game1.Print("Emmener plat comptoir ! "+repas.nom);
        }

        public void EmmenerPlatEtuve(Repas repas)
        {
            Restaurant.tableChaude.NewDishWaiting(repas);
            View.Game1.Print("Emmener plat étuve ! " + repas.nom);
        }

        public void callWaiter(int numTable)
        {
            // Choix du serveur
            List<Serveur> Serveurs;
            if (numTable <= Restaurant.Tables.Count / 2)
            {
                Serveurs = Restaurant.Serveurs.FindAll(x => x.Carre == 1);
                disponibiliteServeurCarre1.WaitOne();
            }
            else
            {
                Serveurs = Restaurant.Serveurs.FindAll(x => x.Carre == 2);
                disponibiliteServeurCarre2.WaitOne();
            }

            foreach (Serveur serveur in Serveurs)
            {
                serveur.BringDish(numTable);
            }
            disponibiliteServeurCarre2.Release();
        }
    }
}