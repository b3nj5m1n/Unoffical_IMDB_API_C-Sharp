using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebToolsLMDB
{
    public class IMDB_SearchResult
    {
        string IMDB_TITLE_URL1;
        string IMG1;
        string Title1;
        string TitleExtension1;

        public string IMDB_TITLE_URL { get => IMDB_TITLE_URL1; set => IMDB_TITLE_URL1 = value; }
        public string IMG { get => IMG1; set => IMG1 = value; }
        public string Title { get => Title1; set => Title1 = value; }
        public string TitleExtension { get => TitleExtension1; set => TitleExtension1 = value; }

        public override string ToString()
        {
            return TitleExtension;
        }
    }
}
