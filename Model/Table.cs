using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Table
    {
        public Table(int numero, int rang, int carre, int nbPlace, int x, int y, bool orientation, bool etat)
        {
            this.Numero = numero;
            this.Rang = rang;
            this.Carre = carre;
            this.NbPlace = nbPlace;
            this.X = x;
            this.Y = y;
            this.OrientationHorizontale = orientation;
            this.Etat = etat;
        }

        public int Carre { get; set; }
        public int Rang { get; set; }
        public int NbPlace { get; set; }
        public int Numero { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool OrientationHorizontale { get; set; }
        public bool Etat { get; set; }

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