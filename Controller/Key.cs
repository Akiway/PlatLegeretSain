using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MH = PlatLegeretSain.Model.MaitreHotel;

namespace PlatLegeretSain.Controller
{
    class Key
    {

        public static void CheckKeyboard()
        {
            View.Game1 game = View.Game1.Instance();
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

            if (keyboard.IsKeyDown(Keys.Z))
            {
                MH.Instance().MoveUp(2);
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                MH.Instance().MoveDown(2);
            }

            if (keyboard.IsKeyDown(Keys.Q))
            {
                MH.Instance().MoveLeft(2);
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                MH.Instance().MoveRight(2);
            }
        }
    }
}
