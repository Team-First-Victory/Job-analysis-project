using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Net;


namespace Job_analysis_project_console
{
    class Web_Connectors_Test
    {
/*        static void Main(string[] args)
        {
            //Test();
            Web_Connectors_Test wct = new Web_Connectors_Test();
            wct.JobExtractorFromIndeed(50);
            foreach (var key in wct.GetJobList().Keys)
            {
                foreach (var key2 in wct.GetJobList()[key].Keys)
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\elias\Desktop\description.txt", true))
                    {
                        //Console.WriteLine(wct.GetJobList()[key][key2]);
                        file.WriteLine(wct.GetJobList()[key][key2]);
                    }
*//*                    System.IO.File.WriteAllText(@"C:\Users\elias\Desktop\description.txt", wct.GetJobList()[key][key2]);
                    Console.WriteLine(wct.GetJobList()[key][key2]);*//*
                }
            }
        }*/



        private Dictionary<string, Dictionary<string, string>> JobList;

        public Dictionary<string, Dictionary<string, string>> GetJobList()
        {
            return JobList;
        }
        private void JobExtractorFromIndeed(int pageNumber)
        {
            JobList = new Dictionary<string, System.Collections.Generic.Dictionary<string, string>>();
            for (int page = 0; page < pageNumber * 10; page += 10)
            {
                var url = @"https://www.indeed.com/jobs?q=software+engineer&l=";
                if (page > 0)
                {
                    url = @"https://www.indeed.com/jobs?q=software+engineer&start" + page;
                }
                var webGet = new HtmlWeb();
                string prefix = @"https://www.indeed.com/viewjob?jk=";
                if (webGet.Load(url) is HtmlDocument document)
                {
                    var nodes = document.DocumentNode.SelectNodes("//div[contains(@class,'jobsearch-SerpJobCard')]").ToList();
                    foreach (var node in nodes)
                    {
                        Dictionary<string, string> job = new Dictionary<string, string>();
                        string jobid = node.GetAttributeValue("id", "");
                        if (!JobList.ContainsKey(jobid) && jobid.Length!=0)
                        {
                            var datajk = node.GetAttributeValue("data-jk", "");
                            try
                            {
                                
                                var company = node.SelectSingleNode("//*[@id=\"" + jobid + "\"]/div[2]/div[1]/span").InnerText;
                                job.Add("Company", company);
                                var location = node.SelectSingleNode("//*[@id=\"recJobLoc_" + datajk + "\"]").GetAttributeValue("data-rc-loc");
                                job.Add("Location", location);
                                if (company.Trim().ToLower().Contains("seen") && company.Trim().ToLower().Contains("indeed"))
                                {
                                    continue;
                                }
                                else
                                {
                                    var url2 = prefix + datajk;
                                    if (webGet.Load(url2) is HtmlDocument document2)
                                    {
                                        var nodes2 = document2.DocumentNode.SelectNodes("//div[contains(@class,'jobsearch-ViewJobLayout-jobDisplay')]").ToList();
                                        foreach (var node2 in nodes2)
                                        {
                                            var title = node2.SelectSingleNode("//h3[contains(@class,'jobsearch-JobInfoHeader-title')]").InnerText;
                                            job.Add("Title", title);
                                            var detail = node2.SelectSingleNode("//div[contains(@class,'jobDescriptionText')]").InnerText;
                                            job.Add("Detail", detail);
                                            Console.WriteLine(detail);
                                            using (System.IO.StreamWriter file =
new System.IO.StreamWriter(@"C:\Users\elias\Desktop\description.txt", true))
                                            {
                                                //Console.WriteLine(wct.GetJobList()[key][key2]);
                                                file.WriteLine(detail);
                                            }
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }
                            JobList.Add(jobid, job);
                        }
                            

                    }
                }
            }
        }

        private void JobExtractor(int pageNumber)
        {
            for(int page = 0; page < pageNumber*10; page+=10)
            {
                var url = @"https://www.indeed.com/jobs?q=software+engineer&l=";
                if (page > 0)
                {
                    url = @"https://www.indeed.com/jobs?q=software+engineer&start" + page;
                }
                
                var webGet = new HtmlWeb();
                string prefix = @"https://www.indeed.com/viewjob?jk=";
                if (webGet.Load(url) is HtmlDocument document)
                {
                    var nodes = document.DocumentNode.SelectNodes("//div[contains(@class,'jobsearch-SerpJobCard')]").ToList();
                    foreach (var node in nodes)
                    {
                        var jobid = node.GetAttributeValue("id", "");
                        var datajk = node.GetAttributeValue("data-jk", "");
                        Console.WriteLine(jobid);
                        Console.WriteLine(datajk);
                        try
                        {
                            var company = node.SelectSingleNode("//*[@id=\"" + jobid + "\"]/div[2]/div[1]/span").InnerText;
                            var location = node.SelectSingleNode("//*[@id=\"recJobLoc_" + datajk + "\"]").GetAttributeValue("data-rc-loc");
                            if (company.Trim().ToLower().Contains("seen") && company.Trim().ToLower().Contains("indeed"))
                            {
                                continue;
                            }
                            else
                            {
                                var url2 = prefix + datajk;
                                if (webGet.Load(url2) is HtmlDocument document2)
                                {
                                    var nodes2 = document2.DocumentNode.SelectNodes("//div[contains(@class,'jobsearch-ViewJobLayout-jobDisplay')]").ToList();
                                    foreach (var node2 in nodes2)
                                    {
                                        Console.WriteLine(company.Trim());
                                        Console.WriteLine(location.Trim());

                                        var title = node2.SelectSingleNode("//h3[contains(@class,'jobsearch-JobInfoHeader-title')]").InnerText;
                                        Console.WriteLine(title);
                                        var detail = node2.SelectSingleNode("//div[contains(@class,'jobDescriptionText')]").InnerText;
                                        Console.WriteLine(detail);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private static void Test()
        {
            List<string> resultList = new List<string>();
            foreach (var content in JobResult(3))
            {
                resultList.Add(Jobdetail(content));
                Console.WriteLine(content);
            }

            foreach(string result in resultList)
            {
                Console.WriteLine(result);
            }
        }
        private static string Jobdetail(string url)
        {
            string result = null;
            var webGet = new HtmlWeb();
            if (webGet.Load(url) is HtmlDocument document)
            {
                var nodes = document.DocumentNode.CssSelect("div").ToList();
                int count = 0;
                foreach (var node in nodes)
                {
                    result += node.InnerText;
                }
            }
            return result;
        }

        public static List<string> JobResult(int page)
        {
            var url = "https://www.indeed.com/jobs?q=software+engineer&start=";
            List<string> resultPageAddressList = new List<string>();
            List<string> jobDescriptionLinkList = new List<string>();
            resultPageAddressList.Add(url);
            for (int i = 10; i <= page * 10; i = i + 10)
            {
                resultPageAddressList.Add(url + i.ToString());
            }
  
            var urlPrefix = "https://www.indeed.com";
            var webGet = new HtmlWeb();
            foreach (var resultPageAddress in resultPageAddressList)
            {
                if (webGet.Load(resultPageAddress) is HtmlDocument document)
                {
                    var nodes = document.DocumentNode.CssSelect("#resultsCol .title");
                    string hrefStr = @"(href\s*=\s*(?:[""']))(?<1>[^""']*)([""']|(?<1>\S+))";
                    Regex rxHref = new Regex(hrefStr);

                    foreach (var node in nodes)
                    {
                        MatchCollection matches = rxHref.Matches(node.InnerHtml);
                        foreach (Match match in matches)
                        {
                            jobDescriptionLinkList.Add(urlPrefix + match.Groups[1]);
                        }
                    }
                }
            }
            return jobDescriptionLinkList;
        }

/*        private static void JobLists()
        {
            List<string> jobLinks = new List<string>();
            Dictionary<string, Dictionary<String, String>> jobPostingInfo = new Dictionary<string, Dictionary<String, String>>();
            string jobDetail = null;
            string urlPrefix = @"https://www.indeed.com";
            var url = @"https://www.indeed.com/jobs?q=software+engineer&l=";
            //var url = "https://www.indeed.com/jobs?q=software+engineer&l=Washington+State";
            //var url = @"https://www.indeed.com/jobs?q=software%20engineer&l=Washington%20State&advn=1851882598186819&vjk=3dc9e34eed2d42e5";
            string hrefStr = @"(href\s*=\s*(?:[""']))(?<1>[^""']*)([""']|(?<1>\S+))";
            Regex rxHref = new Regex(hrefStr);
            var webGet = new HtmlWeb();
            if (webGet.Load(url) is HtmlDocument document)
            {
                //var nodes = document.DocumentNode.CssSelect("#item-search-results li").ToList();
                //var nodes = document.DocumentNode.CssSelect("#resultsCol").ToList();
                var nodes = document.DocumentNode.CssSelect("#resultsCol .title").ToList();
                //var nodes = document.DocumentNode.SelectNodes("//*[@id=\"resultsCol\"]").CssSelect("div ")

                //  Console.WriteLine(nodes.Count);

                //< div class="jobsearch-SerpJobCard unifiedRow row result" id="pj_ad4dff7956770644" data-jk="ad4dff7956770644" data-empn="210908886952977" data-ci="316220555">
                int count = 0;
                foreach (var node in nodes)
                {
                    string context = node.InnerHtml;
                    MatchCollection matches = rxHref.Matches(context);
                    foreach (Match match in matches)
                    {
                        //Console.WriteLine("{0} : {1}", count++, );
                        jobDetail = urlPrefix + match.Groups[1];
                        jobLinks.Add(jobDetail);
                    }
                }
                Console.WriteLine("Done");
            }
            Console.ReadLine();
        }*/





/*        public void jobp()
        {
            Dictionary<string, List<String>> jobPostingInfo = new Dictionary<string, List<String>>();
            var url = "https://www.indeed.com/jobs?q=software+engineer&l=Washington+State";
            var webGet = new HtmlWeb();
            if (webGet.Load(url) is HtmlDocument document)
            {
                //var nodes = document.DocumentNode.CssSelect("#item-search-results li").ToList();
                var nodes = document.DocumentNode.CssSelect("#resultsCol").ToList();
                //< div class="jobsearch-SerpJobCard unifiedRow row result" id="pj_ad4dff7956770644" data-jk="ad4dff7956770644" data-empn="210908886952977" data-ci="316220555">
                foreach (var node in nodes)
                {
                    string context = node.InnerHtml;
                    string jobKeystr = @"(data-jk="")([A-Za-z0-9]*)("" data-empn="")([A-Za-z0-9]*)("")";
                    Regex rx = new Regex(jobKeystr);
                    MatchCollection matches = rx.Matches(context);
                    foreach (Match match in matches)
                    {
                        string empn = match.Groups[4].ToString();
                        string id = match.Groups[2].ToString();
                        if (!jobPostingInfo.ContainsKey(empn))
                        {
                            jobPostingInfo.Add(empn, new List<string>());
                            jobPostingInfo[empn].Add(id);
                        }
                        else if (jobPostingInfo.ContainsKey(empn) && !jobPostingInfo[empn].Contains(id))
                        {
                            jobPostingInfo[empn].Add(id);
                        }
                    }
                }
            }
            foreach (var empn in jobPostingInfo.Keys)
            {
                foreach (var id in jobPostingInfo[empn])
                    Console.WriteLine("EMPID: {0} Jk : {1}", empn, id);
            }
            Console.ReadLine();
        }*/

        /*static void Main(string[] args)
        {
            Dictionary<string, List<String>> jobPostingInfo = new Dictionary<string, List<String>>();
            List<string> urls = new List<string>();
            var url = "https://www.indeed.com/jobs?q=software+engineer&l=Washington+State";
            var postUrl = @"&start=";
            urls.Add(url);
            for (int i = 10; i < 1000; i = i + 10)
            {
                urls.Add(url + postUrl + i);
            }
            foreach (string address in urls)
            {
                var webGet = new HtmlWeb();
                if (webGet.Load(url) is HtmlDocument document)
                {
                    //var nodes = document.DocumentNode.CssSelect("#item-search-results li").ToList();
                    var nodes = document.DocumentNode.CssSelect("#resultsCol").ToList();
                    //< div class="jobsearch-SerpJobCard unifiedRow row result" id="pj_ad4dff7956770644" data-jk="ad4dff7956770644" data-empn="210908886952977" data-ci="316220555">
                    foreach (var node in nodes)
                    {
                        string context = node.InnerHtml;
                        string jobKeystr = @"(data-jk="")([A-Za-z0-9]*)("" data-empn="")([A-Za-z0-9]*)("")";
                        Regex rx = new Regex(jobKeystr);
                        MatchCollection matches = rx.Matches(context);
                        foreach (Match match in matches)
                        {
                            string empn = match.Groups[4].ToString();
                            string id = match.Groups[2].ToString();
                            if (!jobPostingInfo.ContainsKey(empn))
                            {
                                jobPostingInfo.Add(empn, new List<string>());
                                jobPostingInfo[empn].Add(id);
                            }
                            else if (jobPostingInfo.ContainsKey(empn) && !jobPostingInfo[empn].Contains(id))
                            {
                                jobPostingInfo[empn].Add(id);
                            }
                        }
                    }
                }
                foreach (var empn in jobPostingInfo.Keys)
                {
                    foreach (var id in jobPostingInfo[empn])
                        Console.WriteLine("EMPID: {0} Jk : {1}", empn, id);
                }
            }
            Console.ReadLine();
        }*/
    }
}
