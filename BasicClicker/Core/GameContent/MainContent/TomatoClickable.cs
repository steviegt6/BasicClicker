using BasicClicker.Core.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.Core.GameContent.MainContent
{
    public class TomatoClickable : Entity
    {
        public float rotationSpeed = 0.1f;
        public float tomatoScale = 1f;
        public float tomatoRotation = 0f;
        public bool rotationDirection = false;

        public Vector2 ScreenMiddle => Main.WindowMeasurements / 2f;

        public override void Update(GameTime gameTime)
        {
            Position = ScreenMiddle;
            Hitbox = new Rectangle((int)ScreenMiddle.X - AssetManager.TomatoLarge.Width / 2, (int)ScreenMiddle.Y - AssetManager.TomatoLarge.Height / 2, AssetManager.TomatoLarge.Width, AssetManager.TomatoLarge.Height);

            if (Main.Cursor.Hitbox.Intersects(Main.LargeTomato.Hitbox))
            {
                tomatoScale = MathHelper.Lerp(tomatoScale, 1f, 0.15f);
                rotationSpeed = MathHelper.Lerp(rotationSpeed, 0.75f, 0.025f);
            }
            else
            {
                tomatoScale = MathHelper.Lerp(tomatoScale, 0.75f, 0.15f);
                rotationSpeed = MathHelper.Lerp(rotationSpeed, 0.1f, 0.025f);
            }

            if (rotationDirection)
            {
                tomatoRotation += MathHelper.ToRadians(rotationSpeed);

                if (tomatoRotation >= MathHelper.ToRadians(10f))
                    rotationDirection = false;
            }
            else
            {
                tomatoRotation -= MathHelper.ToRadians(rotationSpeed);

                if (tomatoRotation <= MathHelper.ToRadians(-10f))
                    rotationDirection = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) => spriteBatch.Draw(AssetManager.TomatoLarge, ScreenMiddle, null, Color.White, tomatoRotation, new Vector2(AssetManager.TomatoLarge.Width, AssetManager.TomatoLarge.Height) / 2f, tomatoScale, SpriteEffects.None, 0f);
    }
}