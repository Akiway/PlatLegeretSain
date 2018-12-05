using System;

namespace PlatLegeretSain.Controller
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Model.Restaurant resto = new Model.Restaurant();

            using (var game = new View.Game1())
            {
                game.Run();
            }
        }
    }
}
