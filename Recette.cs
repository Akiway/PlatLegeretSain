using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain
{
    public class Recette
    {
        public Recette()
        {
            throw new System.NotImplementedException();
        }

        public List<PlatLegeretSain.Ingredient> ingredients
        {
            get => default(List<PlatLegeretSain.Ingredient>);
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