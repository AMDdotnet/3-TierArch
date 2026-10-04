using BL.Contracts;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly IBimarService _bimarService;
        public Form1(IBimarService bimarService)
        {
            InitializeComponent();
            _bimarService = bimarService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = _bimarService.Insert(
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Properties.Resources.SystemError
            var cs = UI.Properties.Settings.Default.ConnectionString;
            MessageBox.Show(cs);
        }
    }
}
