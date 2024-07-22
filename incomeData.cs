using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace income_and_expense_tracker
{
    internal class incomeData
    {
        public int Id {  get; set; }
        public String category { get; set; }    
        public String item { get; set; }    
        public String income {  get; set; }
        public String description { get; set; }
        public String DateIncome {  get; set; }

        public List<incomeData> incomeListData()
        {
            List<incomeData> listdata = new List<incomeData>();
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from incomedb", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                incomeData idata = new incomeData();
                idata.Id = (int)reader["id"];
                idata.category = reader["category"].ToString();
                idata.item = reader["item"].ToString();
                idata.income = reader["income"].ToString();
                idata.description= reader["description"].ToString();
                idata.DateIncome=((DateTime) reader["date_income"]).ToString("MM/dd/yyyy");
                listdata.Add(idata);
            }
            
            return listdata;
        }
    }
}
