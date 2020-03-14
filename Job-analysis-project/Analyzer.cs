using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Job_analysis_project
{
    /// <summary>
    /// This is a main class.
    /// need to call web connect to retrieve data,
    /// pass the data to statistics, and retrieve the statistical data
    /// pass it to chart to generate a chart.
    /// </summary>
    class Analyzer
    {
        public Chart Chart { get; set; }
        public Statistics Statistics { get; set; }
        Dictionary<string, Job> JobLists = new Dictionary<string, Job>();
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
        private void GenerateJobLists()
        {
            Web_Connecter indeed = new Web_Connecter();
            result = indeed.GetJobList("indeed", 5);
            foreach (string jobID in result.Keys)
            {
                JobLists.Add(jobID, new Job()
                {
                    JobID = jobID,
                    Company = result[jobID]["Company"],
                    Location = result[jobID]["Location"],
                    Title = result[jobID]["Title"],
                    Description = result[jobID]["Description"],
                    Stat = Job_Dictionary.GetResult(result[jobID]["Description"])
                });
                /*string path = @"C:\Users\elias\Desktop\test.txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(result[jobID]["Description"]);
                    }
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(result[jobID]["Description"]);
                }*/
            }
        }

        private void GenerateStatisticalDataSet()
        {
            Statistics = new Statistics(JobLists.Values.ToList());
        }

        private void GenerateChart(int width, int height)
        {
            Chart = new Chart(Statistics)
            {
                Height = height,
                Width = width
            };
            Chart.GenerateSVG();
        }

        public void Analyze(int width, int height)
        {
            
            GenerateJobLists();
            GenerateStatisticalDataSet();
            GenerateChart(width, height);
        }
    }
}
