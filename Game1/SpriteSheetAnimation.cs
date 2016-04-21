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
   public class SpriteSheetAnimation : Animation
    {
       int frameCounter;
       int switchFrame;

       public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
       {
           base.LoadContent(Content, image, text, position);
           frameCounter = 0;
           switchFrame = 100;
       }
       public override void UnloadContent()
       {
           base.UnloadContent();
       }
       public override void Update(GameTime gameTime)
       {
           if (isActiv)
           {
               frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
               if(frameCounter >= switchFrame)
               {
                   frameCounter = 0;
               }
           }
           else
           {
               frameCounter = 0;
           }
          
   
       }
       public override void Draw(SpriteBatch spriteBatch)
       {
           base.Draw(spriteBatch);
       }
    }
}
