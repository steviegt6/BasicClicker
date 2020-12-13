using BasicClicker.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;

namespace BasicClicker
{
    public class BCGame : Game
    {
        public static BCGame Instance { get; private set; }

        /// <summary>
        /// GraphicsDeviceManager used by the entirety of BasicClicker.
        /// </summary>
        public GraphicsDeviceManager BCGraphicsDeviceManager { get; }

        /// <summary>
        /// SpriteBatch used by the entirety of BasicClicker.
        /// </summary>
        public SpriteBatch BCSpriteBatch { get; private set; }

        public BCGame()
        {
            Instance = this;
            BCGraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        // Called when the program gets focused
        protected override void OnActivated(object sender, EventArgs args)
        {
            Window.Title = "Basic Clicker";

            Main.GameIsIdle = false;

            if (MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Resume();

            base.OnActivated(sender, args);
        }

        // Called when the program gets unfocused
        protected override void OnDeactivated(object sender, EventArgs args)
        {
            // Indicate the program is on idle when unfocused
            Window.Title = "Basic Clicker - Idle";

            Main.GameIsIdle = true;

            if (MediaPlayer.State == MediaState.Playing)
                MediaPlayer.Pause();

            base.OnDeactivated(sender, args);
        }

        protected override void Initialize()
        {
            Main.Logger.Info("Initializing");

            DataManager.CreateSaveFile();

            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;

            base.Initialize();

            MediaPlayer.Play(AssetManager.Melancholy);
            MediaPlayer.IsRepeating = true;

            Main.Logger.Info("Initialized");
        }

        protected override void LoadContent()
        {
            Main.Logger.Info("Loading content");

            BCSpriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.LoadAssets();

            Main.Logger.Info("Content loaded");
        }

        protected override void Update(GameTime gameTime)
        {
            Main.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            BCSpriteBatch.Begin();
            Main.Draw(gameTime, BCSpriteBatch);
            BCSpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}