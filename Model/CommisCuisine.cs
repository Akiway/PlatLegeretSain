using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class CommisCuisine : Employe
    {
        public CommisCuisine()
        {
            
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
            View.Game1.Print("Emmener plat comptoir ! ");
        }

        public void EmmenerPlatEtuve(Repas repas)
        {
            View.Game1.Print("Emmener plat étuve ! ");
        }

        public void callWaiter(int numTable)
        {
            // Appeler le serveur
            View.Game1.Print("Commis de cuisine > callWaiter !");
            // Choix du serveur
            if (numTable <= Restaurant.Tables.Count / 2)
            {
                if (Restaurant.Serveur1.Occuped == false)
                {
                    Restaurant.Serveur1.BringDish(numTable);
                }
                else if (Restaurant.Serveur2.Occuped == false)
                {
                    Restaurant.Serveur2.BringDish(numTable);
                }
                else
                {
                    // Thread 5 min
                }
            }
            else
            {
                if (Restaurant.Serveur3.Occuped == false)
                {
                    Restaurant.Serveur3.BringDish(numTable);
                }
                else if (Restaurant.Serveur4.Occuped == false)
                {
                    Restaurant.Serveur4.BringDish(numTable);
                }
                else
                {
                    // Thread 5 min
                }
            }
        }
    }
}