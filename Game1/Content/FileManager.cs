using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace Game1.Content
{
    public class FileManager
    {
        enum LoadType{Attributes, Contents};

        LoadType type;


        List<List<string>> attributes = new List<List<string>>();
        List<List<string>> contents = new List<List<string>>();

        List<string> tempAttributes = new List<string>();
        List<string> tempContents = new List<string>();

        bool identifierFound = false;
    
        public void LoadContent(string filename, List<List<string>> attributes, List<List<string>> contents)
        {
            using(StreamReader reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                if(line.Contains("Load="))
                {
                    if(identifierFound)
                    {

                    }
                    tempAttributes = new List<string>();
                    line.Remove(0, line.IndexOf("=") + 1);
                    type = LoadType.Attributes;
                }
                else
                {
                    tempContents = new List<string>();
                    type = LoadType.Contents;
                }

                string[] lineArray = line.Split('}');

                foreach (string li in lineArray)
                {
                    string newLine = li.Trim('[', ' ',']');
                    if(newLine != String.Empty)
                    {
                        if (type == LoadType.Contents)
                            tempContents.Add(newLine);
                        else
                            tempAttributes.Add(newLine);
                    }
                    if (type == LoadType.Contents && tempContents.Count > 0)
                    {
                        contents.Add(tempContents);
                        attributes.Add(tempAttributes);
                    }

                }
            }
        }
        public void LoadContent(string filename, List<List<string>> attributes,
            List<List<string>> contetns, string indentifier)
        {

        }
    }
}
