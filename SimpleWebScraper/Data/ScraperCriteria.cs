using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Data
{
    class ScraperCriteria
    {
        public ScraperCriteria()
        {
            Parts = new List<ScraperCriteriaPart>();
        }

        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        public List<ScraperCriteriaPart> Parts { get; set; }
    }
}
