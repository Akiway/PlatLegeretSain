using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Recette
    {
        public Recette(int nbPersonne, int tempsPreparation, int tempsRepos, int tempsCuisson, List<Ingredient> ingredients)
        {
            this.nbPersonne = nbPersonne;
            this.tempsPreparation = tempsPreparation;
            this.tempsRepos = tempsRepos;
            this.tempsCuisson = tempsCuisson;
            this.ingredients = ingredients;
        }

        public List<Ingredient> ingredients;

        public int tempsCuisson;

        public int tempsRepos;

        public int tempsPreparation;

        public int nbPersonne;
    }
}