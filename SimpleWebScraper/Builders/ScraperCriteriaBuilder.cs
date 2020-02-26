using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Builders
{
    class ScraperCriteriaBuilder
    {
        //public string Data { get; set; }
        //public string Regex { get; set; }
        //public RegexOptions RegexOption { get; set; }
        //public List<ScraperCriteriaPart> Parts { get; set; }

        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScraperCriteriaPart> _parts;

        public ScraperCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScraperCriteriaPart>();
        }

        public ScraperCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }

        public ScraperCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }
        public ScraperCriteriaBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        public ScraperCriteriaBuilder WithPart(ScraperCriteriaPart scraperCriteriaPart)
        {
            _parts.Add(scraperCriteriaPart);
            return this;
        }
        public ScraperCriteria Build()
        {
            ScraperCriteria scraperCriteria = new ScraperCriteria();
            scraperCriteria.Data = _data;
            scraperCriteria.Regex = _regex;
            scraperCriteria.RegexOption = _regexOption;
            scraperCriteria.Parts = _parts;
            return scraperCriteria;

        }
    }
    
}
