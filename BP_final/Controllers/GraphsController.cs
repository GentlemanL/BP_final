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
            //var graph = new List<Graph>
            //{
            //    new Graph() {SomeValue = "something1", SomeValue2 = 27},
            //    new Graph() {SomeValue = "something2", SomeValue2 = 34},
            //    new Graph() {SomeValue = "something3", SomeValue2 = 55},
            //    new Graph() {SomeValue = "something4", SomeValue2 = 21},
            //    new Graph() {SomeValue = "something5", SomeValue2 = 35}
            //};

            //var graph2 = new List<Graph>
            //{
            //    new Graph() {SomeValue = "something6", SomeValue2 = 65},
            //    new Graph() {SomeValue = "something7", SomeValue2 = 37},
            //    new Graph() {SomeValue = "something8", SomeValue2 = 82},
            //    new Graph() {SomeValue = "something9", SomeValue2 = 22},
            //    new Graph() {SomeValue = "something10", SomeValue2 = 1}
            //};

            var graph3 = new List<Graph>
            {
                new Graph() {SomeValue = "2008", SomeValue2 = 1, SomeValue3 = 40},
                new Graph() {SomeValue = "2008", SomeValue2 = 2, SomeValue3 = 53},
                new Graph() {SomeValue = "2008", SomeValue2 = 3, SomeValue3 = 46},
                new Graph() {SomeValue = "2008", SomeValue2 = 4, SomeValue3 = 45},
                new Graph() {SomeValue = "2008", SomeValue2 = 5, SomeValue3 = 67},
                new Graph() {SomeValue = "2008", SomeValue2 = 6, SomeValue3 = 7},
                new Graph() {SomeValue = "2008", SomeValue2 = 7, SomeValue3 = 12},
                new Graph() {SomeValue = "2009", SomeValue2 = 1, SomeValue3 = 35},
                new Graph() {SomeValue = "2009", SomeValue2 = 2, SomeValue3 = 41},
                new Graph() {SomeValue = "2009", SomeValue2 = 3, SomeValue3 = 67},
                new Graph() {SomeValue = "2009", SomeValue2 = 4, SomeValue3 = 32},
                new Graph() {SomeValue = "2009", SomeValue2 = 5, SomeValue3 = 68},
                new Graph() {SomeValue = "2009", SomeValue2 = 6, SomeValue3 = 22},
                new Graph() {SomeValue = "2009", SomeValue2 = 7, SomeValue3 = 13},
                new Graph() {SomeValue = "2010", SomeValue2 = 1, SomeValue3 = 2},
                new Graph() {SomeValue = "2010", SomeValue2 = 2, SomeValue3 = 14},
                new Graph() {SomeValue = "2010", SomeValue2 = 3, SomeValue3 = 68},
                new Graph() {SomeValue = "2010", SomeValue2 = 4, SomeValue3 = 111},
                new Graph() {SomeValue = "2010", SomeValue2 = 5, SomeValue3 = 45},
                new Graph() {SomeValue = "2010", SomeValue2 = 6, SomeValue3 = 83},
                new Graph() {SomeValue = "2010", SomeValue2 = 7, SomeValue3 = 22},
            };

            var xColumnNames = graph3.Select(i => i.SomeValue2.ToString()).Distinct().ToArray(); //year, month, ...
            var graphNames = graph3.Select(i => i.SomeValue.ToString()).Distinct().ToArray(); //year, month, ...
            List<object[]> graphValues = new List<object[]>();

            foreach (var gn in graphNames)
            {
                var something = graph3.Where(i => i.SomeValue == gn).Select(i => new object[] { i.SomeValue3 }).ToArray();
                graphValues.Add(something);
            }

            //for (int i = 0; i < graphNames.Count(); i++)
            //{
            //    object[] o = new object[xColumnNames.Count()];
            //    for (int j = 0; j < xColumnNames.Count(); j++)
            //    {
            //            //o[j] = graph3[j + i * j].SomeValue2 == j + 1 ? graph3[j + i * j].SomeValue3 : 0;
            //    }    
            //    graphValues.Add(o);
            //}

            List<Series> graphSeries = new List<Series>();
            int q = 0;
            foreach (var gv in graphValues)
            {
                graphSeries.Add(new Series { Name = graphNames[q], Data = new Data(gv) });
                q++;
            }




            var ySomeValue2 = graph3.Select(i => new object[] { i.SomeValue2 }).Distinct().ToArray(); // value
            var ySomeValue3 = graph3.Select(i => new object[] { i.SomeValue3 }).ToArray(); // value

            var columnChart = new Highcharts("columnChart")
                .InitChart(new Chart{DefaultSeriesType = ChartTypes.Column})
                .SetTitle(new Title {Text = "Demno Column Chart"})
                .SetXAxis(new XAxis {Categories = xColumnNames})
                .SetYAxis(new YAxis {Title = new YAxisTitle {Text = "y axis something"}, Min = 0})
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn
                    {
                        //check this 
                        DataLabels = new PlotOptionsColumnDataLabels
                        {
                            Enabled = true
                        },
                        EnableMouseTracking = false
                    }
                })
                .SetSeries(graphSeries.ToArray());

            var chart = new Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                .SetTitle(new Title { Text = "Demo chart" })
                .SetSubtitle(new Subtitle { Text = "Demo subtitle" })
                //x values
                .SetXAxis(new XAxis { Categories = xColumnNames })
                //y stuff
                .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Y axis title" }, Min = 0 })
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
                        EnableMouseTracking = false
                    }
                })
                .SetSeries(graphSeries.ToArray());
                //.SetSeries(new[]
                //{
                //    new Series {Name = "SOMEHTING", Data = new Data(list)}
                //    //new Series {Name = "SOMEHTING_ELSE", Data = new Data(ySomeValue3)},
                //});

            ChartsModel model = new ChartsModel();
            model.Charts = new List<Highcharts>();

            model.Charts.Add(chart);
            model.Charts.Add(columnChart);

            //List<Highcharts> loc = new List<Highcharts>();
            //loc.Add(chart);
            //loc.Add(columnChart);

            // Line chart function to be

            //var xSomeValue1 = graph.Select(i => i.SomeValue).ToArray(); //year, month, ...
            //var ySomeValue2 = graph.Select(i => new object[] { i.SomeValue2 }).ToArray(); // value
            //var ySomeValue3 = graph2.Select(i => new object[] { i.SomeValue2 }).ToArray(); // value

            //var chart = new Highcharts("chart")
            //    .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
            //    .SetTitle(new Title { Text = "Demo chart" })
            //    .SetSubtitle(new Subtitle { Text = "Demo subtitle" })
            //    //x values
            //    .SetXAxis(new XAxis { Categories = xSomeValue1 })
            //    //y stuff
            //    .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Y axis title" }, Min = 0 })
            //    .SetTooltip(new Tooltip
            //    {
            //        Enabled = true,
            //        //check what this does
            //        Formatter = @"function() {return '<b>' + this.series.name + '</b><br/>' + this.x + ': ' + this.y; }"
            //    })
            //    //check this 
            //    .SetPlotOptions(new PlotOptions
            //    {
            //        //check this 
            //        Line = new PlotOptionsLine
            //        {
            //            //check this 
            //            DataLabels = new PlotOptionsLineDataLabels
            //            {
            //                Enabled = true
            //            },
            //            EnableMouseTracking = false
            //        }
            //    })
            //    .SetSeries(new[]
            //    {
            //        new Series {Name = "SOMEHTING", Data = new Data(ySomeValue2)},
            //        new Series {Name = "SOMEHTING_ELSE", Data = new Data(ySomeValue3)},
            //    });

            return View(model);
        }
    }
}