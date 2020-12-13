using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Assets
{
    public static class AssetManager
    {
        /* SpriteFonts */
        public static SpriteFont Consola;

        /* Texture2Ds */
        public static Texture2D TomatoLarge;

        public static void LoadAssets()
        {
            // SpriteFonts
            Consola = BCGame.Instance.Content.Load<SpriteFont>("Fonts\\Consola");

            // Texture2Ds
            TomatoLarge = BCGame.Instance.Content.Load<Texture2D>("Images\\TomatoLarge");
        }
    }
}