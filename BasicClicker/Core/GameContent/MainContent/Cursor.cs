using BasicClicker.Core;
using BasicClicker.Core.GameContent;
using Microsoft.Xna.Framework;

namespace BasicClicker.Core.GameContent.MainContent
{
    public class Cursor : Entity
    {
        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Main.BCMouse.X, Main.BCMouse.Y);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
        }
    }
}