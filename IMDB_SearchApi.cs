using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebToolsLMDB;

namespace WebToolsLMDB
{
    public class IMDB_SearchApi
    {

        

        public List<IMDB_SearchResult> Get_SearchResults(String Search)
        {
            string URL = FormatURL(Search);
            Console.WriteLine(URL);
            List<IMDB_SearchResult> search_results = new List<IMDB_SearchResult>();


            HtmlDocument doc = Get_Document(URL);
            
            List<Tuple<HtmlNode, HtmlNode>> search_results_raw = new List<Tuple<HtmlNode, HtmlNode>>();

            foreach (HtmlNode node in doc.DocumentNode.Descendants("tr").Where(d => d.GetAttributeValue("class", "").Contains("findResult")))
            {
                HtmlNode newNode = node.Descendants("td").Where(d => d.GetAttributeValue("class", "").Contains("result_text")).First();
                HtmlNode newNode2 = node.Descendants("td").Where(d => d.GetAttributeValue("class", "").Contains("primary_photo")).First();
                search_results_raw.Add(new Tuple<HtmlNode, HtmlNode>(newNode, newNode2));
            }


            
            foreach (Tuple<HtmlNode, HtmlNode> Tuple in search_results_raw)
            {
                HtmlNode img_node = Tuple.Item2.Descendants("img").First();
                string img_src = img_node.GetAttributeValue("src", string.Empty);
                string title = Tuple.Item1.Descendants("a").First().InnerHtml;
                string link = Tuple.Item1.Descendants("a").First().GetAttributeValue("href", string.Empty);
                string title_extension = Tuple.Item1.InnerText;
                IMDB_SearchResult searchResult = new IMDB_SearchResult()
                {
                    IMG = img_src,
                    Title = title,
                    IMDB_TITLE_URL = link,
                    TitleExtension = title_extension
                };
                search_results.Add(searchResult);

            }

            

            return search_results;
        }

        public String FormatURL(String Search)
        {
            //https://www.imdb.com/find?q=hello+world&s=tt&ref_=fn_al_tt_mr
            Search = Search.Replace(" ", "+");
            Search = "https://www.imdb.com/find?q=" + Search + "&s=tt&ref_=fn_al_tt_mr";
            return Search;
        }

        public HtmlDocument Get_Document(String URL)
        {
            HtmlDocument document = new HtmlDocument();
            try
            {
                HtmlWeb web = new HtmlWeb();
                document = web.Load(URL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return document;
        }

    }
}
