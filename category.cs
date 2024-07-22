using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace income_and_expense_tracker
{
    public partial class category : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");
        public category()
        {
            InitializeComponent();
            displaycategorydata(); 
        }
        public void displaycategorydata()
        {
            categorydata cdata = new categorydata();
            List<categorydata> listdata = cdata.categoryListdata();

            dataGridView1.DataSource = listdata;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            if (textBox1.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please Fill All Feilds", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into category(category,type,status,date_created) values (@category,@type,@status,@date_created)", con);
                cmd.Parameters.AddWithValue("@category", textBox1.Text);
                cmd.Parameters.AddWithValue("@type", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@status", comboBox2.SelectedItem);

                DateTime today = DateTime.Today;
                cmd.Parameters.AddWithValue("@date_created", today);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            displaycategorydata();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void category_Load(object sender, EventArgs e)
        {
           
        }
        private int getid = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row= dataGridView1.Rows[e.RowIndex];
                getid = Convert.ToInt32(row.Cells[0].Value);
                textBox1.Text= row.Cells[1].Value.ToString();
                comboBox1.SelectedItem= row.Cells[2].Value.ToString();
                comboBox2.SelectedItem = row.Cells[3].Value.ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please Select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update category set category=@cat , type=@type, status=@status where id=@id", con);
                cmd.Parameters.AddWithValue("@id", getid);
                cmd.Parameters.AddWithValue("@cat", textBox1.Text);
                cmd.Parameters.AddWithValue("@type", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@status", comboBox2.SelectedItem);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Update Success", "Success message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            displaycategorydata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select Item first", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("delete category where id=@id",con);
                cmd.Parameters.AddWithValue("@id", getid);
                cmd.ExecuteNonQuery();
              
                MessageBox.Show("Record delete Success", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            displaycategorydata();
        }
    }
}
