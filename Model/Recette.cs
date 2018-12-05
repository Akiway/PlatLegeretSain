using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Recette
    {
        public Recette()
        {
            throw new System.NotImplementedException();
        }

        public List<Ingredient> ingredients
        {
            get => default(List<Ingredient>);
            set
            {
            }
        }

        private int tempsCuisson
        {
            get => default(int);
            set
            {
            }
        }

        private int tempsRepos
        {
            get => default(int);
            set
            {
            }
        }

        private int tempsPreparation
        {
            get => default(int);
            set
            {
            }
        }

        private int nbPersonne
        {
            get => default(int);
            set
            {
            }
        }
    }
}