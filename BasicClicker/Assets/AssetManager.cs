using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace BasicClicker.Assets
{
    public static class AssetManager
    {
        /* Songs */
        public static Song Melancholy;

        /* SpriteFonts */
        public static SpriteFont Consola;

        /* Texture2Ds */
        public static Texture2D TomatoLarge;
        public static Texture2D Cursor;

        internal static void LoadAssets()
        {
            LoadSongs();
            LoadSpriteFonts();
            LoadTexture2Ds();
        }

        #region Quick-call methods

        /// <summary>
        /// Loads a <see cref="Song"/> from the <c>Content</c> folder.
        /// </summary>
        public static Song LoadSong(string assetPath, bool autoPath = true)
        {
            if (autoPath)
                assetPath = "Sounds\\" + assetPath;

            return Load<Song>(assetPath);
        }

        /// <summary>
        /// Loads a <see cref="SpriteFont"/> from the <c>Content</c> folder.
        /// </summary>
        public static SpriteFont LoadSpriteFont(string assetPath, bool autoPath = true)
        {
            if (autoPath)
                assetPath = "Fonts\\" + assetPath;

            return Load<SpriteFont>(assetPath);
        }

        /// <summary>
        /// Loads a <see cref="Texture2D"/> from the <c>Content</c> folder.
        /// </summary>
        public static Texture2D LoadTexture2D(string assetPath, bool autoPath = true)
        {
            if (autoPath)
                assetPath = "Images\\" + assetPath;

            return Load<Texture2D>(assetPath);
        }

        /// <summary>
        /// Shorthand for <see cref="Microsoft.Xna.Framework.Content.ContentManager.Load{T}(string)"/>.
        /// </summary>
        public static T Load<T>(string assetPath) => BCGame.Instance.Content.Load<T>(assetPath);

        #endregion Quick-call methods

        #region Texture initialization methods

        private static void LoadSongs()
        {
            Melancholy = LoadSong("Melancholy_BGM");
        }

        private static void LoadSpriteFonts()
        {
            Consola = LoadSpriteFont("Consola");
        }

        private static void LoadTexture2Ds()
        {
            TomatoLarge = LoadTexture2D("TomatoLarge");
            Cursor = LoadTexture2D("Cursor");
        }

        #endregion Texture initialization methods
    }
}