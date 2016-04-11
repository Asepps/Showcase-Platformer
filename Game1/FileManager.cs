using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game1
{
    public class FileManager
    {
        enum LoadType { Attributes, Contents };

        LoadType type;

        List<string> tempAttributes = new List<string>();
        List<string> tempContents = new List<string>();

        bool identifierFound = false;


        public void LoadContent(string filename, List<List<string>> attributes, List<List<string>> contents)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Contains("Load ="))
                    {
                        tempAttributes = new List<string>();
                        line.Remove(0, line.IndexOf("=") + 1);
                        type = LoadType.Attributes;
                    }
                    else
                    {
                        tempContents = new List<string>();
                        type = LoadType.Contents;
                    }
                    
                    

                    string[] lineArray = line.Split('[');
                    foreach (string li in lineArray)
                    {
                        string newLine = li.Trim('[', ' ', ']');
                        if (newLine != String.Empty)
                        {
                            if (type == LoadType.Contents)
                                    tempContents.Add(newLine);

                                //BAKER -debug why this is adding Load = to the list

                            else if (newLine ==	"Load =")
                            {

                            }
                                
                            else
                                tempAttributes.Add(newLine);
                        }
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
            List<List<string>> contents, string identifier)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains("EndLoad=") && line.Contains(identifier))
                    {
                        identifierFound = false;
                        break;
                    }
                    else if(line.Contains("Load=") && line.Contains(identifier))
                    {
                        identifierFound = true;
                        continue;
                    }
                    if (identifierFound)
                    {
                        if (line.Contains("Load="))
                        {
                            tempAttributes = new List<string>();
                            line = line.Remove(0, line.IndexOf("=") + 1);
                            type = LoadType.Attributes;
                        }
                        else
                        {
                            tempContents = new List<string>();
                            type = LoadType.Contents;
                        }
                        string[] lineArray = line.Split(']');

                        foreach (string li in lineArray)
                        {
                            string newLine = li.Trim('[', ' ', ']');
                            if (newLine != String.Empty)
                            {
                                if (type == LoadType.Contents)
                                    tempContents.Add(newLine);
                                else
                                    tempAttributes.Add(newLine);
                            }
                        }
                        if (type == LoadType.Contents && tempContents.Count > 0)
                        {
                            contents.Add(tempContents);
                            attributes.Add(tempAttributes);
                        }
                    }
                }
            }
        }
    }
}
