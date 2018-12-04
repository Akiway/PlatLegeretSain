using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain
{
    public class MaitreHotel : Employe
    {
        public MaitreHotel()
        {
            throw new System.NotImplementedException();
        }

        public ITableDisponible ITableDisponible
        {
            get => default(ITableDisponible);
            set
            {
            }
        }

        public int table
        {
            get => default(int);
            set
            {
            }
        }

        public Table attribuerTable()
        {
            throw new System.NotImplementedException();
        }

        public void appelerChefRang()
        {
            throw new System.NotImplementedException();
        }

        public void setState(ITableDisponible iTableDisponible)
        {
            throw new System.NotImplementedException();
        }

        public void PlaceLibere()
        {
            throw new System.NotImplementedException();
        }

        public void PasPlace()
        {
            throw new System.NotImplementedException();
        }
    }
}