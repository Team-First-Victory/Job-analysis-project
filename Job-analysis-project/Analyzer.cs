using System;
using System.Collections.Generic;
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
        Dictionary<string, Job> JobLists = new Dictionary<string, Job>();
        readonly Job_Dictionary jd = new Job_Dictionary();
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
        private void GenerateJobLists()
        {
            Web_Connecter indeed = new Web_Connecter();
            result = indeed.GetJobList("indeed", 2);
            foreach (string jobID in result.Keys)
            {
                JobLists.Add(jobID, new Job()
                {
                    JobID = jobID,
                    Company = result[jobID]["Company"],
                    Location = result[jobID]["Location"],
                    Title = result[jobID]["Title"],
                    Description = result[jobID]["Description"],
                    Keywords = jd.GetKeyWords(result[jobID]["Description"])
                });
            }
        }
    }
}
