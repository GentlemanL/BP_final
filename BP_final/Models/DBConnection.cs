using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BP_final.Models
{
    public class DBConnection
    {
        protected SqlConnection con;

        //open ocnnection
        public bool Open(string Connection = "DefaultConnection2")
        {
            con = new SqlConnection(@WebConfigurationManager.ConnectionStrings[Connection].ToString());
            try
            {
                if(con.State.ToString() != "Open")
                {
                    con.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        //close connection
        
        public bool Close()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
