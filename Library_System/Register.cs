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

namespace Library_System
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection("Data Source=AYUSH\\SQLEXPRESS;"+ "Initial Catalog=Liabrary_System;Integrated Security=True;");
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
           
            try {
                    con.Open();

                String Uniqueid = textBox1.Text;
                String Name = textBox2.Text;

                String Designation = comboBox1.SelectedItem.ToString();
                String Department =comboBox2.SelectedItem.ToString();
                
                String MoNo = textBox3.Text;
                long iMoNo = Int64.Parse(textBox3.Text);

                String Email = textBox4.Text;
                String UserName = textBox5.Text;
                String Password = textBox6.Text;


                String Qry = "insert into Register(Uniqueid,Name,Designation,Department,MoNo,Email,UserName,Password) values ('" + Uniqueid +"','"+ Name + "','"+ Designation + "','"+ Department + "',"+ iMoNo + ",'"+ Email + "','"+ UserName + "','"+ Password + "')";

                SqlCommand cmd = new SqlCommand(Qry,con);

               int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Number of user register with Username" + UserName);
                }
                else
                {
                    MessageBox.Show("User registeraton failed with Username" + UserName);
                }
                
                button2_Click(sender, e);
                   
                } 
            
            catch (System.Exception es)
            {
                MessageBox.Show("Error in registration form"+ es.ToString());
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.comboBox1.SelectedIndex = -1;
            this.comboBox2.SelectedIndex = -1;
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        
    }
}
