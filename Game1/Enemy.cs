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
        Texture2D ErightWalk, EleftWalk, EupWalk, EdownWalk, EcurrentWalk;
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 200f;
        int frames = 0;



        public override void LoadContent(ContentManager content, InputManager input)
        {
            fileManager = new FileManager();
            moveAnimation = new SpriteSheetAnimation();
            Vector2 tempFrames = Vector2.Zero;
            base.LoadContent(content, input);
            

            ErightWalk = content.Load<Texture2D>("EnemyNinjaRight");
            EleftWalk = content.Load<Texture2D>("EnemyNinjaLeft");
            EupWalk = content.Load<Texture2D>("EnemyNinjaUp");
            EdownWalk = content.Load<Texture2D>("EnemyNinjaDown");
            EcurrentWalk = ErightWalk;




            fileManager.LoadContent("../../../../Load/Enemy.cme", attributes, contents);
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
                            position = new Vector2(int.Parse(frames[0]), int.Parse(frames[1]));
                            break;


                    }
                }
            }

            base.LoadContent(content, input);
        }

        public override void Initialize()
        {
            destRect = new Rectangle(100, 100, 31, 32);
            base.Initialize();
        }
        public override void UnloadContent()
        {
           

            base.UnloadContent();
        }
        public override void Update(GameTime gameTime, InputManager input)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= 3)
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
        public override void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Draw(EcurrentWalk, new Rectangle(100, 100, 31, 32), new Rectangle(0, 0, 31, 32), Color.White);
            base.Draw(spritebatch);
        }




    }
}
