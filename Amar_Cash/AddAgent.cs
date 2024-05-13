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
using System.Xml.Linq;

namespace Amar_Cash
{
    public partial class AddAgent : Form
    {
        public AddAgent()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
         
        private void label2_Click(object sender, EventArgs e)
        {

        }
            SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void DisplayAccounts()
        {
            try
            {

                con.Open();
                string strCommand = "Select * From agenttbl";
                SqlCommand objCommand = new SqlCommand(strCommand, con);
                //bind data with  ui
                DataSet objDataSet = new DataSet();
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                dataGridView1.DataSource = objDataSet.Tables[0];
                con.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }

        }
        private void AddAgent_Load(object sender, EventArgs e)
        {
            DisplayAccounts();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            CheckProfit checkProfit = new CheckProfit();
            checkProfit.Show();
            this.Hide();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            AddUserFromAdmin addUser = new AddUserFromAdmin();
            addUser.Show();
            this.Hide();
        }

        private void txtAgentNm_TextChanged(object sender, EventArgs e)
        {

        }

 

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all text fields are not blank
                if (!string.IsNullOrWhiteSpace(txtAgentNm.Text) && !string.IsNullOrWhiteSpace(txtPasAgent.Text) && !string.IsNullOrWhiteSpace(txtMoneyAgent.Text) && !string.IsNullOrWhiteSpace(txtphone.Text))
                {
                    // Create SQL command with parameters to prevent SQL injection
                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AgentTbl] ([AgentName], [AgentPass], [AgentCash], [agentphoneno]) VALUES (@AgentName, @AgentPass, @AgentCash, @AgentPhone)", con);
                    cmd.Parameters.AddWithValue("@AgentName", txtAgentNm.Text);
                    cmd.Parameters.AddWithValue("@AgentPass", txtPasAgent.Text);
                    cmd.Parameters.AddWithValue("@AgentCash", txtMoneyAgent.Text);
                    cmd.Parameters.AddWithValue("@AgentPhone", txtphone.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Add Successfully");
                    DisplayAccounts();
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

        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
