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
            this.etatTable = new TableDisponible();
        }

        public int table { get; set; }
        private IFreeTable etatTable { get; set; }

        public MaitreHotel MaitreHotel1 { get; set; }

        public void AccueillirClient(int numReservation, List<Client> clients)
        {
            etatTable.AccueillirClient(this.etatTable, numReservation, clients);
        }

        public void appelerChefRang()
        {
            Restaurant.CR1.MoveLeft(100);
            Restaurant.CR1.MoveDown(340);
            Restaurant.CR1.MoveRight(100);
        }

        public void setState(IFreeTable newEtat)
        {
            this.etatTable = newEtat;
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