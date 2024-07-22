using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace income_and_expense_tracker
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-B67GD14I\SQLEXPRESS;Initial Catalog=expencedb;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register reg=new Register();
            reg.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            try

            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Field Cannot be Null", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else{String selectdata = "SELECT * FROM  registertab where username=@username and password=@password";
                    using (SqlCommand cmd = new SqlCommand(selectdata, con))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", textBox2.Text);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Login Success", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Mainform mn = new Mainform();
                            mn.Show();
                        }


                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Faild Connection" + ex, "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            finally { con.Close(); }

            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}
