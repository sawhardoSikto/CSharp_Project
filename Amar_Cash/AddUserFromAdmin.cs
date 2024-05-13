using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Amar_Cash
{
    public partial class AddUserFromAdmin : Form
    {
        private readonly SqlConnection con = new SqlConnection("Data Source=HPENVY-X360-13\\SQLEXPRESS;Initial Catalog=Amar_Cash;Integrated Security=True;");
        private int key = 0;

        public AddUserFromAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DisplayAccounts()
        {
            try
            {
                con.Open();
                string strCommand = "SELECT * FROM AccountTbl";
                SqlCommand objCommand = new SqlCommand(strCommand, con);
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

        private void AddUserFromAdmin_Load(object sender, EventArgs e)
        {
            DisplayAccounts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.SelectedRows[0].Cells["AccName"].Value.ToString();
            txtNumber.Text = dataGridView1.SelectedRows[0].Cells["AccPhoneNumber"].Value.ToString();
            txtGender.SelectedItem = dataGridView1.SelectedRows[0].Cells["AccGender"].Value.ToString();
            txtPass.Text = dataGridView1.SelectedRows[0].Cells["AccPass"].Value.ToString();
            key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AccPhoneNumber"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void reset()
        {
            txtName.Text = "";
            txtGender.SelectedIndex = -1;
            txtNumber.Text = "";
            txtPass.Text = "";
            key = 0;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            CheckProfit checkProfit = new CheckProfit();
            checkProfit.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNumber.Text) && txtGender.SelectedItem != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO AccountTbl (AccName, AccPass, AccPhoneNumber, AccGender, AccBalance) VALUES (@AccName, @AccPass, @AccPhoneNumber, @AccGender, 0)", con);
                    cmd.Parameters.AddWithValue("@AccName", txtName.Text);
                    cmd.Parameters.AddWithValue("@AccPass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@AccPhoneNumber", txtNumber.Text);
                    cmd.Parameters.AddWithValue("@AccGender", txtGender.SelectedItem.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayAccounts();
                    MessageBox.Show("Registration Successful");
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

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtNumber.Text) && txtGender.SelectedItem != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE AccountTbl SET AccName = @AccName, AccPass = @AccPass, AccGender = @AccGender WHERE AccPhoneNumber = @AccPhoneNumber", con);
                    cmd.Parameters.AddWithValue("@AccName", txtName.Text);
                    cmd.Parameters.AddWithValue("@AccPass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@AccGender", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AccPhoneNumber", txtNumber.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    reset();
                    DisplayAccounts();
                    MessageBox.Show("Update Successful");
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

        private void bunifuButton1_Click_2(object sender, EventArgs e)
        {
            int txt_txt;

            try
            {
                // Check if the account phone number is provided
                if (int.TryParse(txtNumber.Text, out txt_txt))
                {
                    // Create SQL command with parameter to prevent SQL injection
                    SqlCommand cmd = new SqlCommand("DELETE FROM AccountTbl WHERE AccPhoneNumber = @AccPhoneNumber", con);
                    cmd.Parameters.AddWithValue("@AccPhoneNumber", txt_txt);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Account deleted successfully.");

                    // Update DataGridView
                    DisplayAccounts();
                }
                else
                {
                    MessageBox.Show("Please provide a valid account phone number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable SearchProduct(int productId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AccountTbl WHERE AccPhoneNumber = @AccPhoneNumber", con);

                // Add parameter with correct name
                cmd.Parameters.AddWithValue("@AccPhoneNumber", productId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return dataTable;
        }

        private void bunifuButton1_Click_3(object sender, EventArgs e)
        {
            int productId;
            if (int.TryParse(txtNumber.Text, out productId))
            {
                DataTable productTable = SearchProduct(productId);
                if (productTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = productTable; // Assuming your DataGridView is named dataGridView1
                    txtNumber.Clear();

                }
                else
                {
                    MessageBox.Show("Product not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayAccounts();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
