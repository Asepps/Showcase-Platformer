using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    public class Animation
    {
        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle sourceRect;
        protected float rotation, scale, axis;
        protected Vector2 origion, position;
        protected ContentManager content;
        protected bool isActiv;
        protected float alpha;

        public virtual float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }
        public bool IsActiv
        {
            set { isActiv = value; }
            get { return isActiv; }
        }

        public float Scale
        {
            set { scale = value; }
        }
        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        public virtual void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            this.image = image;
            this.text = text;
            this.position = position;
            if (text != String.Empty)
                font = content.Load<SpriteFont>("Menu");
            color = new Color(114, 77, 255);
            if (image != null)
                sourceRect = new Rectangle(0 , 0 ,image.Width, image.Height);

            rotation = 0.0f;
            axis = 0.0f;
            scale = alpha = 1.0f;
            isActiv = false;
        }
        public virtual void UnloadContent()
        {
            content.Unload();
            text = string.Empty;
            position = Vector2.Zero;
            sourceRect = Rectangle.Empty;
            image = null;
        }
        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (image != null)
            {
                origion = new Vector2(sourceRect.Width / 2,
                    sourceRect.Height / 2);
                spriteBatch.Draw(image, position + origion, sourceRect, Color.White * alpha, rotation, origion, scale, SpriteEffects.None, 0.0f);
            }
            if (text != String.Empty)
            {
                origion = new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origion, color * alpha, rotation, origion, scale, SpriteEffects.None, 0.0f);
            }

        }
    }
}
