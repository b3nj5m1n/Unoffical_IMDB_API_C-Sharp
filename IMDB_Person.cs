using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebToolsLMDB
{
    public class IMDB_Person
    {
        private string type;
        private string url;
        private string name;

        public string Name { get => name; set => name = value; }
        public string Url { get => url; set => url = value; }
        public string Type { get => type; set => type = value; }
    }
}
