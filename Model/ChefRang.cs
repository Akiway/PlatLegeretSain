using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class ChefRang : Employe, IObservateur
    {
        public ChefRang()
        {
            throw new System.NotImplementedException();
        }

        public List<Commande> commandes
        {
            get => default(List<Commande>);
            set
            {
            }
        }

        public void installerClient()
        {
            throw new System.NotImplementedException();
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