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
            this.X = 1230;
            this.Y = 780;
            this.img = "Mh_";
            this.Orientation = "front";
            this.etatTable = new TableDisponible();
        }

        public int table { get; set; }
        private IFreeTable etatTable { get; set; }

        public void AccueillirClient(int numReservation, List<Client> clients)
        {
            etatTable.AccueillirClient(this.etatTable, numReservation, clients);
        }

        public void setState(IFreeTable newEtat)
        {
            this.etatTable = newEtat;
        }
    }
}