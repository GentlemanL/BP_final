using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BP_final.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Graph { get; set; }
        public string SqlInput { get; set; }
        public bool IsChecked{ get; set; }
    }

    public class ReportDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
    }
}