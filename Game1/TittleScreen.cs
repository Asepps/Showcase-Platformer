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
    public class TitleScreen : GameScreen
    {
       
       SpriteFont font;
       MenuManager menu;

       public override void LoadContent(ContentManager Content,InputManager inputManager)
       {
           base.LoadContent(Content, inputManager);
           if (font == null)
               font = content.Load<SpriteFont>("TimesNewRoman12");
           menu = new MenuManager();
           menu.LoadContent(content, "Title");
       }
       public override void UnloadContent()
       {
           base.UnloadContent();
           menu.UnloadContent();
       }
       public override void Update(GameTime gametime)
       {
           menu.Update(gametime, inputManager);
       }
       public override void Draw(SpriteBatch spritebatch)
       {
           menu.Draw(spritebatch);
       }
    }
 }

