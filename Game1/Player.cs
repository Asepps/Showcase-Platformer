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

        

        public override void LoadContent(ContentManager content, InputManager input)
        {
            base.LoadContent(content, input);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            moveAnimation.UnloadContent();
        }
        public override void Update(GameTime gameTime, InputManager input)
        {
            moveAnimation.IsActiv = true;
            if (input.KeyDown(Keys.Right, Keys.D))
                moveAnimation.CurrentFrame = new Vector2(moveAnimation.CurrentFrame.X, 9);
            else if (input.KeyDown(Keys.Left, Keys.A))
                moveAnimation.CurrentFrame = new Vector2(moveAnimation.CurrentFrame.X, 1);
            else
                moveAnimation.IsActiv = false;

            moveAnimation.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            moveAnimation.Draw(spriteBatch);
        }

    }
}
