using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Cuisinier : Employe
    {
        public Cuisinier(String name)
        {
            this.Occuped = false;
            this.name = name;
        }

        public bool Occuped;
        public String name;
        public List<Repas> listRepas = new List<Repas>();

        public void Cuisiner(List<Repas> repas)
        {
            this.Occuped = true;
            foreach(Repas element in repas)
            {
                element.EnChauffe(this);
                this.listRepas.Add(element);
                View.Game1.Print("EnChauffe");
                // Supprimer ingredients des recettes de la BDD
            }
        }

        public void DishReady(Repas repas)
        {
            Restaurant.commisCuisine.EmmenerPlatComptoir(repas);

            View.Game1.Print("--------------------- Cuisinier ----------------------");
            View.Game1.Print(repas.nom);
            View.Game1.Print(listRepas.Count.ToString());
            if(listRepas.FindAll(x => x.ready.Equals(true)).Count == listRepas.Count)
            {
                Restaurant.commisCuisine.callWaiter();
                View.Game1.Print("All");
            }
            this.Occuped = false;
            View.Game1.Print("--------------------- FinCuisinier -------------------");
        }
    }
}