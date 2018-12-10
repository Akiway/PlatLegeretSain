using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlatLegeretSain.Model
{
    // No Singleton possible !
    [Serializable()]
    public class Statistique
    {
        public int timeHours { get; set; }
        public int timeMinutes { get; set; }
        public int timeSeconds { get; set; }
        public int timeTotalSecondes { get; set; }
        public int nbClient { get; set; }
        public int nbClientATable { get; set; }
        public int nbClientCarte { get; set; }
        public int nbGroupe { get; set; }
        public int nbTableLibre { get; set; }
        public int nbClientCarre1 { get; set; }
        public int nbClientCarre2 { get; set; }
        public double vitesseSimulation { get; set; }
        public string statutSimulation { get; set; }
        public int availableThreads { get; set; }
        public int maxThreads { get; set; }
        private int io;

        public Statistique()
        {
        }

        public void Update(GameTime gameTime)
        {
            timeHours = Clock.Hours;
            timeMinutes = Clock.Minutes;
            timeSeconds = Clock.Seconds;
            timeTotalSecondes = Clock.TotalSeconds;
            nbClient = Restaurant.Clients.Count;
            nbClientATable = Restaurant.Clients.FindAll(x => x.imgEtat != "").Count;
            nbClientCarte = Restaurant.Clients.FindAll(x => x.imgEtat == "carte_").Count;
            nbClientCarre1 = nbClientCarre2 = 0;
            for (int i=0; i<Restaurant.Clients.Count; i++)
            {
                Client client = Restaurant.Clients[i];
                if (client.numTable != 0)
                {
                    if (Restaurant.Tables.Find(x => x.Numero == client.numTable).Carre == 1)
                    {
                        nbClientCarre1++;
                    }
                    else if (Restaurant.Tables.Find(x => x.Numero == client.numTable).Carre == 2)
                    {
                        nbClientCarre2++;
                    }
                }
            }
            nbTableLibre = Restaurant.Tables.FindAll(x => x.Disponible == true).Count;
            vitesseSimulation = Clock.Speed;
            statutSimulation = "Running";
            int outAvailableThreads, outMaxThreads, outIo;
            ThreadPool.GetAvailableThreads(out outAvailableThreads, out outIo);
            ThreadPool.GetMaxThreads(out outMaxThreads, out outIo);
            availableThreads = outAvailableThreads;
            maxThreads = outMaxThreads;
            io = outIo;
        }
    }
}
