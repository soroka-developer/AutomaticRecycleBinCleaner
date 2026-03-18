using AutoRecycleBinCleaner.Src;
using System;
using System.Windows.Forms;

namespace AutoRecycleBinCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lastUpdateText.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    if (int.TryParse(textBox2.Text, out int minutes))
                    {
                        timer1.Interval = minutes * 60 * 1000;
                        timer1.Enabled = !timer1.Enabled;
                        button2.Text = timer1.Enabled ? "Stop" : "Start";
                    }
                    else
                    {
                        MessageBox.Show("Enter a number!");
                    }
                }
                else
                {
                    MessageBox.Show("Enter minutes!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BinCleaner.Clear();
            lastUpdateText.Text = $"Last clear: {BinCleaner.LastCleanupTime}";
        }
    }
}
