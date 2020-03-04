using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Job_analysis_project
{
    /// <summary>
    /// This class will keep the keywords that we defined.
    /// </summary>
    abstract class Job_Dictionary
    {
        struct Keyword
        {
            public string keyword;
            public string regex;
            public Keyword(string key, string regular_expression)
            {
                keyword = key;
                regex = regular_expression;
            }
        }

        private Dictionary<string, int> defList { get; set; }
        
        public List<string> GetKeyWords()
        {
            List<string> keywords = new List<string>();
            foreach (var keyword in defList.Keys)
            {
                keywords.Add(keyword);
            }
            return keywords;
        }

        private static List<Keyword> GetDefinitionList()
        {
            List<Keyword> definitionList = new List<Keyword>();
            definitionList.Add(new Keyword("Node JS", "[^a-z0-9](Node?.JS)[^a-z0-9]"));
            definitionList.Add(new Keyword("Node JS", "[^a-z0-9](Node\\.JS)[^a-z0-9]"));
            definitionList.Add(new Keyword("object oriented", "[^a-z0-9](object.[a-z]+)[^ ]"));
            definitionList.Add(new Keyword("ASP.NET", "[^a-z0-9](ASP.NET)[^a-z0-9]"));
            definitionList.Add(new Keyword(".NET", "[^a-z0-9](.NET)[^a-z0-9]"));
            definitionList.Add(new Keyword("WPF", "[^a-z0-9](WPF)[^a-z0-9]"));
            definitionList.Add(new Keyword("C#", "[^a-z0-9](C#)[^a-z0-9]"));
            definitionList.Add(new Keyword("JAVA", "[^a-z0-9](JAVA)[^a-z0-9]"));
            definitionList.Add(new Keyword("JAVASCRIPT", "[^a-z0-9](JAVASCRIPT)[^a-z0-9]"));
            definitionList.Add(new Keyword("C", "[^a-z0-9](C)[^a-z0-9+#]"));
            definitionList.Add(new Keyword("C++", "[^a-z0-9](C\\++)[^a-z0-9]"));
            definitionList.Add(new Keyword("C++", "[^a-z0-9](CPP)[^a-z0-9]"));
            definitionList.Add(new Keyword("Perl", "[^a-z0-9](Perl)[^a-z0-9]"));
            definitionList.Add(new Keyword("Python", "[^a-z0-9](Python)[^a-z0-9]"));
            definitionList.Add(new Keyword("Bash", "[^a-z0-9](Bash)[^a-z0-9]"));
            definitionList.Add(new Keyword("PowerShell", "[^a-z0-9](PowerShell)[^a-z0-9]"));
            definitionList.Add(new Keyword("Typescript", "[^a-z0-9](Typescript)[^a-z0-9]"));
            definitionList.Add(new Keyword("MVC", "[^a-z0-9](MVC)[^a-z0-9]"));
            definitionList.Add(new Keyword("JSON", "[^a-z0-9](JSON)[^a-z0-9]"));
            definitionList.Add(new Keyword("HTML", "[^a-z0-9](HTML.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("CSS", "[^a-z0-9](CSS)[^a-z0-9]"));
            definitionList.Add(new Keyword("XML", "[^a-z0-9](XML)[^a-z0-9]"));
            definitionList.Add(new Keyword("REST API", "[^a-z0-9](REST API)[^a-z0-9]"));
            definitionList.Add(new Keyword("RESTful API", "[^a-z0-9](RESTful API.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("SOAP", "[^a-z0-9](SOAP)[^a-z0-9]"));
            definitionList.Add(new Keyword("SQL", "[^a-z0-9](SQL)[^a-z0-9]"));
            definitionList.Add(new Keyword("MySQL", "[^a-z0-9](MySQL)[^a-z0-9]"));
            definitionList.Add(new Keyword("TSQL", "[^a-z0-9](TSQL)[^a-z0-9]"));
            definitionList.Add(new Keyword("VBA", "[^a-z0-9](VBA)[^a-z0-9]"));
            definitionList.Add(new Keyword("VBA", "[^a-z0-9](Visual basic.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("Unix", "[^a-z0-9](Unix.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("Linux", "[^a-z0-9](Linux.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("Android", "[^a-z0-9](Android.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("IOS", "[^a-z0-9](IOS.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("AJAX", "[^a-z0-9](AJAX.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("jQuery", "[^a-z0-9](jQuery.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("AngularJS", "[^a-z0-9](AngularJS.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("AngularJS", "[^a-z0-9](Angular.?)[^a-z0-9]"));
            definitionList.Add(new Keyword("ReactJS", "[^a-z0-9](React)[^a-z0-9]"));
            definitionList.Add(new Keyword("ReactJS", "[^a-z0-9](ReactJS)[^a-z0-9]"));
            definitionList.Add(new Keyword("Azure", "[^a-z0-9](Azure)[^a-z0-9]"));
            definitionList.Add(new Keyword("AWS", "[^a-z0-9](AWS)[^a-z0-9]"));
            definitionList.Add(new Keyword("OpenGL", "[^a-z0-9](OpenGL)[^a-z0-9]"));
            definitionList.Add(new Keyword("DirectX", "[^a-z0-9](DirectX)[^a-z0-9]"));
            definitionList.Add(new Keyword("Scala", "[^a-z0-9](Scala)[^a-z0-9]"));
            definitionList.Add(new Keyword("R", "[^a-z0-9](R)[^a-z0-9]"));
            definitionList.Add(new Keyword("Ruby", "[^a-z0-9](Ruby)[^a-z0-9]"));
            definitionList.Add(new Keyword("UI", "[^a-z0-9](UI)[^a-z0-9]"));
            definitionList.Add(new Keyword("UX", "[^a-z0-9](UX)[^a-z0-9]"));
            return definitionList;
        }

        public static Dictionary<string, int> GetResult(string description)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var def in GetDefinitionList())
            {
                int matchCount = (new Regex(def.regex.ToLower())).Matches(description.ToLower()).Count;
                if (result.ContainsKey(def.keyword))
                {
                    result[def.keyword]+= matchCount;
                }
                else
                {
                    if (matchCount!=0)
                        result.Add(def.keyword, matchCount);
                }
            }
            return result;
        }
    }
}
