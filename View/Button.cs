using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatLegeretSain.View
{
    class Button
    {
        private MouseState _currentMouse;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouse;
        private Texture2D _texture;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        public event EventHandler Click;
        public bool Clicked { get; private set; }

        public Rectangle Rectangle => new Rectangle(X, Y, Width, Height);

        public Button(int x, int y, int width, int height, string text, SpriteFont font, Texture2D texture)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Text = text;
            this._font = font;
            this._texture = texture;
        }


        public void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.Red;
            Mouse.SetCursor(MouseCursor.Arrow);

            if (_isHovering)
            {
                color = Color.DarkRed;
                Mouse.SetCursor(MouseCursor.Hand);
            }

            spriteBatch.Draw(_texture, Rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), Color.White);
            }
        }
    }
}
