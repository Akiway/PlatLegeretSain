using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        List<Button> Buttons;
        public static Song Musique, Nyancat;
        SoundEffect Ambiance;
        Model.Statistique stats;
        public static Semaphore PrintPool = new Semaphore(1,1);

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
            stats = Controller.Program.stats;

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

            // Musique
            Musique = Content.Load<Song>("Musique");
            Nyancat = Content.Load<Song>("Nyancat");
            Ambiance = Content.Load<SoundEffect>("Ambiance");
            MediaPlayer.Play(Musique);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            Ambiance.Play();

            // Buttons of the interface
            Button speedBtn = new Button(1765, 755, 60, 40, "", spriteFont, buttonTexture);
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
            stats.Update(gameTime);

            ThreadPool.GetAvailableThreads(out availableThreads, out io);
            ThreadPool.GetMaxThreads(out maxThreads, out io);

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


            // Affichage des tables
            foreach (Model.Table table in Model.Restaurant.Tables)
            {
                //DrawImage(table.Img + table.NbPlace, table.X, table.Y);
                if (table.OrientationHorizontale)
                {
                    spriteRender.Draw(spriteSheet.Sprite(table.Img + table.NbPlace + table.ImgState), new Vector2(table.X, table.Y));
                }
                else
                {
                    spriteRender.Draw(spriteSheet.Sprite(table.Img + table.NbPlace + table.ImgState), new Vector2(table.X, table.Y), null, (float)Math.Atan2((double)1,(double)0));
                }
            }


            // Affichage des clients
            try
            {
                foreach (Model.Client client in Model.Restaurant.Clients)
                {
                    DrawImage(client.img + client.imgEtat + client.Orientation, client.X, client.Y);
                }
            } catch (Exception ex)
            {
                Print(ex.Message);
            }

            // Affichage des stats
            spriteBatch.DrawString(spriteFontClock,
                (Clock.Minutes + Model.Parameters.InitialHour) + ":" + (Clock.Seconds < 10 ? "0" : null) + Clock.Seconds,
                new Vector2(60, 65), Color.Red);

            DrawText("Threads : " + (maxThreads - availableThreads), 1350, 765);
            DrawText("Clients dans le restaurant : " + stats.nbClient, 1350, 795);
            DrawText("a table : " + stats.nbClientATable, 1415, 825);
            DrawText("lisant la carte : " + stats.nbClientCarte, 1415, 855);
            DrawText("dans le carre 1 : " + stats.nbClientCarre1, 1415, 885);
            DrawText("dans le carre 2 : " + stats.nbClientCarre2, 1415, 915);
            DrawText("Tables libres : " + stats.nbTableLibre, 1350, 945);
            DrawText("Vitesse : x" + Clock.Speed, 1650, 765);

            foreach (Button button in Buttons)
            {
                button.Draw(gameTime, spriteBatch);
            }

            // Affichage des employés
            foreach (Model.Employe employe in Model.Restaurant.Employes)
            {
                DrawImage(employe.img + employe.Orientation, employe.X, employe.Y);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawImage(string image, int x, int y) => spriteRender.Draw(spriteSheet.Sprite(image), new Vector2(x, y));

        public void DrawText(string text, int x, int y) => spriteBatch.DrawString(spriteFont, text, new Vector2(x, y), Color.White);

        public static void Print(string text)
        {
            Console.WriteLine(text);

            PrintPool.WaitOne();
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Controller.Program.logFile, true))
            {
                file.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " | " + text);
                file.Close();
            }
            PrintPool.Release();
        }
    }
}
