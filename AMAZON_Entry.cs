using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebToolsLMDB
{
    public class AMAZON_Entry
    {
        private string link;
        private string primeVideo;
        private string primeVideoBuy;
        private string bluray;
        private string dvd;
        private string four_K;

        public string PrimeVideo { get => primeVideo; set => primeVideo = value; }
        public string PrimeVideo_Buy { get => primeVideoBuy; set => primeVideoBuy = value; }
        public string Bluray { get => bluray; set => bluray = value; }
        public string DVD { get => dvd; set => dvd = value; }
        public string Four_K { get => four_K; set => four_K = value; }
        public List<Tuple<DateTime, string>> PrimeVideo_History { get => primeVideo_History; set => primeVideo_History = value; }
        public List<Tuple<DateTime, string>> Bluray_History { get => bluray_History; set => bluray_History = value; }
        public List<Tuple<DateTime, string>> DVD_History { get => dVD_History; set => dVD_History = value; }
        public List<Tuple<DateTime, string>> Four_K_History { get => four_K_History; set => four_K_History = value; }
        public string Link { get => link; set => link = value; }

        private List<Tuple<DateTime, String>> primeVideo_History;
        private List<Tuple<DateTime, String>> bluray_History;
        private List<Tuple<DateTime, String>> dVD_History;
        private List<Tuple<DateTime, String>> four_K_History;
    }
}
