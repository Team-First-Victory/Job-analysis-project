using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job_analysis_project
{
    /// <summary>
    ///  Job Class
    /// </summary>
    class Job
    {
        public string JobID { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
        public Job()
        {
            JobID = "Empty";
            Company = "Empty";
            Location = "Empty";
            Title = "Empty";
            Description = "Empty";
            Keywords = null;
        }
    }
}
