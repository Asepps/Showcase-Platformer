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
    public class SplashScreen : GameScreen
    {
        
       KeyboardState keyState;
       SpriteFont font;
       List<FadeAnimation> fade;
       List<Texture2D> images;

       FileManager fileManager;

       int imageNumber;
       

       public override void LoadContent(ContentManager Content)
       {
           base.LoadContent(Content);
           if (font == null)
               font = content.Load<SpriteFont>("TimesNewRoman12");
           imageNumber = 0;
           fileManager = new FileManager();
           fade = new List<FadeAnimation>();
           images = new List<Texture2D>();

           fileManager.LoadContent("Load/splash.cme", attributes, contents);

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
               fade[i].LoadContent(content, images[i], "", new Vector2 (269, 201 ));

               fade[i].Scale = 3.08f; 
               fade[i].IsActiv = true;
           }
       }
       public override void UnloadContent()
       {
           base.UnloadContent();
           fileManager = null;
       }
       public override void Update(GameTime gametime)
       {
           keyState = Keyboard.GetState();
           //if (keyState.IsKeyDown(Keys.Enter))
           //ScreenManager.Instance.AddScreen(new TitleScreen());

           fade[imageNumber].Update(gametime);
           if (fade[imageNumber].Alpha == 0.0f)
               imageNumber++;
           if(imageNumber >= fade.Count - 1 || keyState.IsKeyDown(Keys.Z))
           {
               ScreenManager.Instance.AddScreen(new TitleScreen());
           }
           
       }
       public override void Draw(SpriteBatch spritebatch)
       {
           fade[imageNumber].Draw(spritebatch);
       }



      
    }
}


