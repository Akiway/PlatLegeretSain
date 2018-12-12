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
            if (numTable <= Restaurant.Tables.Count / 2)
            {
                disponibiliteServeurCarre1.WaitOne();

                if (Restaurant.Serveur1.Occuped == false)
                {
                    Restaurant.Serveur1.BringDish(numTable);
                }
                else if (Restaurant.Serveur2.Occuped == false)
                {
                    Restaurant.Serveur2.BringDish(numTable);
                }
                disponibiliteServeurCarre1.Release();
            }
            else
            {
                disponibiliteServeurCarre2.WaitOne();
                if (Restaurant.Serveur3.Occuped == false)
                {
                    Restaurant.Serveur3.BringDish(numTable);
                }
                else if (Restaurant.Serveur4.Occuped == false)
                {
                    Restaurant.Serveur4.BringDish(numTable);
                }
                disponibiliteServeurCarre2.Release();
            }
        }
    }
}