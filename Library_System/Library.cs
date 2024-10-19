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
namespace Library_System
{
    public partial class Library : Form
    {
        SqlConnection con = new SqlConnection("Data Source=AYUSH\\SQLEXPRESS;"+ "Initial Catalog=Liabrary_System;Integrated Security=True;");
        public Library()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = " ";
            this.textBox2.Text = " ";
            this.textBox3.Text = " ";   
            this.textBox4.Text = " ";
            this.textBox10.Text = " ";
            this.textBox11.Text = " ";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                String ISBN = textBox1.Text.ToString();
                String Book_Name = textBox2.Text.ToString();
                String Subject = textBox3.Text.ToString();                
                String Author = textBox4.Text.ToString();              
                String price = textBox10.Text.ToString();
                float iPrice = float.Parse(price);

                String qry = "insert into Book_Info values ('" + ISBN + "','" + Book_Name + "','" + Subject + "','" + Author + "'," + iPrice + ")";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Book Registerd Successfully : " + ISBN);
                    show();
                }
                else
                {
                    MessageBox.Show("Book Not Registerd : ");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
            }
            con.Close();
        }
        //Grid Box Start 
        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Book_Info",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows) { 
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
            }
        }
        // Grid  Box End
        //update Button Start
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String ISBN = textBox1.Text.ToString();
                String BookName = textBox2.Text.ToString();

                String Subject = textBox3.Text.ToString();

                String Author = textBox4.Text.ToString();
                String price = textBox10.Text.ToString();
                float iPrice = float.Parse(price);
                String qry = "update Book_Info set BookName='" + BookName + "',Price= " + iPrice + ", Subject = " + Subject + ",Author= '" + Author + "' Where  ISBN='" + ISBN + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Update Successfully" + ISBN);
                }
                else
                {
                    MessageBox.Show("Not Update");
                }
            }
            catch (SystemException es)
            {
                MessageBox.Show("Error is : " + es.ToString());
            }
            con.Close();
        }
        //Update Buttion End
        //Delete Button Start
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String ISBN = textBox1.Text.ToString();
                String qry = "delete from Book_Info where ISBN ='" + ISBN + "'";

                SqlCommand sc = new SqlCommand(qry, con);

                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Delete Successfully" + ISBN);
                }
                else
                {
                    MessageBox.Show("Not Delete");
                }
            }
            catch (SystemException es)
            {
                MessageBox.Show("Error is : " + es.ToString());
            }
            con.Close();
        }
        //Delete Bution
    }
    }