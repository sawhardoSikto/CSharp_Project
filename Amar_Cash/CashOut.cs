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
    public partial class CashOut : Form
    {
        string num;
        public CashOut(string num)
        {
            InitializeComponent();
            this.num = num;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        int balance;
        private void GetBalance()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                con.Open();
                string query = "SELECT * FROM AccountTbl WHERE accphonenumber = @accPhoneNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@accPhoneNumber", num);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    balance = Convert.ToInt32(dr["accbalance"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string randomDigit()
        {
            Random random = new Random();
            string randomDigits = random.Next(1000, 10000).ToString();

            long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            string uniqueNumber = randomDigits + timestamp;
            return uniqueNumber;
        }
        public void deposite()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Transaction] ([transactionType], [Tdate], [transactionbalance], [UserAccNo], [agentAccNO], [transactionCode]) VALUES (@transactionType, @Tdate, @transactionbalance, @UserAccNo, @agentAccNO, @transactionCode)", con);
                cmd.Parameters.AddWithValue("@transactionType", "Cash Out");
                cmd.Parameters.AddWithValue("@Tdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@transactionbalance", txtamount.Text);
                cmd.Parameters.AddWithValue("@UserAccNo", num);
                cmd.Parameters.AddWithValue("@agentAccNO", txtaccnumber.Text);
                cmd.Parameters.AddWithValue("@transactionCode", randomDigit());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
        }
        private void CashOut_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void GetBalanceAgent()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                con.Open();
                string query = "SELECT * FROM AgentTbl WHERE agentphoneno = @accPhoneNumber";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@accPhoneNumber", txtaccnumber.Text);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    balance = Convert.ToInt32(dr["agentcash"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AgentUpdate()
        {
            SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
            // deposite();
            GetBalanceAgent();
            int newbal = balance + Convert.ToInt32(txtamount.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update AgentTbl set agentcash=@AB where agentphoneno=@num", con);
            cmd.Parameters.AddWithValue("@AB", newbal);
            cmd.Parameters.AddWithValue("@num", txtaccnumber.Text);
            cmd.ExecuteNonQuery(); // Execute the query
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                // Check if the balance is sufficient for cash out
                GetBalance();
                if (balance == 0 || balance < Convert.ToInt32(txtamount.Text))
                {
                    MessageBox.Show("Insufficient balance for cash out.");
                    return;
                }

                // Proceed with cash-out
                deposite();
                int newbal = balance - Convert.ToInt32(txtamount.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update AccountTbl set accbalance=@AB where accphonenumber=@num", con);
                cmd.Parameters.AddWithValue("@AB", newbal);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery(); // Execute the query
                AgentUpdate();
               
                MessageBox.Show("Cash Out successful");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Optionally, you can log the exception for debugging purposes
                // Logging code can be added here
            }
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

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            UserHistory userHistory = new UserHistory(num);
            userHistory.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
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
