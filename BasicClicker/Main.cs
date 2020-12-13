using BasicClicker.Assets;
using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BasicClicker
{
    /// <summary>
    /// Main class for most non-categorized fields and methods. <br />
    /// Made for general-use stuff and to avoid cluttering <see cref="BasicClickerGame"/>.
    /// </summary>
    public static class Main
    {
        public static readonly Version BCVersion = new Version(0, 0, 1, 0);

        public static bool GameIsIdle = false;
        public static readonly string VersionText = $"BasicClicker v{BCVersion}";

        /// <summary>
        /// Logger used by BaseClicker.
        /// </summary>
        public static ILog Logger = LogManager.GetLogger("BaseClicker");

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw the version in the bottom-left-hand corner of the screen
            DrawVersionText(spriteBatch);
        }

        public static void Update(GameTime gameTime)
        {
        }

        public static void DrawVersionText(SpriteBatch spriteBatch)
        {
            GraphicsDevice graphicsDevice = BasicClickerGame.Instance.BCGraphicsDeviceManager.GraphicsDevice;
            Vector2 versionTextSize = AssetManager.Consola.MeasureString(VersionText);
            Vector2 versionPosFullscreen = new Vector2(0, graphicsDevice.DisplayMode.Height - versionTextSize.Y);
            Vector2 versionPosWindowed = new Vector2(0, graphicsDevice.Viewport.Height - versionTextSize.Y);

            spriteBatch.DrawString(AssetManager.Consola, VersionText, BasicClickerGame.Instance.BCGraphicsDeviceManager.IsFullScreen ? versionPosFullscreen : versionPosWindowed, Color.Black);
        }
    }
}