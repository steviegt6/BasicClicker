using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Core.Interfaces
{
    public interface IDrawable
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}