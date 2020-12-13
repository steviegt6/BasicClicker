using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Utilities
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns a Vector2 using <see cref="Texture2D.Height"/> and <see cref="Texture2D.Width"/>.
        /// </summary>
        public static Vector2 Size(this Texture2D texture) => new Vector2(texture.Width, texture.Height);
    }
}