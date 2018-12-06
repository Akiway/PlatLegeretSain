using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatLegeretSain.Model
{
    sealed class MaitreHotel : Employe
    {
        // Singleton
        private static MaitreHotel MH = null;
        public static MaitreHotel Instance()
        {
            if (MH == null)
                MH = new MaitreHotel();
            return MH;
        }

        private MaitreHotel()
        {
            this.X = 1220;
            this.Y = 770;
            this.img = "Mh_";
            this.orientation = "front";
        }

        public ITableLibre ITableDisponible
        {
            get => default(ITableLibre);
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

        public MaitreHotel MaitreHotel1
        {
            get => default(MaitreHotel);
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
            Restaurant.CR1.MoveLeft(100);
            Restaurant.CR1.MoveDown(340);
            Restaurant.CR1.MoveRight(100);
        }

        public void setState(ITableLibre iTableDisponible)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Change le State en TableDisponible
        /// </summary>
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