using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amar_Cash
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close ();  
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this .Close (); 
        }

        private void welcome_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ShowComingSoonMessage("Coming soon...");
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
    }
}
