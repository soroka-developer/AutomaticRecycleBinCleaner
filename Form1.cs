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
            button2.Text = timer1.Enabled ? "Stop" : "Start";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BinCleaner.Clear();
        }
    }
}
