using System;

namespace PlatLegeretSain.Controller
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Model.Statistique stats;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Reset Logs
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("../../../../Logs.txt", false))
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
