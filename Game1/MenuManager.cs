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
        List<List<string>> attributes, contents;
        int axis;
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
                        case"Item":
                            menuItems.Add(contents[i][j]);
                                break;
                        case"Image":
                                menuImages.Add(content.Load<Texture2D>(contents[i][j]);
                                break;
                        case"Position":
                            string[] temp = contents[i][j].Split('');
                            posiotion = new Vector2(float.Parse(temp[]))


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
    }
}
