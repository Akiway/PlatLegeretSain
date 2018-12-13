using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class Cuisinier : Employe
    {
        public Cuisinier(String name)
        {
            this.name = name;
            this.img = "Cuisinier_";
        }

        public String name;
        public List<Repas> listMtn = new List<Repas>();
        public List<Repas> listApres = new List<Repas>();

        public void Cuisiner(List<Repas> repas)
        {
            foreach(Repas element in repas)
            {
                if(this.name == "C1")
                {
                    // S'il y a des entrees dans la liste
                    if(repas.FindAll(x => x.type.Equals("entree")).Count != 0)
                    {
                        if (element.type == "entree")
                        {
                            listMtn.Add(element);
                        }
                        else
                        {
                            listApres.Add(element);
                        }
                    }
                    else
                    {
                        listMtn.Add(element);
                    }
                }
                else
                {
                    listApres.Add(element);
                }
                ThreadPool.QueueUserWorkItem(element.Conception, this);
                View.Game1.Print("Conception du repas : "+element.nom);
            }
        }

        public void DishReady(Repas repas)
        {
            if (this.name == "C1")
            {
                if(listMtn.FindAll(x => x.Equals(repas)).Count != 0)
                {
                    // Ajouter animation déplacement du commisCuisine
                    Restaurant.commisCuisine.EmmenerPlatComptoir(repas);
                    View.Game1.Print("Le commis de cuisine met un plat sur le comptoir");
                    View.Game1.Print("la : " + listMtn.FindAll(x => x.ready.Equals(true)).Count);
                    View.Game1.Print("ici : " + listMtn.Count);

                    if (listMtn.FindAll(x => x.ready.Equals(true)).Count == listMtn.Count)
                    {
                        Restaurant.commisCuisine.callWaiter(repas.numTable);
                    }
                }
                else
                {
                    Restaurant.commisCuisine.EmmenerPlatEtuve(repas);
                }
            }
            else
            {
                Restaurant.commisCuisine.EmmenerPlatEtuve(repas);
            }
        }
    }
}