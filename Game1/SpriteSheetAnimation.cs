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
           frames = new Vector2(10, 9);
           currentFrame = new Vector2(0, 0);
           sourceRect = new Rectangle((int)currentFrame.X * FrameWidth, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
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
                   currentFrame.X++;

                   if (currentFrame.X * FrameWidth >= image.Width)
                       currentFrame.X = 0;

                   
               }
           }
           else
           {
               frameCounter = 0;
           }
           sourceRect = new Rectangle((int)currentFrame.X * FrameWidth, (int)currentFrame.Y * FrameHeight, FrameHeight, FrameHeight);
   
       }
    }
}
