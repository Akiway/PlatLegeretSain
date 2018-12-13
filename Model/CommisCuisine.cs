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

        public void EmmenerPlatComptoir(Repas repas)
        {
            // Animation déplacement à l'étuve
            MoveToEtuve();
            Restaurant.CPC.NewDishReady(repas);
            // Animation déplacement au comptoir
            MoveToComptoir();
        }

        public void EmmenerPlatEtuve(Repas repas)
        {
            // Animation déplacement à l'étuve
            MoveToEtuve(false);
            Restaurant.tableChaude.NewDishWaiting(repas);
            View.Game1.Print("Emmener plat étuve ! " + repas.nom);
        }

        public void callWaiter(int numTable)
        {
            View.Game1.Print("Le commis de cuisine appel le serveur.");
            // Choix du serveur
            List<Serveur> Serveurs;

            if (numTable <= Restaurant.Tables.Count / 2)
            {
                Serveurs = Restaurant.Serveurs.FindAll(x => x.Carre == 1);
                disponibiliteServeurCarre1.WaitOne();
                Serveur serveur = Serveurs.Find(x => x.Occuped == false);
                serveur.BringDish(numTable);
                disponibiliteServeurCarre1.Release();
            }
            else
            {
                Serveurs = Restaurant.Serveurs.FindAll(x => x.Carre == 2);
                disponibiliteServeurCarre2.WaitOne();
                Serveur serveur = Serveurs.Find(x => x.Occuped == false);
                serveur.BringDish(numTable);
                disponibiliteServeurCarre2.Release();
            }
        }
    }
}