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
    public class MenuManager
    {
        List<string> menuItems;
        List<string> animationTypes;
        List<Texture2D> menuImages;
        List<List<Animation>> animation;

        ContentManager content;

        FileManager fileManager;

        Vector2 position;
        int axis;
        List<List<string>> attributes, contents;
        List<Animation> tempAnimation;
        Rectangle source;
        SpriteFont font;

        int itemNumber;
        private void SetMenuItems()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuImages.Count == i)
                    menuImages.Add(null);
            }
            for (int i = 0; i < menuImages.Count; i++)
            {
                if (menuItems.Count == i)
                    menuItems.Add("");
            }
        }

        private void SetAnimationd()
        {
            Vector2 posAdd = position;
            Vector2 dimensions;
            for (int i = 0; i < menuImages.Count; i++)
            {
                
                for (int j = 0; j < animationTypes.Count; i++)
                {
                    switch (animationTypes[j])
                    {
                        case"Fade":
                            tempAnimation.Add(new FadeAnimation());
                            tempAnimation[tempAnimation.Count - 1].LoadContent(content, menuImages[i], menuItems[i], position)
                            break;

                    }
                }
                animation.Add(tempAnimation);
                tempAnimation = new List<Animation>();
                dimensions = new Vector2(font.MeasureString(menuItems[i]).X + menuImages[i].Width,
                    font.MeasureString(menuItems[i]).Y + menuImages[i].Height);

                if(axis ==1)
                {
                    pos.X += dimensions.X;

                }
                else
                {
                    pos.Y += dimensions.Y;
                }

            }
        }
     
        
        public void LoadContent(ContentManager content, string id)
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
            menuItems = new List<string>();
            animationTypes = new List<string>();
            menuImages = new List<Texture2D>();
            animation = new List<List<Animation>>();
            attributes = new List<List<string>>();
            contents = new List<List<string>>();
            
            position = Vector2.Zero;
            fileManager.LoadContent("Load/Menus.cme", attributes, contents, id);

            for (int i = 0; i < attributes.Count; i++)
            {
                for (int j = 0; j < attributes.Count; i++)
                {
                    switch (attributes[i][j])
                    {
                        case"Font":
                            font = content.Load<SpriteFont>(contents[i][j]);
                            break;
                        case"Item":
                            menuItems.Add(contents[i][j]);
                                break;
                        case"Image":
                                menuImages.Add(content.Load<Texture2D>(contents[i][j]));
                                break;
                        case "Axis":
                            axis = int.Parse(contents[i][j]);
                            break;
                        case"Position":
                            string[] temp = contents[i][j].Split(' ');
                            position = new Vector2(float.Parse(temp[0]),
                            float.Parse(temp[1]));
                            break;
                        case"Source":
                            temp = contents[i][j].Split(' ');
                            source = new Rectangle(int.Parse(temp[0]),
                                int.Parse(temp[1]), int.Parse(temp[2]), int.Parse(temp[3]));
                            break;

                    }

                    
                }
            }
        }
        public void UnloadContent()
        {
            content.Unload();
            fileManager = null;
            position = Vector2.Zero;
            animation.Clear();
            menuItems.Clear();
            menuImages.Clear();
            animationTypes.Clear();
        }
        public void Update(GameTime gametime)
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
