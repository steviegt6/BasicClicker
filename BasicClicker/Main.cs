using BasicClicker.Assets;
using BasicClicker.GameContent.MainContent;
using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BasicClicker
{
    /// <summary>
    /// Main class for most non-categorized fields and methods. <br />
    /// Made for general-use stuff and to avoid cluttering <see cref="BCGame"/>.
    /// </summary>
    public static class Main
    {
        /// <summary>
        /// Logger used by BasicClicker.
        /// </summary>
        public static ILog Logger;

        public static readonly Version BCVersion = new Version(0, 0, 1, 0);

        public static bool GameIsIdle = false;
        public static readonly string VersionText = $"BasicClicker v{BCVersion}";

        public static Tomato LargeTomato = new Tomato();
        public static Cursor Cursor = new Cursor();
        public static MouseState BCMouse = Mouse.GetState();
        public static Vector2 WindowMeasurements = Vector2.Zero;
        public static float TomatoScale = 1f;

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicsDeviceManager graphicsDeviceManager = BCGame.Instance.BCGraphicsDeviceManager;
            GraphicsDevice graphicsDevice = graphicsDeviceManager.GraphicsDevice;

            // Get window measurements
            WindowMeasurements = graphicsDeviceManager.IsFullScreen ? new Vector2(graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height) : new Vector2(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

            // Draw the version in the bottom-left-hand corner of the screen
            DrawVersionText(spriteBatch, graphicsDeviceManager, graphicsDevice);

            // Draw the tomato
            // Draw code can be found in Tomato.cs
            LargeTomato.Draw(spriteBatch);
        }

        public static void Update(GameTime gameTime)
        {
            BCMouse = Mouse.GetState();

            Cursor.Update(gameTime);
            LargeTomato.Update(gameTime);
        }

        public static void DrawVersionText(SpriteBatch spriteBatch, GraphicsDeviceManager graphicsDeviceManager, GraphicsDevice graphicsDevice)
        {
            Vector2 versionTextSize = AssetManager.Consola.MeasureString(VersionText);
            Vector2 versionPosFullscreen = new Vector2(0, WindowMeasurements.Y - versionTextSize.Y);
            Vector2 versionPosWindowed = new Vector2(0, graphicsDevice.Viewport.Height - versionTextSize.Y);

            spriteBatch.DrawString(AssetManager.Consola, VersionText, graphicsDeviceManager.IsFullScreen ? versionPosFullscreen : versionPosWindowed, Color.Black);
        }
    }
}