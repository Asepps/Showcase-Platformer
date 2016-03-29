﻿using System;
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
    public class SplashScreen : GameScreen
    {
        
       KeyboardState keyState;
       SpriteFont font;
       List<FadeAnimation> fade;
       List<Texture2D> images;

       int imageNumber;
       

       public override void LoadContent(ContentManager Content)
       {
           base.LoadContent(Content);
           if (font == null)
               font = content.Load<SpriteFont>("TimesNewRoman12");
           fade = new List<FadeAnimation>();
           images = new List<Texture2D>();
           imageNumber = 0;
           for (int i = 0; i < attributes.Count; i++)
           {
               for (int j = 0; j < attributes[i].Count; j++)
               {
                   switch (attributes[i][j])
                   {
                       case "Image":
                           images.Add(content.Load<Texture2D>(contents[i][j]));
                           fade.Add(new FadeAnimation());
                           break;
                   }
               }
           }
           for (int i = 0; i < fade.Count; i++)
           {
               fade[i].LoadContent(content, images[i], "", Vector2.Zero);
               fade[i].Scale = 3.08f;
               fade[i].IsActiv = true;
           }
       }
       public override void UnloadContent()
       {
           base.UnloadContent();
       }
       public override void Update(GameTime gametime)
       {
           keyState = Keyboard.GetState();
           if (keyState.IsKeyDown(Keys.Enter))
           ScreenManager.Instance.AddScreen(new TitleScreen());
           base.Update(gametime);

           
       }
       public override void Draw(SpriteBatch spritebatch)
       {
           fade[imageNumber].Draw(spritebatch);
       }



      
    }
}


