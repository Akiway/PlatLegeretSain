using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    sealed class Database
    {
        // Singleton
        private static Database db = null;
        public static Database Instance()
        {
            if (db == null)
                db = new Database();
            return db;
        }

        private Database()
        {
            throw new System.NotImplementedException();
        }

        public string Serveur
        {
            get => default(string);
            set
            {
            }
        }

        public string DatabaseName
        {
            get => default(string);
            set
            {
            }
        }

        public string Login
        {
            get => default(string);
            set
            {
            }
        }

        public string Password
        {
            get => default(string);
            set
            {
            }
        }

        public List<Ingredient> RecupererIngredientRecette()
        {
            throw new System.NotImplementedException();
        }

        public Table TableLibre()
        {
            throw new System.NotImplementedException();
        }

        public void StatutTable()
        {
            throw new System.NotImplementedException();
        }
    }
}