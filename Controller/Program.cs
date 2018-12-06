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
            Model.Restaurant resto = Model.Restaurant.Instance();
            var game = View.Game1.Instance();
            using (game)
            {
                game.Run();
            }

            Controller.Key keyController = new Controller.Key();
        }
    }
}
