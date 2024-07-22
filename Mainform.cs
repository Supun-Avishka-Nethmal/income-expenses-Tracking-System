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
    public partial class Mainform : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");
        public Mainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dsh = new Dashboard();
            dsh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            category cs = new category();
            cs.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure to want to Logout?","Confirmation message",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                Form1 fr = new Form1();
                fr.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();

            if(textBox1.Text==""|| comboBox1.SelectedIndex==-1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please Fill All Feilds", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            SqlCommand cmd = new SqlCommand("insert into category(category,type,status,date_created) values (@category,@type,@status,@date)",con);
            cmd.Parameters.AddWithValue("@category", textBox1.Text);
            cmd.Parameters.AddWithValue("@type", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@status", comboBox2.SelectedItem);

            DateTime date = DateTime.Today;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Income income= new Income();
            income.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Expences expences = new Expences();
            expences.Show();
        }
    }
}
