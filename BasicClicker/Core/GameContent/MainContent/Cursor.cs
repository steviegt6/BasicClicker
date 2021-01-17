using BasicClicker.Core.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Core.GameContent.MainContent
{
    public class Cursor : Entity
    {
        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Main.BCMouse.X, Main.BCMouse.Y);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) => spriteBatch.Draw(AssetManager.Cursor, Position, Color.White);
    }
}