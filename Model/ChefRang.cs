using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class ChefRang : Employe, IObservateur
    {
        private int Carre { get; set; }

        public ChefRang(int carre, int x = 1130, int y = 500)
        {
            this.Carre = carre;
            this.X = x;
            this.Y = y;
            this.img = "Cr_";
            this.orientation = "left";
        }

        public List<Commande> commandes
        {
            get => default(List<Commande>);
            set
            {
            }
        }

        public void installerClient(int numTable)
        {
            int nbClient = Restaurant.Clients.FindAll(x => x.numTable.Equals(numTable)).Count;
            View.Game1.Print("Je place "+nbClient+" client à la table numéro : "+numTable);
        }

        public void donnerCarte()
        {
            throw new System.NotImplementedException();
        }

        public void prendreCommande()
        {
            throw new System.NotImplementedException();
        }

        public void notifier()
        {
            throw new System.NotImplementedException();
        }
    }
}