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

namespace Amar_Cash
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdminNm == null)
            {
                MessageBox.Show("please enter username");

            }
            else if (txtadmnpass == null)
            {
                MessageBox.Show("please enter password");

            }
            else
            {
                try
                {
                    this.Hide();
                    SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                    SqlCommand cmd = new SqlCommand("select * from admin where adminname=@adminname and password=@password", con);
                    cmd.Parameters.AddWithValue("@adminname", txtAdminNm.Text);
                    cmd.Parameters.AddWithValue("@password", txtadmnpass.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        Admin admin = new Admin();
                        admin.ShowDialog();





                    }
                    else
                    {
                        MessageBox.Show("invalid username and password");
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(" " + ex);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void txtAdminNm_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (txtAdminNm == null)
            {
                MessageBox.Show("please enter username");

            }
            else if (txtadmnpass == null)
            {
                MessageBox.Show("please enter password");

            }
            else
            {
                try
                {
                    this.Hide();
                    SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                    SqlCommand cmd = new SqlCommand("select * from admin where adminname=@adminname and password=@password", con);
                    cmd.Parameters.AddWithValue("@adminname", txtAdminNm.Text);
                    cmd.Parameters.AddWithValue("@password", txtadmnpass.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        Admin admin = new Admin();
                        admin.ShowDialog();





                    }
                    else
                    {
                        MessageBox.Show("invalid username and password");
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(" " + ex);
                }

            }
        }

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
