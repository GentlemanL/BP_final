using DotNet.Highcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP_final.Models
{
    public class Graph
    {
        public string SomeValue { get; set; }
        public int SomeValue2 { get; set; }
        public int SomeValue3 { get; set; }

    }
    public class ChartsModel
    {
        public List<Highcharts> Charts { get; set; }
    }
}