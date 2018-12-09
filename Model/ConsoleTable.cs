using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    sealed class ConsoleTable
    {
        // Singleton
        private static ConsoleTable console = null;
        public static ConsoleTable Instance()
        {
            if (console == null)
                console = new ConsoleTable();
            return console;
        }

        public ConsoleTable()
        {
            this.nbBouteilleEau = 40;
            this.nbCorbeillePain = 40;
        }

        public int nbBouteilleEau;
        public int nbCorbeillePain;
    }
}
