using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job_analysis_project
{
    /// <summary>
    /// This will receive data and calculate and change to numerical data.
    /// </summary>
    class Statistics
    {
        private int JobCount { get; set; }
        public Dictionary<string, int> statisticalData { get; private set; }

        private List<Dictionary<string, int>> listOfJobDescription = new List<Dictionary<string, int>>();

        public Statistics(List<Job> jobList)
        {
            statisticalData = new Dictionary<string, int>();
            Generate(jobList);
            JobCount = GetCount();
            
        }

        private void Generate(List<Job> jobList)
        {
            foreach (var job in jobList)
            {
                if (job.Stat.Count != 0)
                {
                    AddJobs(job.Stat);
                    JobCount++;
                }
            }
        }

        private void AddJobs(Dictionary<string, int> jobResult)
        {
            foreach(string keyword in jobResult.Keys)
            {
                if (statisticalData.ContainsKey(keyword))
                {
                    statisticalData[keyword] = statisticalData[keyword] + jobResult[keyword];
                }
                else
                {
                    statisticalData.Add(keyword, jobResult[keyword]);
                }
            }
        }

        public Dictionary<string, int> GetStatisticalData()
        {
            return statisticalData;
        }

        public int GetCount()
        {
            return JobCount;
        }
    }
}
