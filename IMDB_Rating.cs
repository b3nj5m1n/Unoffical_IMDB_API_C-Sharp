using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebToolsLMDB
{
    public class IMDB_Rating
    {
        public string type { get; set; }
        public long Rating_count { get; set; }
        public string Best_Rating { get; set; }
        public string Worst_Rating { get; set; }
        public string Average_Rating { get; set; }
    }
}
