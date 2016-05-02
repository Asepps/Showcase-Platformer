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
    public class Enemy:Entity
    {
        Texture2D rightWalk,leftWalk,upWalk,DownWalk,currentWalk;

           public override void LoadContent(ContentManager content, InputManager input)
           {
            fileManager = new FileManager();
            moveAnimation = new SpriteSheetAnimation();
            Vector2 tempFrames = Vector2.Zero;
            base.LoadContent(content, input);
            rightWalk = content.Load<Texture2D>("EnemyNinjaRight");
            rightWalk = content.Load<Texture2D>("Ninjaright");
            leftWalk = content.Load<Texture2D>("NinjaLeft");
            upWalk = content.Load<Texture2D>("NinjaUp");
            downWalk = content.Load<Texture2D>("NinjaDown");


            
            
            fileManager.LoadContent("../../../../Load/Enemies.cme", attributes, contents);
            for (int i = 0; i < attributes.Count; i++)
            {
                for (int j = 0; j < attributes[i].Count; j++)
                {
                    switch ( attributes [i][j])
                    {
                        case "Health":
                            health = int.Parse(contents[i][j]);
                            break;
                        case "Frames":
                            string[] frames = contents[i][j].Split(' ');
                            tempFrames = new Vector2(int.Parse(frames[0]), int.Parse(frames[1]));
                            break;
                        case"Image":
                            image = content.Load<Texture2D>(contents[i][j]);
                            break;
                        case "Position":
                            frames = contents[i][j].Split(' ');
                            position = new Vector2(int.Parse(frames[0]), int.Parse(frames[1]));
                            break;

                                
                    }
                }
            }
          
            base.LoadContent(content, input);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime, InputManager input)
        {
            
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(rightWalk, new Rectangle(100, 100, 32, 32), Color.White);
            spritebatch.End();
            base.Draw(spritebatch);
        }
    }
}
