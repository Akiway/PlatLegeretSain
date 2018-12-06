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

        public string Serveur { get; set; }
        public string DatabaseName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private Database()
        {

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

        public void ReserverTable(int table)
        {

        }
    }
}