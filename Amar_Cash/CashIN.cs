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
    public partial class CashIN : Form
    {
        string num;
        public CashIN(string num)
        {
            InitializeComponent();
            this.num = num;
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
                cmd.Parameters.AddWithValue("@accPhoneNumber", txtaccnumber.Text);

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
                cmd.Parameters.AddWithValue("@transactionType", "Deposite");
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
                cmd.Parameters.AddWithValue("@accPhoneNumber",num);

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
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
                GetBalanceAgent();

                // Check if the balance is sufficient for cash-out
                

                
                int newbal = balance - Convert.ToInt32(txtamount.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update AgentTbl set agentcash=@AB where agentphoneno=@num", con);
                cmd.Parameters.AddWithValue("@AB", newbal);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating agent's balance: " + ex.Message);
                
            }
        }


        private void CashIN_Load(object sender, EventArgs e)
        {

        }

        private void txtaccnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");

                GetBalance();



                deposite();
                int newbal = balance + Convert.ToInt32(txtamount.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update AccountTbl set accbalance=@AB where accphonenumber=@num", con);
                cmd.Parameters.AddWithValue("@AB", newbal);
                cmd.Parameters.AddWithValue("@num", txtaccnumber.Text);
                cmd.ExecuteNonQuery(); // Execute the query
                AgentUpdate();
                MessageBox.Show("Cash in successful");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            AgentHome agent = new AgentHome(num);
            agent.Show();
            this.Hide();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            ShowComingSoonMessage("Coming soon...");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            agent_cashout agent_Cashout = new agent_cashout();
            agent_Cashout.Show();
            this.Hide();
        }

        public static void ShowComingSoonMessage(string message, int interval = 100)
        {
            // Create a new instance of a MessageBox
            Form messageBoxForm = new Form();
            messageBoxForm.FormBorderStyle = FormBorderStyle.None;
            messageBoxForm.StartPosition = FormStartPosition.CenterScreen;
            messageBoxForm.Size = new System.Drawing.Size(300, 200);

            // Create a panel to act as the message box background
            Panel panel = new Panel();
            panel.BackColor = Color.LightBlue; // Set the background color
            panel.Size = new Size(300, 160);

            // Create a label to display the message
            Label label = new Label();
            label.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;

            // Add the label to the panel
            panel.Controls.Add(label);

            // Add the panel to the form
            messageBoxForm.Controls.Add(panel);

            // Add a button to allow the user to close the message box
            Button closeButton = new Button();
            closeButton.Text = "Close";
            closeButton.Size = new Size(75, 30);
            closeButton.Location = new Point((messageBoxForm.Width - closeButton.Width) / 2, 150);
            closeButton.Click += (sender, e) => { messageBoxForm.Close(); }; // Close the form when the button is clicked
            messageBoxForm.Controls.Add(closeButton);

            // Add a timer to update the label text gradually
            Timer timer = new Timer();
            timer.Interval = interval; // Set the interval for letter display
            int currentIndex = 0; // Track the current index of the message
            timer.Tick += (sender, e) =>
            {
                if (currentIndex < message.Length)
                {
                    label.Text += message[currentIndex]; // Append the next letter
                    currentIndex++;
                }
                else
                {
                    timer.Stop(); // Stop the timer when all letters are displayed
                }
            };
            timer.Start();

            Timer timer1 = new Timer();
            timer1.Interval = 2500; // 2.5 seconds
            timer1.Tick += (sender, e) => { messageBoxForm.Close(); };
            timer1.Start();

            // Show the message box
            messageBoxForm.ShowDialog();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            ShowComingSoonMessage("Coming soon...");
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
