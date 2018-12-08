using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    class Nyancat : Employe
    {
        // Singleton
        private static Nyancat nyancat = null;
        public static Nyancat Instance()
        {
            if (nyancat == null)
                nyancat = new Nyancat();
            return nyancat;
        }

        private Nyancat()
        {
            this.X = -50;
            this.Y = 500;
            this.img = "Nyancat_";
            this.orientation = "front";
        }
    }
}
