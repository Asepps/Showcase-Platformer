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

        private List<NinjaStar> stars;
        private Texture2D shurikenTexture;

        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            player = new Player();
            layer = new Layers();
            player.LoadContent(content, input);
            layer.LoadContent(content, "../../../../../../Load/Maps/Map1");

            stars = new List<NinjaStar>();
            shurikenTexture = content.Load<Texture2D>("Shuriken");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            inputManager.Update();
            player.Update(gameTime, inputManager);

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

            foreach (NinjaStar star in stars)
            {
                star.Update();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            layer.Draw(spriteBatch);

            foreach (NinjaStar star in stars)
            {
                star.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
        }
    }
}
