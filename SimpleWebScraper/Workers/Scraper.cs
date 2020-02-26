using SimpleWebScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Workers
{
    class Scraper
    {
        public List<string> Scrape(ScraperCriteria scraperCriteria)
        {
            List<string> scrappedElements = new List<string>();

            MatchCollection matches = Regex.Matches(scraperCriteria.Data, scraperCriteria.Regex, scraperCriteria.RegexOption);

            foreach (Match match in matches)
            {
                if (!scraperCriteria.Parts.Any())
                {
                    scrappedElements.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scraperCriteria.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);

                        if (matchedPart.Success)
                        {
                            scrappedElements.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }



            return scrappedElements;
        }
    }
}
