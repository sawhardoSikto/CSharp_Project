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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Amar_Cash
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNumber.Text) && txtGender.SelectedItem != null)
                {
                    SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AccountTbl] ([AccName], [AccPass], [AccPhoneNumber], [AccGender], [AccBalance]) VALUES (@AccName, @AccPass, @AccPhoneNumber, @AccGender, @AccBalance)", con);
                    cmd.Parameters.AddWithValue("@AccName", txtName.Text);
                    cmd.Parameters.AddWithValue("@AccPass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@AccPhoneNumber", txtNumber.Text);
                    cmd.Parameters.AddWithValue("@AccGender", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AccBalance", 0);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registration Successful");
                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                
            }
        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNumber.Text) && txtGender.SelectedItem != null)
                {
                    SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AccountTbl] ([AccName], [AccPass], [AccPhoneNumber], [AccGender], [AccBalance]) VALUES (@AccName, @AccPass, @AccPhoneNumber, @AccGender, @AccBalance)", con);
                    cmd.Parameters.AddWithValue("@AccName", txtName.Text);
                    cmd.Parameters.AddWithValue("@AccPass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@AccPhoneNumber", txtNumber.Text);
                    cmd.Parameters.AddWithValue("@AccGender", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AccBalance", 0);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registration Successful");
                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();  
                form.ShowDialog();  
        }
    }
}
