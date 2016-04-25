﻿using System;
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
            fileManager = new FileManager();
            moveAnimation = new SpriteSheetAnimation();
            Vector2 tempFrames = Vector2.Zero;

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
        public override void UnloadContent()
        {
            base.UnloadContent();
            moveAnimation.UnloadContent();
        }
        public override void Update(GameTime gameTime, InputManager input)
        {
            moveAnimation.IsActiv = true;
<<<<<<< HEAD
            if (input.KeyDown(Keys.Right, Keys.D))
                moveAnimation.CurrentFrame = new Vector2(moveAnimation.CurrentFrame.X, 9);
=======

            if (input.KeyDown(Keys.Right, Keys.D))
                moveAnimation.CurrentFrame = new Vector2(moveAnimation.CurrentFrame.X, 2);
>>>>>>> 2d54b07... added new sprite
            else if (input.KeyDown(Keys.Left, Keys.A))
                moveAnimation.CurrentFrame = new Vector2(moveAnimation.CurrentFrame.X, 1);
            else
                moveAnimation.IsActiv = false;
<<<<<<< HEAD

=======
>>>>>>> 2d54b07... added new sprite
            moveAnimation.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            moveAnimation.Draw(spriteBatch);
        }

    }
}
