using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace income_and_expense_tracker
{
    public partial class Dashboard : Form
    {
       SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");
        public Dashboard()
        {
            InitializeComponent();
            todayincome();
            yesterdayincome();
            lastmonthincome();
            lastyearincome();
            todayexpence();
            yesterdayexpence();
            lastmonthexpences();
            lastyearexpences();
            totalincome();
            totalexpence();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        public void todayincome()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select  SUM(income) from incomedb where date_income=@date ", con);
            DateTime today = DateTime.Today;
        
            cmd.Parameters.AddWithValue("@date", today);
            
            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {

                decimal todaycost = Convert.ToDecimal(result);
                label5.Text = todaycost.ToString("C");

            }
            else
            {
                label5.Text= "$0.00";
            }
            con.Close();

        }
         public void yesterdayincome()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SUM(income) from incomedb where CONVERT(DATE,date_income)=DATEADD(day,-1,DATEDIFF(day,0,GETDATE()))", con);

          
            object result= cmd.ExecuteScalar();
            if(result != DBNull.Value)
            {
                decimal yesterdayincome= Convert.ToDecimal(result);
                label8.Text= yesterdayincome.ToString("C");
            }
            else
            {
                label8.Text = "$0.00";
            }
            con.Close();
        }

        public void lastmonthincome()
        {
            con.Open();
            DateTime today = DateTime.Now.Date;
            DateTime startmonth = new DateTime(today.Year, today.Month, 1);
            DateTime endmonth = startmonth.AddMonths(1).AddDays(-1);

            SqlCommand cmd = new SqlCommand("select SUM(income) from incomedb where date_income >= @startmonth AND date_income <= @endmonth", con);
            cmd.Parameters.AddWithValue("@startmonth", startmonth);
            cmd.Parameters.AddWithValue("@endmonth", endmonth);


            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                decimal lastmonthicome = Convert.ToDecimal(result);
                label10.Text = lastmonthicome.ToString("C");
            }
            else
            {
                label10.Text = "$0.00";
            }
            con.Close();
        }

        public void lastyearincome()
        {
            con.Open();
            DateTime today = DateTime.Now.Date;
            DateTime startyear = new DateTime(today.Year,1,1);
            DateTime endyear= startyear.AddYears(1).AddMonths(0).AddDays(-1);
            SqlCommand cmd = new SqlCommand("select SUM(income) from incomedb where date_income >= @startyear and date_income <=@endyear",con);
            cmd.Parameters.AddWithValue("@startyear", startyear);
            cmd.Parameters.AddWithValue("@endyear", endyear);

            object resultnew = cmd.ExecuteScalar();
            if (resultnew != DBNull.Value)
            {
                decimal lastyearincome= Convert.ToDecimal(resultnew);
                label12.Text = lastyearincome.ToString("C");
            }
            else
            {
                label12.Text = "$0.00";
            }
            con.Close();
        }
        public void todayexpence()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select  SUM(cost) from expences where date_expence=@date ", con);
            DateTime today = DateTime.Today;

            cmd.Parameters.AddWithValue("@date", today);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {

                decimal todaycost = Convert.ToDecimal(result);
                label20.Text = todaycost.ToString("C");

            }
            else
            {
                label20.Text = "$0.00";
            }
            con.Close();

        }
        public void yesterdayexpence()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SUM(cost) from expences where CONVERT(DATE,date_expence)=DATEADD(day,-1,DATEDIFF(day,0,GETDATE()))", con);


            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                decimal yesterdayincome = Convert.ToDecimal(result);
                label17.Text = yesterdayincome.ToString("C");
            }
            else
            {
                label17.Text = "$0.00";
            }
            con.Close();
        }
        public void lastmonthexpences()
        {
            con.Open();
            DateTime today = DateTime.Now.Date;
            DateTime startmonth = new DateTime(today.Year, today.Month, 1);
            DateTime endmonth = startmonth.AddMonths(1).AddDays(-1);

            SqlCommand cmd = new SqlCommand("select SUM(cost) from expences where date_expence >= @startmonth AND date_expence <= @endmonth", con);
            cmd.Parameters.AddWithValue("@startmonth", startmonth);
            cmd.Parameters.AddWithValue("@endmonth", endmonth);


            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                decimal lastmonthicome = Convert.ToDecimal(result);
                label15.Text = lastmonthicome.ToString("C");
            }
            else
            {
                label15.Text = "$0.00";
            }
            con.Close();
        }
        public void lastyearexpences()
        {
            con.Open();
            DateTime today = DateTime.Now.Date;
            DateTime startyear = new DateTime(today.Year, 1, 1);
            DateTime endyear = startyear.AddYears(1).AddMonths(0).AddDays(-1);
            SqlCommand cmd = new SqlCommand("select SUM(cost) from expences where date_expence >= @startyear and date_expence <=@endyear", con);
            cmd.Parameters.AddWithValue("@startyear", startyear);
            cmd.Parameters.AddWithValue("@endyear", endyear);

            object resultnew = cmd.ExecuteScalar();
            if (resultnew != DBNull.Value)
            {
                decimal lastyearincome = Convert.ToDecimal(resultnew);
                label13.Text = lastyearincome.ToString("C");
            }
            else
            {
                label13.Text = "$0.00";
            }
            con.Close();
        }

        public void totalincome()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SUM(income) from income ",con);
             
            object result= cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                decimal totalincome= Convert.ToDecimal(result);
                label22.Text = totalincome.ToString("c");

            }
            else
            {
                label22.Text = "$0.00";
            }
            con.Close();
        }
        public void totalexpence()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SUM(cost) from expences ", con);

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                decimal totalexpence = Convert.ToDecimal(result);
                label24.Text = totalexpence.ToString("c");

            }
            else
            {
                label24.Text = "$0.00";
            }
            con.Close() ;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            todayincome();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
