using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Nyancat = PlatLegeretSain.Model.Nyancat;
using Microsoft.Xna.Framework.Media;
using System;

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
                Nyancat.Instance().MoveUp(2);
                MediaPlayer.Play(View.Game1.Nyancat);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                Nyancat.Instance().MoveDown(2);
                MediaPlayer.Play(View.Game1.Nyancat);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }

            if (keyboard.IsKeyDown(Keys.Q))
            {
                Nyancat.Instance().MoveLeft(2);
                MediaPlayer.Play(View.Game1.Nyancat);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                Nyancat.Instance().MoveRight(2);
                MediaPlayer.Play(View.Game1.Nyancat);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }
            if (!keyboard.IsKeyDown(Keys.Z) && !keyboard.IsKeyDown(Keys.Q) && !keyboard.IsKeyDown(Keys.S) && !keyboard.IsKeyDown(Keys.D))
            {
                MediaPlayer.Play(View.Game1.Musique);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Volume = 0.5f;
            }
        }
    }
}
