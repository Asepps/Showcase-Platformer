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
    public class Enemy : Entity
    {
        public Direction direction;
        Texture2D rightWalk, leftWalk, upWalk, downWalk, currentWalk;
        Rectangle destRect;
        Rectangle sourceRect;
        Random rand;
        Player player;
        float elapsed;
        float delay = 200f;
        int frames = 0;
        int randTime = 0;
        int randDirection = 0;
       
        public Enemy(Player player,int posX, int posY, int enemySeed)
            
        {
            rand = new Random(enemySeed);
            this.player = player;
            position.X = posX;
            position.Y = posY;
        }

        public override void LoadContent(ContentManager content, InputManager input)
        {
            fileManager = new FileManager();
            moveAnimation = new SpriteSheetAnimation();
            Vector2 tempFrames = Vector2.Zero;
            base.LoadContent(content, input);

            rightWalk = content.Load<Texture2D>("EnemyNinjaRight");
            leftWalk = content.Load<Texture2D>("EnemyNinjaLeft");
            upWalk = content.Load<Texture2D>("EnemyNinjaUp");
            downWalk = content.Load<Texture2D>("EnemyNinjaDown");
            currentWalk = rightWalk;




      /*      fileManager.LoadContent("../../../../Load/Enemy.cme", attributes, contents);
            for (int i = 0; i < attributes.Count; i++)
            {
                for (int j = 0; j < attributes[i].Count; j++)
                {
                    switch (attributes[i][j])
                    {
                        case "Health":
                            health = int.Parse(contents[i][j]);
                            break;
                        case "Frames":
                            string[] frames = contents[i][j].Split(' ');
                            tempFrames = new Vector2(int.Parse(frames[0]), int.Parse(frames[1]));
                            break;
                        case "Image":
                            image = content.Load<Texture2D>(contents[i][j]);
                            break;
                        case "Position":
                            frames = contents[i][j].Split(' ');
                            //position = new Vector2(int.Parse(frames[0]), int.Parse(frames[1]));
                            break;
            

                    }
                }
            }
       */
            image = content.Load<Texture2D>("EnemyNinjaRight");
            Width = image.Width/3;
            Height = image.Height;
            moveAnimation.LoadContent(content, image, "", position);
            base.LoadContent(content, input);
        }
        public void Animate(GameTime gameTime)
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
                sourceRect = new Rectangle(31 * frames, 0, 31, 32);
        }


        public override void Initialize()
        {
            destRect = new Rectangle(100, 100, 31, 32);
            base.Initialize();
        }
        public override void UnloadContent()
        {
           

            base.UnloadContent();
            moveAnimation.UnloadContent();

        }

        public override void Update(GameTime gameTime, InputManager input)
        {
            if (randTime <= 0)
            {
                randTime = rand.Next(10, 60);
                randDirection = rand.Next(0,100);
                //randDirection *= (int) position.X + (int) position.Y;
                randDirection = randDirection % 2;
            }
            randTime--;
            if (Math.Round(player.position.X) > Math.Round(position.X) && Math.Round(player.position.Y) > Math.Round(position.Y))
            {
                if (randDirection == 1)
                {
                    position.X += 1.5f;
                    direction = Direction.right;
                    currentWalk = rightWalk;
                }
                else 
                {
                    position.Y += 1.5f;
                    direction = Direction.down;
                    currentWalk = downWalk;
                }
            }
            else if (Math.Round(player.position.X) < Math.Round(position.X) && Math.Round(player.position.Y) > Math.Round(position.Y))
            {
                if (randDirection == 1)
                {
                    position.X -= 1.5f;
                    direction = Direction.left;
                    currentWalk = leftWalk;
                }
                else
                {
                    position.Y += 1.5f;
                    direction = Direction.down;
                    currentWalk = downWalk;
                }
            }
            else if (Math.Round(player.position.X) > Math.Round(position.X) && Math.Round(player.position.Y) < Math.Round(position.Y))
            {
                if (randDirection == 1)
                {
                    position.X += 1.5f;
                    direction = Direction.right;
                    currentWalk = rightWalk;
                }
                else
                {
                    position.Y -= 1.5f;
                    direction = Direction.up;
                    currentWalk = upWalk;
                }
            }
            else if (Math.Round(player.position.X) < Math.Round(position.X) && Math.Round(player.position.Y) < Math.Round(position.Y))
            {
                if (randDirection == 1)
                {
                    position.X -= 1.5f;
                    direction = Direction.left;
                    currentWalk = leftWalk;
                }
                else
                {
                    position.Y -= 1.5f;
                    direction = Direction.up;
                    currentWalk = upWalk;
                }
            }
            else if (Math.Round(player.position.X) > Math.Round(position.X))
            {
                position.X += 1.5f;
                direction = Direction.right;
                currentWalk = rightWalk;
            }
            else if (Math.Round(player.position.Y) > Math.Round(position.Y))
            {
                position.Y += 1.5f;
                direction = Direction.down;
                currentWalk = downWalk;
            }
            else if (Math.Round(player.position.X) < Math.Round(position.X))
            {
                position.X -= 1.5f;
                direction = Direction.left;
                currentWalk = leftWalk;
            }
            else if (Math.Round(player.position.Y) < Math.Round(position.Y))
            {
                position.Y -= 1.5f;
                direction = Direction.up;
                currentWalk = upWalk;
            }

            Animate(gameTime);

            moveAnimation.IsActiv = true;
            destRect = new Rectangle((int)position.X, (int)position.Y, 31, 32);
            moveAnimation.Update(gameTime);
            
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(currentWalk, new Rectangle((int)position.X, (int)position.Y, 32, 32), new Rectangle(32 * frames, 0, 32, 32), Color.White, 0, new Vector2(16, 16), SpriteEffects.None, 1);
           
            base.Draw(spritebatch);
        }




    }
}
