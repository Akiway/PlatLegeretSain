using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlatLegeretSain.Model
{
    public class CommisSalle : Employe
    {
        public static Semaphore CommisSallePool;

        public CommisSalle()
        {
            CommisSallePool = new Semaphore(1, 1);
            this.img = "CommisSalle_";
        }

        public void BringBread(int numTable)
        {
            MoveToTable(numTable);
            Console.WriteLine(this.X);
            // Apporter le pain et l'eau à la table numTable
            if (Restaurant.Tables.Find(x => x.Numero.Equals(numTable)).NbPlace > 6)
            {
                Restaurant.console.nbBouteilleEau -= 2;
                Restaurant.console.nbCorbeillePain -= 2;
            }
            else
            {
                Restaurant.console.nbBouteilleEau -= 1;
                Restaurant.console.nbCorbeillePain -= 1;
            }
            Restaurant.Tables.Find(x => x.Numero.Equals(numTable)).ImgState = "_pain";
            // Wait at the table 1 sec
            Thread.Sleep(1000);
            MoveToOrigin();
        }
    }
}