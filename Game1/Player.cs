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
    public class Player:Entity
    {
        Texture2D rightWalk, leftWalk;
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 200f;
        int frames = 0;
        private KeyboardState ks;
        Vector2 position = new Vector2();
        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            fileManager = new FileManager();
            moveAnimation = new SpriteSheetAnimation();
            Vector2 tempFrames = Vector2.Zero;
            
            rightWalk = content.Load<Texture2D>("Ninjaright");
            leftWalk = content.Load<Texture2D>("NinjaLeft");

            

            fileManager.LoadContent("../../../../Load/Player.cme", attributes, contents);
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
            moveAnimation.LoadContent(content, image, "", position);

        }
        public override void Initialize()
        {
            destRect = new Rectangle(100, 100, 32, 128);
            base.Initialize();
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            moveAnimation.UnloadContent();
        }

        private void Animate(GameTime gameTime)
        {

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= delay)
            {
                if (frames > 1)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }
                elapsed = 0;
            }
            sourceRect = new Rectangle(32 * frames, 0, 32, 128);
        }
        public override void Update(GameTime gameTime, InputManager input)
        {
            ks = Keyboard.GetState();
            {
                if (ks.IsKeyDown(Keys.D))
                {
                    position.X += 2f;
                }
            }

            moveAnimation.IsActiv = true;
            destRect = new Rectangle((int)position.X, (int)position.Y, 32, 128);
            Animate(gameTime);
            moveAnimation.Update(gameTime);

           

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rightWalk, new Rectangle((int)position.X, (int)position.Y, 32, 128), new Rectangle(32 * frames, 0, 32, 128), Color.White);

            moveAnimation.Draw(spriteBatch);
        }

    }
}
