using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class GameObject
    {
        public Texture2D texture { get; private set; }
        public Vector2 position;
        public Vector2 velocity = Vector2.Zero;
        public float speed = 0;
        public float rotation = 0;
        public float scale = 1;

        public int Width { get; private set; }
        public int Height { get; private set; }


        public GameObject(Texture2D texture)
        {
            this.texture = texture;

            Width = texture.Width;
            Height = texture.Height;
        }

        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = new Rectangle(0, 0, Width, Height);
            spriteBatch.Draw(texture, position, source, Color.White, rotation,
                new Vector2(Width / 2, Height / 2), scale, SpriteEffects.None, 1);
        }
            

    }
}
