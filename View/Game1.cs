using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TexturePackerMonoGameDefinitions;

namespace PlatLegeretSain.View
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    sealed class Game1 : Game
    {
        // Singleton
        private static Game1 game = null;
        public static Game1 Instance()
        {
            if (game == null)
                game = new Game1();
            return game;
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteRender spriteRender;
        SpriteSheet spriteSheet;
        SpriteSheetLoader loader;
        SpriteFont spriteFont;
        GameTime GT;

        public GameTime GetGameTime() => GT;

        public void SetGameTime(GameTime gt) => GT = gt;

        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1000;
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteRender = new SpriteRender(this.spriteBatch);
            loader = new SpriteSheetLoader(Content, GraphicsDevice);
            spriteSheet = loader.Load("PLSsprites.png");

            spriteFont = Content.Load<SpriteFont>("ArialNormal");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Controller.Key.CheckKeyboard();
            Model.Restaurant.Time = (gameTime.TotalGameTime.Minutes+10) + ":" + gameTime.TotalGameTime.Seconds;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            DrawImage(PLSsprites.Restaurant, 0, 0);

            foreach(Model.Employe employe in Model.Restaurant.Employes)
            {
                DrawImage(employe.img + employe.orientation, employe.X, employe.Y);
            }

            foreach(Model.Client client in Model.Restaurant.Clients)
            {
                DrawImage(client.img + client.orientation, client.X, client.Y);
            }

            if (gameTime.TotalGameTime.TotalSeconds % 2 != 0) // Affiche une fois sur 2
                //Print(Model.Restaurant.Clients.Count.ToString());


            DrawText(Math.Round(gameTime.TotalGameTime.TotalMinutes+10) + "h" + Math.Round(gameTime.TotalGameTime.TotalSeconds), 0, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawImage(string image, int x, int y)
        {
            spriteRender.Draw(spriteSheet.Sprite(image), new Vector2(x, y));
        }

        public void DrawText(string text, int x, int y)
        {
            spriteBatch.DrawString(spriteFont, text, new Vector2(x, y), Color.Black);
        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
