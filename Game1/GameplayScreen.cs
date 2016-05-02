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
        Layers layer;
        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
            player = new Player();
            layer = new Layers();
            player.LoadContent(content, input);
            layer.LoadContent(content, "../../../../../../Load/Maps/Map1");
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
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            layer.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
