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
    public partial class UserHistory : Form
    {
        string num;
        public UserHistory(string num)
        {
            this.num = num;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

        private void DisplayAccounts()
        {
            try
            {

                con.Open();
                string strCommand = "SELECT [Tid]\r\n      ,[transactionType]\r\n      ,[Tdate]\r\n      ,[transactionbalance]\r\n      ,[UserAccNo]\r\n      ,[agentAccNO]\r\n      ,[transactionCode]\r\n  FROM [dbo].[Transaction] where useraccno='"+num+"' ";
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

        private void UserHistory_Load(object sender, EventArgs e)
        {
            DisplayAccounts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            Home home = new Home(num);
            home.Show();
            this.Hide();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer(num);
            transfer.Show();
            this.Hide();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            CashOut cashOut = new CashOut(num);
            cashOut.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
