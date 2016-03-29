using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    public class GameScreen
    {
        protected ContentManager content;
        protected List<List<string>> attributes, contents;

        public virtual void Intialize() { }
        public virtual void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent() 
        {
            content.Unload();
        }
        public virtual void Update(GameTime gametime) { }
        public virtual void Draw(SpriteBatch spritebatch) { }

    }
}
