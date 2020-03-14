using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job_analysis_project
{
    /// <summary>
    /// This class will connect web and retrieve the string data of job.
    /// </summary>
    class Web_Connecter
    {
        private Dictionary<string, Dictionary<string, string>> JobList;

        public Dictionary<string, Dictionary<string, string>> GetJobList(string name, int page=0)
        {
            switch (name.ToLower())
            {
                case "indeed":
                    JobExtractorFromIndeed(page);
                    break;
                default:
                    break;
            }
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
                        var jobid = node.GetAttributeValue("id", "");
                        if (JobList.ContainsKey(jobid))
                        {
                            continue;
                        }
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
                                        var description = node2.SelectSingleNode("//div[contains(@class,'jobDescriptionText')]").InnerText;
                                        job.Add("Description", description);
                                    }
                                }

                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        JobList.Add(jobid, job);
                    }
                }
            }
        }
    }
}
