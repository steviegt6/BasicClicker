using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BasicClicker.GameContent
{
    public abstract class Entity : IUpdateable, IDrawable
    {
        public Vector2 Position;

        public Rectangle Hitbox;

        public virtual bool IntersectsEntity(Entity entity) => Hitbox.Intersects(entity.Hitbox);

        public virtual bool IntersectsRectangle(Rectangle hitbox) => Hitbox.Intersects(hitbox);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}