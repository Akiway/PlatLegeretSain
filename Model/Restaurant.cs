using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class Restaurant
    {
        public static MaitreHotel MH;
        public static List<Employe> Employes = new List<Employe>();

        public Restaurant()
        {
            MH = new MaitreHotel();
            Employes.Add(MH);

        }
    }
}
