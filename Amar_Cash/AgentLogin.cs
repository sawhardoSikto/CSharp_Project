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
    public partial class AgentLogin : Form
    {
        public AgentLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(agentphoneno.Text))
            {
                MessageBox.Show("Please enter username");
            }
            else if (string.IsNullOrEmpty(txtpass.Text))
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                    con.Open(); // Open the connection

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Agenttbl WHERE agentphoneno=@agentphoneno AND agentpass=@password", con);
                    cmd.Parameters.AddWithValue("@agentphoneno", agentphoneno.Text);
                    cmd.Parameters.AddWithValue("@password", txtpass.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        this.Hide();
                        AgentHome agentHome = new AgentHome(agentphoneno.Text);
                        agentHome.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }

                    reader.Close(); // Close the reader
                    con.Close(); // Close the connection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void AgentLogin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void agentphoneno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(agentphoneno.Text))
            {
                MessageBox.Show("Please enter username");
            }
            else if (string.IsNullOrEmpty(txtpass.Text))
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                    con.Open(); // Open the connection

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Agenttbl WHERE agentphoneno=@agentphoneno AND agentpass=@password", con);
                    cmd.Parameters.AddWithValue("@agentphoneno", agentphoneno.Text);
                    cmd.Parameters.AddWithValue("@password", txtpass.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        this.Hide();
                        AgentHome agentHome = new AgentHome(agentphoneno.Text);
                        agentHome.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }

                    reader.Close(); // Close the reader
                    con.Close(); // Close the connection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
