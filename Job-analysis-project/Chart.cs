using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job_analysis_project
{
    /// <summary>
    /// Receive statistical data and generate a chart.
    /// </summary>
    class Chart
    {
        public string ChartHTML { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Statistics Statistics { get; set; }
        public Chart(Statistics stat)
        {
            Statistics = stat;
        }
 
        public void GenerateSVG()
        {
            int jobCount = Statistics.GetCount();
            Dictionary<string, int> dataset = Statistics.statisticalData;
            int width = Width - 100;
            int height = Height - 100;
            int heightIncrement = height / dataset.Count;
            int ypos = 0;
            int fontSize = height / 50;
            int keywordSize = height / 50;
            int maxLength = 0;
            foreach (string key in dataset.Keys)
            {
                if (key.Length > maxLength)
                {
                    maxLength = key.Length;
                }
            }
            string svg = @"<!DOCTYPE html>" + "\n";
            svg += @"<html>" + "\n";
            svg += @"<head>" + "\n";
            svg += @"<meta http-equiv=""X-UA-Compatible"" content=""IE=9""/>" + "\n";
            svg += @"<style>" + "\n";
            svg += @"rect {" + "\n";
            svg += @"fill: steelblue;" + "\n";
            svg += @"}" + "\n";
            svg += @".count {" + "\n";
            svg += @"fill: black;" + "\n";
            svg += @"font: " + fontSize + @"px sans-serif;" + "\n";
            svg += @"text-anchor: end;" + "\n";
            svg += @"}" + "\n";
            svg += @".keyword {" + "\n";
            svg += @"fill: black;" + "\n";
            svg += @"font: " + keywordSize + @"px sans-serif;" + "\n";
            svg += @"}" + "\n";
            svg += @"h1 {" + "\n";
            svg += @"fill: black;" + "\n";
            svg += @"font: " + height / 40 + @"px sans-serif;" + "\n";
            svg += @"}" + "\n";
            svg += @"</style>" + "\n";
            svg += @"</head>" + "\n";
            svg += @"<h1>Job Analysis Chart (Sample: " + jobCount + @")</h1>" + "\n";
            svg += @"<svg class=""chart"" width = """ + width + @""" height = """ + height + @""">" + "\n";
            int widthIncrement = (width - maxLength * keywordSize) / dataset.Values.Max();
            foreach (var key in dataset.Keys)
            {
                svg += @"<g transform=""translate(0, " + ypos + @")"">" + "\n";
                svg += @"<text class=""keyword"" x=""0"" y=""" + (heightIncrement / 2) + @""" dy="".35em"">" + key + @"</text>" + "\n";
                svg += @"</g>" + "\n";
                svg += @"<g transform=""translate(" + (maxLength * keywordSize) + @", " + ypos + @")"">" + "\n";
                svg += @"<rect width=""" + widthIncrement * dataset[key] + @""" height=""" + (heightIncrement - 1) + @"""></rect>" + "\n";
                //svg += @"<text class=""count"" x=""" + (widthIncrement * dataset[key] / 2) + @""" y=""" + (heightIncrement / 2) + @""" dy="".35em"">" + dataset[key] + @"</text>" + "\n";
                svg += @"<text class=""count"" x=""" + (widthIncrement * dataset[key]) + @""" y=""" + (heightIncrement / 2) + @""" dy="".35em"">" + dataset[key] + @"</text>" + "\n";
                svg += @"</g>" + "\n";
                ypos += heightIncrement;
            }
            svg += @"</svg>" + "\n";
            svg += @"</html>" + "\n";
            ChartHTML = svg;
        }
    }
}
