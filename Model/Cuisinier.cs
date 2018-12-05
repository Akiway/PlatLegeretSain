using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    public class Cuisinier : Employe
    {
        public Cuisinier()
        {
            throw new System.NotImplementedException();
        }

        public List<Repas> repas
        {
            get => default(List<Repas>);
            set
            {
            }
        }

        public void cuisiner()
        {
            throw new System.NotImplementedException();
        }
    }
}