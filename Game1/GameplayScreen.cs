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
    public enum Direction
    {
        up,
        down,
        left,
        right
    }

    class GameplayScreen : GameScreen
    {
        Player player;
        Layers layer;

        private List<Enemy> enemies;
        private List<NinjaStar> stars;
        private Texture2D shurikenTexture;
        private bool isAlive = true;

        SpriteFont deathFont;

        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            player = new Player();
            layer = new Layers();
            player.LoadContent(content, input);
            layer.LoadContent(content, "../../../../../../Load/Maps/Map1");
            deathFont = content.Load<SpriteFont>("DeathFont");
            Random rand = new Random();

            stars = new List<NinjaStar>();

            shurikenTexture = content.Load<Texture2D>("Shuriken");
            
            enemies = new List<Enemy>();
            for (int i = 0; i < 50; i++)
            {
                int startX = rand.Next(10, 600);
                int startY = rand.Next(10, 600);
                enemies.Add(new Enemy(player, startX, startY));
            }
            enemies.Add(new Enemy(player,0,0));
            foreach (Enemy enemy in enemies)
            {
                enemy.LoadContent(content, input);
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            foreach (Enemy enemy in enemies)
            {
                enemy.UnloadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                inputManager.Update();
                player.Update(gameTime, inputManager);
                float playerRight = player.position.X + player.Width;
                float playerLeft = player.position.X;
                float playerTop = player.position.Y;
                float playerBottom = player.position.Y + player.Height;
                if (inputManager.KeyPressed(Keys.Space))
                {
                    Vector2 velocity = new Vector2();

                    switch (player.direction)
                    {
                        case Direction.up:
                            velocity = new Vector2(0, -10);
                            break;
                        case Direction.down:
                            velocity = new Vector2(0, 10);
                            break;
                        case Direction.left:
                            velocity = new Vector2(-10, 0);
                            break;
                        case Direction.right:
                            velocity = new Vector2(10, 0);
                            break;
                    }

                    stars.Add(new NinjaStar(shurikenTexture, velocity, player.position, 0));

                }
                foreach (Enemy enemy in enemies)
                {
                    float enemyRight = enemy.position.X + enemy.Width;
                    float enemyLeft = enemy.position.X;
                    float enemyTop = enemy.position.Y;
                    float enemyBottom = enemy.position.Y + enemy.Height;
                    enemy.Update(gameTime, inputManager);
                    if (!(enemyRight < playerLeft ||
                          enemyLeft > playerRight ||
                          enemyTop > playerBottom ||
                          enemyBottom < playerTop))
                    {
                        isAlive = false;
                    }

                }
                List<Enemy> enemeisToRemove = new List<Enemy>();
                List<NinjaStar> starsToRemove = new List<NinjaStar>();
                foreach (NinjaStar star in stars)
                {

                    star.Update();
                    float starRight = star.position.X + star.Width;
                    float starLeft = star.position.X;
                    float starTop = star.position.Y;
                    float starBottom = star.position.Y + star.Height;
                    foreach (Enemy enemy in enemies)
                    {
                        float enemyRight = enemy.position.X + enemy.Width;
                        float enemyLeft = enemy.position.X;
                        float enemyTop = enemy.position.Y;
                        float enemyBottom = enemy.position.Y + enemy.Height;
                        if (!(starRight < enemyLeft ||
                            starLeft > enemyRight ||
                            starTop > enemyBottom ||
                            starBottom < enemyTop))
                        {
                            enemeisToRemove.Add(enemy);
                            starsToRemove.Add(star);
                        }
                    }

                }
                foreach (Enemy enemy in enemeisToRemove)
                {
                    enemies.Remove(enemy);
                }
                foreach (NinjaStar star in starsToRemove)
                {
                    stars.Remove(star);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            layer.Draw(spriteBatch);

            player.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (NinjaStar star in stars)
            {
                star.Draw(spriteBatch);
            }

            if (!isAlive)
            {
                spriteBatch.DrawString(deathFont, "YOU DIED!", new Vector2(400, 320) - deathFont.MeasureString("YOU DIED!") / 2, Color.Red);
            }
        }
    }
}
