using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Cuisinier : Employe
    {
        public Cuisinier()
        {
            this.Occuped = false;
        }

        public bool Occuped;
        public List<Repas> repas;

        public void Cuisiner(List<Repas> repas)
        {
            foreach(Repas element in repas)
            {
                element.EnChauffe(this);
                // Supprimer ingredients des recettes de la BDD
            }
        }

        public void DishReady(Repas repas)
        {
            // Appeler commis de cuisine
        }
    }
}