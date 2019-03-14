using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebToolsLMDB
{
    public class WebToolsIMDB
    {
        

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

        public String Get_IMDB_JSON(String URL)
        {
            string JSON = null;
            HtmlDocument doc = Get_Document(URL);
            var scripts = doc.DocumentNode.Descendants("script");
            foreach (var script in scripts)
            {
                if (script.InnerHtml.Contains("http://schema.org"))
                {
                    JSON = script.InnerHtml;
                }
            }
            return JSON;
        }

        public IMDB_Entry Get_IMDB_Entry(String URL)
        {
            string JSON = Get_IMDB_JSON(URL);
            IMDB_Entry entry = new IMDB_Entry();
            List<IMDB_Entry> entries = new List<IMDB_Entry>();
            Dictionary<dynamic, dynamic> JSON_Parsed = new Dictionary<dynamic, dynamic>();
            JSON_Parsed = JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(JSON);
            try
            {
                entry.Type = JSON_Parsed["@type"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Url = JSON_Parsed["url"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Name = JSON_Parsed["name"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Image = JSON_Parsed["image"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Content_rating = JSON_Parsed["contentRating"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Description = JSON_Parsed["description"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Date = JSON_Parsed["datePublished"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                entry.Duration = System.Xml.XmlConvert.ToTimeSpan(JSON_Parsed["duration"]).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                var Rating = JSON_Parsed["aggregateRating"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                IMDB_Rating rating = new IMDB_Rating();
                Dictionary<dynamic, dynamic> Rating_Parsed = new Dictionary<dynamic, dynamic>();
                Rating_Parsed = JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(JSON_Parsed["aggregateRating"].ToString());
                rating.type = Rating_Parsed["@type"];
                rating.Rating_count = Rating_Parsed["ratingCount"];
                rating.Best_Rating = Rating_Parsed["bestRating"];
                rating.Worst_Rating = Rating_Parsed["worstRating"];
                rating.Average_Rating = Rating_Parsed["ratingValue"];
                entry.Rating = rating;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                List<IMDB_Person> actors = new List<IMDB_Person>();
                if (JSON_Parsed["actor"].Count > 1)
                {
                    foreach (var item in JSON_Parsed["actor"])
                    {
                        IMDB_Person person = new IMDB_Person()
                        {
                            Type = item.@type,
                            Name = item.name,
                            Url = item.url
                        };
                        actors.Add(person);
                    }
                }
                else
                {
                    IMDB_Person person = new IMDB_Person()
                    {
                        Type = JSON_Parsed["actor"].@type,
                        Name = JSON_Parsed["actor"].name,
                        Url = JSON_Parsed["actor"].url
                    };
                    actors.Add(person);
                }
                entry.Actors = actors;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                List<IMDB_Person> directors = new List<IMDB_Person>();
                if (JSON_Parsed["director"].Count > 1)
                {
                    foreach (var item in JSON_Parsed["director"])
                    {
                        IMDB_Person person = new IMDB_Person()
                        {
                            Type = item.@type,
                            Name = item.name,
                            Url = item.url
                        };
                        directors.Add(person);
                    }
                }
                else
                {
                    IMDB_Person person = new IMDB_Person()
                    {
                        Type = JSON_Parsed["director"].@type,
                        Name = JSON_Parsed["director"].name,
                        Url = JSON_Parsed["director"].url
                    };
                    directors.Add(person);
                }
                entry.Directors = directors;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                List<IMDB_Person> creators = new List<IMDB_Person>();
                if (JSON_Parsed["creator"].Count > 1)
                {
                    foreach (var item in JSON_Parsed["creator"])
                    {
                        IMDB_Person person = new IMDB_Person()
                        {
                            Type = item.@type,
                            Name = item.name,
                            Url = item.url
                        };
                        creators.Add(person);
                    }
                }
                else
                {
                    IMDB_Person person = new IMDB_Person()
                    {
                        Type = JSON_Parsed["creator"].@type,
                        Name = JSON_Parsed["creator"].name,
                        Url = JSON_Parsed["creator"].url
                    };
                    creators.Add(person);
                }
                entry.Creators = creators;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                List<String> genres = new List<string>();
                foreach (var item in JSON_Parsed["genre"])
                {
                    genres.Add(item.ToString());
                }
                entry.Genre = genres;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                String[] tagss = JSON_Parsed["keywords"].Split(',');
                List<String> tags = new List<string>(tagss);
                entry.Keywords = tags;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
            //Console.WriteLine(JSON_Parsed["trailer"]);
            //Console.WriteLine(JSON_Parsed["review"]);

            return entry;
        }

        public AMAZON_Entry Get_AMAZON_Entry(String URL)
        {
            AMAZON_Entry entry = new AMAZON_Entry()
            {
                Link = URL
            };
            HtmlDocument doc = Get_Document(URL);

            foreach (HtmlNode node in doc.DocumentNode.Descendants("li").Where(d => d.GetAttributeValue("class", "").Contains("swatchElement")))
            {
                HtmlNode node2 = node.Descendants("a").First();
                string x = RemoveEmptyLines(node2.SelectSingleNode("span[1]").InnerText.Replace(" ", ""));
                string y = RemoveEmptyLines(node2.SelectSingleNode("span[2]").InnerText.Replace(" ", ""));
                Console.WriteLine("x: " + x);
                Console.WriteLine("y: " + y);

                if (x.ToLower().Contains("primevideo"))
                {
                    if (y.ToLower().Contains("prime"))
                    {
                        entry.PrimeVideo = y;
                    }
                    else
                    {
                        entry.PrimeVideo_Buy = y;
                    }
                }
                if (x.ToLower().Contains("blu-ray"))
                {
                    entry.Bluray = y;
                }
                if (x.ToLower().Contains("dvd"))
                {
                    entry.DVD = y;
                }

                
            }


            return entry;
        }

        public  string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
        }

    }
}
