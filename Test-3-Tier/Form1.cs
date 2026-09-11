using BL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = new BimarService();
            var result = service.Insert(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
                return;
            }

            //insert success
        }
    }
}
