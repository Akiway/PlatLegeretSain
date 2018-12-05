using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Database
    {
        public Database()
        {
            throw new System.NotImplementedException();
        }

        public Database Database1
        {
            get => default(Database);
            set
            {
            }
        }

        public string serveur
        {
            get => default(string);
            set
            {
            }
        }

        public string database
        {
            get => default(string);
            set
            {
            }
        }

        public string login
        {
            get => default(string);
            set
            {
            }
        }

        public string password
        {
            get => default(string);
            set
            {
            }
        }

        public List<Ingredient> recupererIngredientRecette()
        {
            throw new System.NotImplementedException();
        }

        public Table tableLibre()
        {
            throw new System.NotImplementedException();
        }

        public void statutTable()
        {
            throw new System.NotImplementedException();
        }
    }
}