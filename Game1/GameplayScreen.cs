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
    class GameplayScreen : GameScreen
    {
        Player player;
        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            player = new Player();
            player.LoadContent(content, input);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
<<<<<<< HEAD
            inputManager.Update();
            player.Update(gameTime, inputManager);
=======
            base.Update(gameTime);
           
>>>>>>> 2d54b07... added new sprite
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
