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
    public partial class Transfer : Form
    {
        string num;

        public Transfer( string num)
        {
            this.num= num;  
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void UserUpdate()
        {
            SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
            Updatedeposite();
            GetBalance();
            int newbal = balance + Convert.ToInt32(txtamount.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Accounttbl set accbalance=@AB where accphonenumber=@num", con);
            cmd.Parameters.AddWithValue("@AB", newbal);
            cmd.Parameters.AddWithValue("@num", txtaccnumber.Text);
            cmd.ExecuteNonQuery(); // Execute the query
            con.Close();

        }
        public void deposite()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Transaction] ([transactionType], [Tdate], [transactionbalance], [UserAccNo], [agentAccNO], [transactionCode]) VALUES (@transactionType, @Tdate, @transactionbalance, @UserAccNo, @agentAccNO, @transactionCode)", con);
                cmd.Parameters.AddWithValue("@transactionType", "Treanfer Money");
                cmd.Parameters.AddWithValue("@Tdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@transactionbalance", txtamount.Text);
                cmd.Parameters.AddWithValue("@UserAccNo",num);
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
        public void Updatedeposite()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Transaction] ([transactionType], [Tdate], [transactionbalance], [UserAccNo], [agentAccNO], [transactionCode]) VALUES (@transactionType, @Tdate, @transactionbalance, @UserAccNo, @agentAccNO, @transactionCode)", con);
                cmd.Parameters.AddWithValue("@transactionType", "Reacive Money");
                cmd.Parameters.AddWithValue("@Tdate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@transactionbalance", txtamount.Text);
                cmd.Parameters.AddWithValue("@UserAccNo", txtaccnumber.Text);
                cmd.Parameters.AddWithValue("@agentAccNO", num);
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
        private void txtamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaccnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        private void CalculateProfit()
        {
            try
            {
                // Calculate profit as 1% of the transfer amount
                decimal transferAmount = Convert.ToDecimal(txtamount.Text);
                decimal profit = transferAmount * 0.01m;

                // Add profit to admin's account
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Admin SET Profit = Profit + @profit WHERE adminname = @adminPhoneNumber", con);
                cmd.Parameters.AddWithValue("@profit", profit);
                cmd.Parameters.AddWithValue("@adminPhoneNumber", "Admin"); // Replace with admin's phone number
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while calculating profit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        private void checkbalancebtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                // Check if the balance is sufficient for cash out
                GetBalance();
                if (balance == 0 || balance < Convert.ToInt32(txtamount.Text))
                {
                    MessageBox.Show("Insufficient balance for Transfer.");
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
                UserUpdate();
                CalculateProfit();
                MessageBox.Show("Transfer successful");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Optionally, you can log the exception for debugging purposes
                // Logging code can be added here
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            UserHistory userHistory = new UserHistory(num);
            userHistory.Show();
            this.Hide();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

            CashOut cashOut = new CashOut(num);
            cashOut.Show();
            this.Hide();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            Home home = new Home(num);
            home.Show();
            this.Hide();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
