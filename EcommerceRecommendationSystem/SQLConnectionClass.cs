using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EcommerceRecommendationSystem
{
    public class SQLConnectionClass
    {
        SqlConnection SQLConn = new SqlConnection();
        public DataTable SQLTable = new DataTable();
        
        public SQLConnectionClass()
        {
            SQLConn.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        //Retrieve user information from DB
        public void retrieveData(string command)
        {
            try
            {
                SQLConn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command, SQLConn);
                da.Fill(SQLTable);
               
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('something wrong in conn to DB with error : " + ex.Message + "');</script>");
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //Insert data into DB
        public void CommandExec(string command)
        {
            try
            {
                SQLConn.Open();
                SqlCommand sqlconn = new SqlCommand(command, SQLConn);

                int rowInfected = sqlconn.ExecuteNonQuery();
                if (rowInfected > 0)
                {
                    //HttpContext.Current.Response.Write("<script>alert('COMMAND COMPLETE');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('Something goes wrong in DBMS, try again');</script>");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLConn.Close();
            }
        }
    }
}

