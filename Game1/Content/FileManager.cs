using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Content
{
    public class FileManager
    {
        enum LoadType{Attribute, Contents};


        List<List<string>> attributes = new List<List<string>>();
        List<List<string>> contents = new List<List<string>>();

        public void LoadContent(string filname, List<List<string>> attributes, List<List<string>> contents)
        {

        }
        public void LoadContent(string filename, List<List<string>> attributes,
            List<List<string>> contetns, string indentifier)
        {

        }
    }
}
