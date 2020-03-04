using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Job_analysis_project_console
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
    abstract class Job_Dictionary_Test
    {
        /*static void Main(string[] args)
        {
            string test = "ention object oriented to detail while working with multiple systems and applications you supportA working knowledge of object-oriented programming object oriented";
            Job_Dictionary_Test jdt = new Job_Dictionary_Test();
            Dictionary<string, int> r = jdt.GetResult(test);
            foreach (var x in r.Keys)
            {
                Console.WriteLine($"{x} has {r[x]} times");
            }
        }*/

        private List<Keyword> GetDefinitionList()
        {
            List<Keyword> definitionList = new List<Keyword>();
            definitionList.Add(new Keyword("object oriented", "object.[A-Za-z]+[^ ]"));
            return definitionList;
        }

        public Dictionary<string, int> GetResult(string description)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var def in GetDefinitionList())
            {
                result.Add(def.keyword, (new Regex(def.regex)).Matches(description).Count);
            }
            return result;
        }
    }
}
