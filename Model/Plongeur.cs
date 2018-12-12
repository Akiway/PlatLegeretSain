using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Plongeur : Employe
    {
        public Plongeur()
        {
            this.img = "Plongeur_";
        }

        public void nettoyer()
        {
            throw new System.NotImplementedException();
        }

        public void lancerLaveVaisselle()
        {
            throw new System.NotImplementedException();
        }

        public void lancerLaveLinge()
        {
            throw new System.NotImplementedException();
        }
    }
}