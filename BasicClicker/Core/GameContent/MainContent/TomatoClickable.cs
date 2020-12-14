using BasicClicker.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Core.GameContent.MainContent
{
    public class TomatoClickable : Entity
    {
        public Vector2 ScreenMiddle => Main.WindowMeasurements / 2f;

        public override void Update(GameTime gameTime)
        {
            Position = ScreenMiddle;
            Hitbox = new Rectangle((int)ScreenMiddle.X - AssetManager.TomatoLarge.Width / 2, (int)ScreenMiddle.Y - AssetManager.TomatoLarge.Height / 2, AssetManager.TomatoLarge.Width, AssetManager.TomatoLarge.Height);

            if (Main.Cursor.Hitbox.Intersects(Main.LargeTomato.Hitbox))
                Main.TomatoScale = MathHelper.Lerp(Main.TomatoScale, 1f, 0.15f);
            else
                Main.TomatoScale = MathHelper.Lerp(Main.TomatoScale, 0.75f, 0.15f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetManager.TomatoLarge, ScreenMiddle, null, Color.White, 0f, new Vector2(AssetManager.TomatoLarge.Width, AssetManager.TomatoLarge.Height) / 2f, Main.TomatoScale, SpriteEffects.None, 0f);
        }
    }
}