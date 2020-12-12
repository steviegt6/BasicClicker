using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Assets
{
    public static class AssetManager
    {
        public static SpriteFont Consola;

        public static void LoadAssets()
        {
            Consola = BasicClickerGame.Instance.Content.Load<SpriteFont>("Fonts\\Consola");
        }
    }
}