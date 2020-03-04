using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job_analysis_project
{
    /// <summary>
    /// This class will keep the keywords that we defined.
    /// </summary>
    class Job_Dictionary
    {
        private List<string> definitionList = new List<string>();
        public List<string> GetKeyWords(string Description)
        {
            List<string> keywords = new List<string>();
            foreach (var keyword in definitionList)
            {
                if (Description.ToLower().Contains(keyword.ToLower()))
                {
                    keywords.Add(keyword);
                }
            }
            return keywords;
        }
    }
}
