using BasicClicker.Assets;
using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BasicClicker
{
    public class BasicClickerGame : Game
    {
        /// <summary>
        /// GraphicsDeviceManager used by the entirety of BasicClicker.
        /// </summary>
        public GraphicsDeviceManager BCGraphicsDeviceManager { get; }

        /// <summary>
        /// SpriteBatch used by the entirety of BasicClicker.
        /// </summary>
        public SpriteBatch BCSpriteBatch { get; private set; }

        public static bool GameIsIdle;

        public static BasicClickerGame Instance { get; private set; }

        /// <summary>
        /// Logger used by BaseClicker.
        /// </summary>
        public static ILog Logger;

        public BasicClickerGame()
        {
            Instance = this;
            BCGraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            Window.Title = "Basic Clicker";

            GameIsIdle = false;

            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            Window.Title = "Basic Clicker - Idle";

            GameIsIdle = true;

            base.OnDeactivated(sender, args);
        }

        protected override void Initialize()
        {
            Logger = LogManager.GetLogger("BaseClicker");

            Logger.Info("Initializing");

            GameIsIdle = false;

            base.Initialize();

            Logger.Info("Initialized");
        }

        protected override void LoadContent()
        {
            Logger.Info("Loading content");

            BCSpriteBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.LoadAssets();

            Logger.Info("Content loaded");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            BCSpriteBatch.Begin();

            BCSpriteBatch.DrawString(AssetManager.Consola, "Test", new Vector2(0, 0), Color.Black);

            BCSpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}