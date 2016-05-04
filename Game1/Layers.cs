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
    public class Layers
    {
        List<List<List<Vector2>>> tileMap;
        List<List<Vector2>> layer;
        List<Vector2> tile;

        ContentManager content;
        FileManager fileManager;

        Texture2D tileSet;
        Vector2 tileDimensions;

        int layerNumber;

        List<List<string>> attributes, contents;

        public int LayerNumber
        {
            set { layerNumber = value; }
        }

        public void LoadContent(ContentManager content, string mapID)
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
            fileManager = new FileManager();

            tile = new List<Vector2>();
            layer = new List<List<Vector2>>();
            tileMap = new List<List<List<Vector2>>>();
            attributes = new List<List<string>>();
            contents = new List<List<string>>();

            fileManager.LoadContent("Load/Maps/" + mapID + ".cme", attributes, contents, "Layers");

            for (int i = 0; i < attributes.Count; i++)
            {
                for (int j = 0; j < attributes[i].Count; j++)
                {
                    switch (attributes[i][j])
                    {
                        case "TileSet":
                            tileSet = this.content.Load<Texture2D>("TileSets/" + contents[i][j]);
                            break;
                        case "TileDimensions":
                            string[] split = contents[i][j].Split(',');
                            tileDimensions = new Vector2(int.Parse(split[0]), int.Parse(split[1]));
                            break;
                        case "StartLayer":
                            for (int k = 0; k < contents[i].Count; k++)
                            {
                                split = contents[i][k].Split(',');
                                tile.Add(new Vector2(int.Parse(split[0]), int.Parse(split[1])));
                            }
                            if (tile.Count > 0)
                                layer.Add(tile);
                            tile = new List<Vector2>();
                            break;
                        case "EndLayer":
                            if (layer.Count > 0)
                                tileMap.Add(layer);
                            layer = new List<List<Vector2>>();
                            break;
                    }

               
                }

                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tileMap[layerNumber].Count; i++)
            {
                for (int j = 0; j < tileMap[layerNumber][i].Count; j++)
                {
                    spriteBatch.Draw(tileSet, new Vector2(j * tileDimensions.X, i * tileDimensions.Y), new Rectangle((int)tileMap[layerNumber][i][j].X * (int)tileDimensions.X, (int)tileMap[layerNumber][i][j].Y * (int) tileDimensions.Y, (int)tileDimensions.X, (int)tileDimensions.Y), Color.White);
                }
            }
        }

    }
}
