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

            
            Model.Restaurant.Tables[0].GererCommande();
            View.Game1.Print("-------------------------------");
            View.Game1.Print("Commande 1 -> e : " + Model.Restaurant.commandes[0].e + " / p : " + Model.Restaurant.commandes[0].p + " / d :" + Model.Restaurant.commandes[0].d);
            View.Game1.Print("Commande 2 -> e : " + Model.Restaurant.commandes[1].e + " / p : " + Model.Restaurant.commandes[1].p + " / d :" + Model.Restaurant.commandes[1].d);
            View.Game1.Print("Commande 3 -> e : " + Model.Restaurant.commandes[2].e + " / p : " + Model.Restaurant.commandes[2].p + " / d :" + Model.Restaurant.commandes[2].d);
            View.Game1.Print("Commande 4 -> e : " + Model.Restaurant.commandes[3].e + " / p : " + Model.Restaurant.commandes[3].p + " / d :" + Model.Restaurant.commandes[3].d);
            View.Game1.Print("Commande 5 -> e : " + Model.Restaurant.commandes[4].e + " / p : " + Model.Restaurant.commandes[4].p + " / d :" + Model.Restaurant.commandes[4].d);
        }
    }
}
