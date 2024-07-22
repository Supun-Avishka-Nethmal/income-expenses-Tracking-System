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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form1 login=new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fields Cannot be null", "error message", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );

            }

            String username = textBox1.Text;
            SqlCommand cmmd = new SqlCommand("select username from registertab where username=@username ",con);
            cmmd.Parameters.AddWithValue("@username",textBox1.Text);
            SqlDataAdapter da =new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                MessageBox.Show("Username already excist");
            }
            
           
            else
            {
                String password = textBox2.Text;
                String cpassword = textBox3.Text;

                if (password == cpassword)
                {
                   
                    SqlCommand cmd = new SqlCommand("insert into registertab(username,password) values (@username,@password)", con);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    cmd.ExecuteNonQuery();
              
                    MessageBox.Show("Register Success", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    Mainform mn= new Mainform();
                    mn.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password doesn't match", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            con.Close();




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
