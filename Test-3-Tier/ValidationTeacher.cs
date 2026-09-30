using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ValidationTeacher : Form
    {
        public ValidationTeacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var teacher = new Teacher();
            teacher.NationalCode = textBox1.Text;
            if (!teacher.IsValid)
            {
                MessageBox.Show(teacher.ErrorMessage);
            }
            else
            {
                //insert
            }
        }
    }
}
