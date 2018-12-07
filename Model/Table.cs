using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Table
    {
        public Table(int nbPlace, int numero, String etat)
        {
            this.numero = numero;
            this.etat = etat;
            this.nbPlace = nbPlace;
        }

        private int carre { get; set; }

        private int rang { get; set; }

        public int nbPlace { get; set; }

        public int numero { get; set; }

        public string etat { get; set; }

        public bool DessertApres { get; set; }

        private List<Client> clients { get; set; }

        public void GererCommande()
        {
            List<Commande> commandes = new List<Commande>();

            List<String> listEntree = new List<string>(new String[] { "Soupe", "Salade", "Thon", "Saumon" });
            List<String> listPlat = new List<string>(new String[] { "Poulet", "Kebab", "Pizza", "Couscous" });
            List<String> listDessert = new List<string>(new String[] { "Creme", "The", "Cafe", "Tarte" });

            //int nbClient = Restaurant.Clients.FindAll(x => x.numTable.Equals(this.numero)).Count;
            int nbClient = 5;

            int vitesseManger = new Random().Next(1, 3);
            int UnDeuxFois = new Random().Next(1, 2);
            Random r = new Random();

            for (int x = 0; x < nbClient; x++)
            {
                List<String> listChoix = new List<string>(new String[]{"Entree","Plat","Dessert"});

                if (UnDeuxFois == 2)
                {
                    listChoix.Remove("Dessert");
                    vitesseManger -= 1;
                    this.DessertApres = true;
                }
                else
                {
                    this.DessertApres = false;
                }

                String entree = "", plat = "", dessert = "";

                for (int i = 0; i < vitesseManger; i++)
                {
                    View.Game1.Print("listChoix : "+listChoix.Count);
                    int index = r.Next(listChoix.Count);
                    string randomResult = listChoix[index];

                    switch (randomResult)
                    {
                        case "Entree":
                            entree = listEntree[r.Next(listEntree.Count)];
                            listChoix.Remove("Entree");
                            break;
                        case "Plat":
                            plat = listPlat[r.Next(listPlat.Count)];
                            listChoix.Remove("Plat");
                            break;
                        case "Dessert":
                            dessert = listDessert[r.Next(listDessert.Count)];
                            listChoix.Remove("Dessert");
                            break;
                    }   
                }
                //commandes.Add(new Commande(entree, plat, dessert));
                Restaurant.commandes.Add(new Commande(entree, plat, dessert));
            }
        }
    }
}