using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Builders
{
    class ScraperCriteriaPartBuilder
    {
        private string _regex;
        private RegexOptions _regexOption;

        public ScraperCriteriaPartBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }

        public ScraperCriteriaPartBuilder WithRegex(String regex)
        {
            _regex = regex;
            return this;
        }

        public ScraperCriteriaPartBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        public ScraperCriteriaPart Build()
        {
            ScraperCriteriaPart scraperCriteriaPart = new ScraperCriteriaPart();
            scraperCriteriaPart.Regex = _regex;
            scraperCriteriaPart.RegexOption = _regexOption;
            ///////////////////////////////////
            return scraperCriteriaPart;
        }
    }

    
}
