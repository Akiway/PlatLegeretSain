using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using TexturePackerMonoGameDefinitions;
using Clock = PlatLegeretSain.Model.Clock;

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
        SpriteFont spriteFont, spriteFontClock;
        int availableThreads, maxThreads, io;
        int nbClientATable, nbClientCarte, nbClientCarre1, nbClientCarre2, nbTableLibre;
        List<Button> Buttons;

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
            var buttonTexture = Content.Load<Texture2D>("button");

            spriteRender = new SpriteRender(this.spriteBatch);
            loader = new SpriteSheetLoader(Content, GraphicsDevice);
            spriteSheet = loader.Load("PLSsprites.png");

            spriteFont = Content.Load<SpriteFont>("ArialNormal");
            spriteFontClock = Content.Load<SpriteFont>("Digital");
            // TODO: use this.Content to load your game content here

            // Buttons of the interface
            Button speedBtn = new Button(1750, 755, 60, 40, "", spriteFont, buttonTexture);
            speedBtn.Click += Controller.Mousse.ChangeSpeed;

            Buttons = new List<Button>() { speedBtn };
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
            foreach (Button button in Buttons)
            {
                button.Update(gameTime);
            }

            ThreadPool.GetAvailableThreads(out availableThreads, out io);
            ThreadPool.GetMaxThreads(out maxThreads, out io);
            nbClientATable = Model.Restaurant.Clients.FindAll(x => x.imgEtat != "").Count;
            nbClientCarte = Model.Restaurant.Clients.FindAll(x => x.imgEtat == "carte_").Count;
            nbClientCarre1 = nbClientCarre2 = 0;
            foreach (Model.Client client in Model.Restaurant.Clients)
            {
                if (client.numTable != 0)
                {
                    if (Model.Restaurant.Tables.Find(x => x.Numero == client.numTable).Carre == 1)
                    {
                        nbClientCarre1++;
                    }
                    else if (Model.Restaurant.Tables.Find(x => x.Numero == client.numTable).Carre == 2)
                    {
                        nbClientCarre2++;
                    }
                }
            }
            nbTableLibre = Model.Restaurant.Tables.FindAll(x => x.Disponible == true).Count;

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


            // Affichage des employés
            foreach(Model.Employe employe in Model.Restaurant.Employes)
            {
                DrawImage(employe.img + employe.orientation, employe.X, employe.Y);
            }

            // Affichage des clients
            foreach(Model.Client client in Model.Restaurant.Clients)
            {
                DrawImage(client.img + client.imgEtat + client.orientation, client.X, client.Y);
            }

            // Affichage des stats
            spriteBatch.DrawString(spriteFontClock,
                (Clock.Minutes + 10) + ":" + (Clock.Seconds < 10 ? "0" : null) + Clock.Seconds,
                new Vector2(60, 65), Color.Red);

            DrawText("Threads : " + (maxThreads - availableThreads), 1350, 765);
            DrawText("Clients dans le restaurant : " + Model.Restaurant.Clients.Count, 1350, 795);
            DrawText("a table : " + nbClientATable, 1415, 825);
            DrawText("lisant la carte : " + nbClientCarte, 1415, 855);
            DrawText("dans le carre 1 : " + nbClientCarre1, 1415, 885);
            DrawText("dans le carre 2 : " + nbClientCarre2, 1415, 915);
            DrawText("Tables libres : " + nbTableLibre, 1350, 945);
            DrawText("Vitesse : x" + Clock.Speed, 1650, 765);

            foreach (Button button in Buttons)
            {
                button.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawImage(string image, int x, int y) => spriteRender.Draw(spriteSheet.Sprite(image), new Vector2(x, y));

        public void DrawText(string text, int x, int y) => spriteBatch.DrawString(spriteFont, text, new Vector2(x, y), Color.White);

        public static void Print(string text) => Console.WriteLine(text);
    }
}
