using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;



namespace income_and_expense_tracker
{
    internal class categorydata
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");

        public int id { get; set; }
        public String category { get; set; }
        public String type { get; set; }
        public String status { get; set; }
        public DateTime date { get; set; }

        public List<categorydata> categoryListdata()
        {
            con.Open();
            List<categorydata> listdata = new List<categorydata>();
            SqlCommand cmd = new SqlCommand("select * from category", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                categorydata cdata = new categorydata();
                {
                    cdata.id = (int)dr["id"];
                    cdata.category = dr["category"].ToString();
                    cdata.type = dr["type"].ToString();
                    cdata.status = dr["status"].ToString();
                    cdata.date = DateTime.Parse(dr["date_created"].ToString());
                    listdata.Add(cdata);

                }
                

            }
           
            con.Close();

            return listdata;
           
        }
        

    }
    }
     
