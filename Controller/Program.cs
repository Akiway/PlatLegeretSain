using System;

namespace PlatLegeretSain.Controller
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Model.Statistique stats;
        public static string logFile;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create new logs
            string date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + "H" + DateTime.Now.Minute + "M" + DateTime.Now.Second;
            logFile = "../../../../logs/" + date + ".txt";
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(logFile, false))
            {
                file.WriteLine("--- Simulation du " + DateTime.Now);
            }

            //Load parameters
            //Model.Parameters.Instance();

            // Create the main clock
            Model.Clock.Instance();
            // Instanciate new stats used for both main application and supervision
            stats = new Model.Statistique();
            // Start the socket server
            Model.SocketServer.Instance();

            // Start the simulation
            Model.Restaurant resto = Model.Restaurant.Instance();
            var game = View.Game1.Instance();
            using (game)
            {
                game.Run();
            }

            // Activate simulation controls
            Controller.Key keyController = new Controller.Key();
        }
    }
}
