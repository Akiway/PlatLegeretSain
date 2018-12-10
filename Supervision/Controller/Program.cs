using System;

namespace Supervision.Controller
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static PlatLegeretSain.Model.Statistique stats;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Model.SocketClient();
    
            using (View.Game1 game = new View.Game1())
                game.Run();
        }
    }
}
