using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Nyancat = PlatLegeretSain.Model.Nyancat;
using Microsoft.Xna.Framework.Media;
using System;

namespace PlatLegeretSain.Controller
{
    class Key
    {
        private static KeyboardState keyboard;
        private static KeyboardState oldKeyboard;

        public static void CheckKeyboard()
        {
            View.Game1 game = View.Game1.Instance();
            oldKeyboard = keyboard;
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

            if (oldKeyboard.IsKeyDown(Keys.Tab) && keyboard.IsKeyUp(Keys.Tab))
            {
                if (Model.Clock.Speed < 2)
                {
                    Model.Clock.Speed += 0.5;
                }
                else
                {
                    Model.Clock.Speed = 0.5;
                }
            }

            if (keyboard.IsKeyDown(Keys.Z))
            {
                Nyancat.Instance().MoveUp(2);
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                Nyancat.Instance().MoveDown(2);
            }

            if (keyboard.IsKeyDown(Keys.Q))
            {
                Nyancat.Instance().MoveLeft(2);
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                Nyancat.Instance().MoveRight(2);
            }
            

            if ((oldKeyboard.IsKeyUp(Keys.Z) && oldKeyboard.IsKeyUp(Keys.Q) && oldKeyboard.IsKeyUp(Keys.S) && oldKeyboard.IsKeyUp(Keys.D)) && (keyboard.IsKeyDown(Keys.Z) || keyboard.IsKeyDown(Keys.Q) || keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.D)))
            {
                MediaPlayer.Play(View.Game1.Nyancat);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.3f;
            }

            if ((oldKeyboard.IsKeyDown(Keys.Z) || oldKeyboard.IsKeyDown(Keys.Q) || oldKeyboard.IsKeyDown(Keys.S) || oldKeyboard.IsKeyDown(Keys.D)) && (keyboard.IsKeyUp(Keys.Z) && keyboard.IsKeyUp(Keys.Q) && keyboard.IsKeyUp(Keys.S) && keyboard.IsKeyUp(Keys.D)))
            {
                MediaPlayer.Play(View.Game1.Musique);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }
        }
    }
}
