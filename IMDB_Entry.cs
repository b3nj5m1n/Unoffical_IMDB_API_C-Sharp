using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebToolsLMDB
{
    public class IMDB_Entry
    {
        private string type;
        private string url;
        private string name;
        private string image;
        private List<String> genre;
        private string content_rating;
        private List<IMDB_Person> actors;
        private List<IMDB_Person> directors;
        private List<IMDB_Person> creators;
        private string description;
        private string date;
        private List<String> keywords;
        private IMDB_Rating rating;
        private string duration;

        public string Type { get => type; set => type = value; }
        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public List<string> Genre { get => genre; set => genre = value; }
        public string Content_rating { get => content_rating; set => content_rating = value; }
        public  List<IMDB_Person> Actors { get => actors; set => actors = value; }
        public List<IMDB_Person> Directors { get => directors; set => directors = value; }
        public List<IMDB_Person> Creators { get => creators; set => creators = value; }
        public string Description { get => description; set => description = value; }
        public string Date { get => date; set => date = value; }
        public List<string> Keywords { get => keywords; set => keywords = value; }
        public IMDB_Rating Rating { get => rating; set => rating = value; }
        public string Duration { get => duration; set => duration = value; }
    }
}
