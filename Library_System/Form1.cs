using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=AYUSH\\SQLEXPRESS;"+ "Initial Catalog=Liabrary_System;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) // Exception
        {
            try { 
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Username");
            }
            if (this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Password");
            }
            if (this.textBox1.Text.Length == 0 || this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("All Information is Mandatory");
            }
            String UserName = textBox1.Text.ToString();
            String Password = textBox2.Text.ToString();
            con.Open();
                String Qry = "SELECT UserName, Password FROM Register WHERE UserName = '" + UserName + "' AND Password = '" + Password + "'";

                SqlDataAdapter sda = new SqlDataAdapter(Qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Login Successfully: "+UserName);
                    this.Hide();
                Library obj = new Library();
                    obj.Show();
            }
            else
            {
                MessageBox.Show("In valid UserName/Password: " + UserName);
            }
        }
            catch (System.Exception es)
            {
                MessageBox.Show("Error in registration form" + es.ToString());
            }
            con.Close();
            button2_Click(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = " ";
            this.textBox2.Text = " ";   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rg = new Register();
            rg.Show();
        }
    }
}