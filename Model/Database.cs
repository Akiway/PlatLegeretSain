using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        private Database()
        {
            this.Serveur = "localhost\\SQLEXPRESS01";
            this.DatabaseName = "ProjetPLS";

            string connetionString = "Data Source=" + this.Serveur + ";Initial Catalog=" + this.DatabaseName + ";Integrated Security=true";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                View.Game1.Print("Connexion à la base de donnée réussie");
                //connection.Close();
            }
            catch (Exception ex)
            {
                View.Game1.Print(ex.Message);
                View.Game1.Print("Connexion à la base de donnée échouée !");
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

        public void ReserverTable(int table)
        {

        }

        public List<Table> GetTables()
        {
            List<Table> tables = new List<Table>();
            command = new SqlCommand("SELECT * FROM [Emplacement]");
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tables.Add(new Table(reader.GetInt32(0), reader.GetInt32(2), reader.GetInt32(4), reader.GetInt32(1), reader.GetInt32(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetBoolean(3)));
            }
            reader.Close();

            return tables;
        }

        public void GetRecettes()
        {
            command = new SqlCommand("SELECT [Titre_Recette] FROM[ProjetPLS].[dbo].[Recette] WHERE[Categorie] = 'entree'");
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Restaurant.listEntrees.Add(reader.GetString(0));
            }
            reader.Close();

            command = new SqlCommand("SELECT [Titre_Recette] FROM[ProjetPLS].[dbo].[Recette] WHERE[Categorie] = 'plat'");
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Restaurant.listPlats.Add(reader.GetString(0));
            }
            reader.Close();

            command = new SqlCommand("SELECT [Titre_Recette] FROM[ProjetPLS].[dbo].[Recette] WHERE[Categorie] = 'dessert'");
            command.Connection = connection;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Restaurant.listDesserts.Add(reader.GetString(0));
            }
            reader.Close();
        }
    }
}