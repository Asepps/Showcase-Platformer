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
       KeyboardState keyState;
       SpriteFont font;

       public override void LoadContent(ContentManager Content)
       {
           base.LoadContent(Content);
           if (font == null)
               font = content.Load<SpriteFont>("TimesNewRoman12");
       }
       public override void UnloadContent()
       {
           base.UnloadContent();
       }
       public override void Update(GameTime gametime)
       {
           keyState = Keyboard.GetState();
           if (keyState.IsKeyDown(Keys.B))
               ScreenManager.Instance.AddScreen(new SplashScreen());
       }
       public override void Draw(SpriteBatch spritebatch)
       {
           spritebatch.DrawString(font, "TitleScreen", new Vector2(200, 300), Color.Black);
       }
    }
 }

