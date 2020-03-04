using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_analysis_project_console
{
    class Chart_Test
    {
        public void GenerateSVG(string name, int width, int height, Dictionary<string, int> dataset)
        {
            int increment = width / dataset.Count;
            int ypos = 0;
            string svg =
                @"<html>
                  <body>
                    <h1>" + name + @"</h1>";
            svg += @"< svg width = """ + width + @" height = """ + height + @">";
            foreach (var key in dataset.Keys)
            {
                svg += @"<g transform=""translate(0, " + ypos + @")"">";
                svg += @"<rect width=""" + (width / dataset.Values.Max()) * dataset[key] + @" height=""" + (height / dataset.Count - 1) + @"></rect>";
                svg += @"<text x = """ + (width / dataset.Values.Max()) * dataset[key] / 2 + @" y=" + (height / dataset.Count - 0.5) + @" dy = "".35em"">" + dataset[key] + @"</text>";
                svg += @"</g>";
                ypos += height / dataset.Count;
            }
            svg += @"</svg>";
        }
    }
}
