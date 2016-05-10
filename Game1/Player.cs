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
        public Direction direction;
        Texture2D rightWalk,leftWalk,upWalk,downWalk,currentWalk;
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 200f;
        int frames = 0;
        private KeyboardState ks;

        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            fileManager = new FileManager();
            moveAnimation = new SpriteSheetAnimation();
            Vector2 tempFrames = Vector2.Zero;

            
            rightWalk = content.Load<Texture2D>("Ninjaright");
            leftWalk = content.Load<Texture2D>("NinjaLeft");
            upWalk = content.Load<Texture2D>("NinjaUp");
            downWalk = content.Load<Texture2D>("NinjaDown");

            currentWalk = rightWalk;
            direction = Direction.right;

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
            Width = image.Width/3 -10;
            Height = image.Height-5;
            moveAnimation.LoadContent(content, image, "", position);

        }
        public override void Initialize()
        {
            destRect = new Rectangle(100, 100, 32, 32);
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
            sourceRect = new Rectangle(32 * frames, 0, 32, 32);
        }
        public override void Update(GameTime gameTime, InputManager input)
        {
            ks = Keyboard.GetState();
            {
                if (ks.IsKeyDown(Keys.D))
                {
                    direction = Direction.right;
                    position.X += 2f;
                    currentWalk = rightWalk;
                    Animate(gameTime);
                }
                else if (ks.IsKeyDown(Keys.A))
                {
                    direction = Direction.left;
                    position.X -= 2f;
                    currentWalk = leftWalk;
                    Animate(gameTime);
                }
                else if (ks.IsKeyDown(Keys.W))
                {
                    direction = Direction.up;
                    position.Y -= 2f;
                    currentWalk = upWalk;
                    Animate(gameTime);
                }
                else if (ks.IsKeyDown(Keys.S))
                {
                    direction = Direction.down;
                    position.Y += 2f;
                    currentWalk = downWalk;
                    Animate(gameTime);
                }
                else
                {
                    sourceRect = new Rectangle(0, 0, 32, 32);
                }


               
            }

            moveAnimation.IsActiv = true;
            destRect = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            moveAnimation.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentWalk, new Rectangle((int)position.X, (int)position.Y, 32, 32), new Rectangle(32 * frames, 0, 32, 32),Color.White , 0, new Vector2(16, 16), SpriteEffects.None, 1);

            //moveAnimation.Draw(spriteBatch);
        }

    }
}
