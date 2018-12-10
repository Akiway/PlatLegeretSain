using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatLegeretSain.View;
using System;

namespace Supervision.View
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteRender spriteRender;
        SpriteSheet spriteSheet;
        SpriteSheetLoader loader;
        SpriteFont spriteFont, spriteFontClock;
        Texture2D logoStats;
        PlatLegeretSain.Model.Statistique stats;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

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

            logoStats = Content.Load<Texture2D>("stats");

            spriteFont = Content.Load<SpriteFont>("ArialNormal");
            spriteFontClock = Content.Load<SpriteFont>("Digital");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            stats = Controller.Program.stats;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(60, 60, 60));

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // Affichage des stats
            spriteBatch.DrawString(spriteFontClock,
                (stats.timeMinutes + 10) + ":" + (stats.timeSeconds < 10 ? "0" : null) + stats.timeSeconds,
                new Vector2(70, 20), Color.White);
            spriteBatch.Draw(logoStats, new Rectangle(20, 15, 50, 50), Color.White);
            spriteBatch.Draw(logoStats, new Rectangle(graphics.PreferredBackBufferWidth - 250, graphics.PreferredBackBufferHeight - 250, 250, 250), Color.White);

            DrawText("Threads : " + (stats.maxThreads - stats.availableThreads), 100, 100);
            DrawText("Clients dans le restaurant : " + stats.nbClient, 100, 130);
            DrawText("a table : " + stats.nbClientATable, 160, 160);
            DrawText("lisant la carte : " + stats.nbClientCarte, 160, 190);
            DrawText("dans le carre 1 : " + stats.nbClientCarre1, 160, 220);
            DrawText("dans le carre 2 : " + stats.nbClientCarre2, 160, 250);
            DrawText("Tables libres : " + stats.nbTableLibre, 100, 280);
            DrawText("Vitesse : x" + stats.vitesseSimulation, 350, 100);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void DrawImage(string image, int x, int y) => spriteRender.Draw(spriteSheet.Sprite(image), new Vector2(x, y));

        public void DrawText(string text, int x, int y) => spriteBatch.DrawString(spriteFont, text, new Vector2(x, y), Color.White);
        
        public static void Print(string text) => Console.WriteLine(text);
    }
}
