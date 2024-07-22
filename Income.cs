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
   
    public partial class Income : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");
        public Income()
        {
            InitializeComponent();
            displaydata();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox5.Text=="" || textBox6.Text == "" || textBox7.Text==""|| textBox8.Text == "" || dateTimePicker2.Value == null)
            {
                MessageBox.Show("please Fill all feilds", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SqlCommand cmd = new SqlCommand("insert into incomedb(category,item,income,description,date_income,date_insert) values(@cat,@item,@income,@des,@date_income,@date_insert)", con);
            cmd.Parameters.AddWithValue("@cat",textBox5.Text);
            cmd.Parameters.AddWithValue("@item", textBox6.Text);
            cmd.Parameters.AddWithValue("@income", textBox7.Text);
            cmd.Parameters.AddWithValue("@des", textBox8.Text);
            cmd.Parameters.AddWithValue("@date_income", dateTimePicker2.Value);
            DateTime today = DateTime.Today;
            cmd.Parameters.AddWithValue("@date_insert", today);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Add Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            displaydata();
            con.Close();
        
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            
        }
        public void displaydata()
        {
            incomeData idata = new incomeData();
            List<incomeData> listdata = idata.incomeListData();
          
            dataGridView2.DataSource = listdata;
        }
        public void displaycategorylist()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT category FROM category WHERE type=@type and status= @status ", con);
            cmd.Parameters.AddWithValue("@type", "Income");
            cmd.Parameters.AddWithValue("@status", "Active");
          
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               
            }
            con.Close();
        }

        private void Income_Load(object sender, EventArgs e)
        {
          
            displaycategorylist();
            displaydata();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || dateTimePicker2.Value == null)
            {
                MessageBox.Show("Please Click cell first", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { 
                if(MessageBox.Show("Are You sure want to update data??","Confrim Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("update incomedb set category=@cat, item=@item, income=@income,description=@des,date_income=@date_income,date_insert=@date_insert where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", getid);
                    cmd.Parameters.AddWithValue("@cat", textBox5.Text);
                    cmd.Parameters.AddWithValue("@item", textBox6.Text);
                    cmd.Parameters.AddWithValue("@income", textBox7.Text);
                    cmd.Parameters.AddWithValue("@des", textBox8.Text);
                    cmd.Parameters.AddWithValue("@date_income", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@date_insert", today);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Update Success", "Success message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           
        }
            con.Close();
            displaydata();
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";


        }
        private int getid = 0;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                getid = Convert.ToInt32(row.Cells[0].Value);
                textBox5.Text= row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
                textBox8.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || dateTimePicker2.Value ==null)
            {
                MessageBox.Show("Please Click Cell First","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure delete this record","Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    SqlCommand cmd = new SqlCommand("delete  incomedb where id=@id", con);
                    cmd.Parameters.AddWithValue("@id", getid);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Delete Success", "Success message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
               

            }
            displaydata();
            con.Close();
          
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
