using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BP_final.Models;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace BP_final.Controllers
{
    public class GraphsController : Controller
    {
        public ActionResult Index()
        {
            var graph = new List<Graph>
            {
                new Graph() {SomeValue = "something1", SomeValue2 = 27},
                new Graph() {SomeValue = "something2", SomeValue2 = 34},
                new Graph() {SomeValue = "something3", SomeValue2 = 55},
                new Graph() {SomeValue = "something4", SomeValue2 = 21},
                new Graph() {SomeValue = "something5", SomeValue2 = 35}
            };

            var xSomeValue1 = graph.Select(i => i.SomeValue).ToArray();
            var ySomeValue2 = graph.Select(i => new object[] { i.SomeValue2 }).ToArray();

            var chart = new Highcharts("chart")
                .InitChart(new Chart {DefaultSeriesType = ChartTypes.Line})
                .SetTitle(new Title {Text = "Demo chart"})
                .SetSubtitle(new Subtitle {Text = "Demo subtitle"})
                //x values
                .SetXAxis(new XAxis {Categories = xSomeValue1})
                //y stuff
                .SetYAxis(new YAxis {Title = new YAxisTitle {Text = "Y axis title"}})
                .SetTooltip(new Tooltip
                {
                    Enabled = true,
                    //check what this does
                    Formatter = @"function() {return '<b>' + this.series.name + '</b><br/>' + this.x + ': ' + this.y; }"
                })
                //check this 
                .SetPlotOptions(new PlotOptions
                {
                    //check this 
                    Line = new PlotOptionsLine
                    {
                        //check this 
                        DataLabels = new PlotOptionsLineDataLabels
                        {
                            Enabled = true
                        },
                        //check this 
                        EnableMouseTracking = false
                    }
                })
                .SetSeries(new[]
                {
                    new Series {Name = "SOMEHTING", Data = new Data(ySomeValue2)},
                });

            return View(chart);
        }
    }
}