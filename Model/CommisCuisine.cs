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
        }

        public void EmmenerPlatEtuve(Repas repas)
        {

        }

        public void callWaiter()
        {
            // Appeler le serveur
        }
    }
}