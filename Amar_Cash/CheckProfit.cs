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
    public partial class CheckProfit : Form
    {
        public CheckProfit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

        private void DisplayAccounts()
        {
            try
            {

                con.Open();
                string strCommand = "SELECT [AdminID]\r\n      ,[Password]\r\n      ,[Profit]\r\n      ,[AdminName]\r\n  FROM [dbo].[Admin]\r\n ";
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

        private void CheckProfit_Load(object sender, EventArgs e)
        {
            DisplayAccounts();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            AddUserFromAdmin addUser = new AddUserFromAdmin();
            addUser.Show();
            this.Hide();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            AddAgent addAgent = new AddAgent();
            addAgent.Show();
            this.Hide();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
