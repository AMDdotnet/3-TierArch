using BL;
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
    public partial class FrmTeacher : Form
    {
        int _id;
        public FrmTeacher(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void FrmTeacher_Load(object sender, EventArgs e)
        {
            FillInfo();
        }

        private void FillInfo()
        {
            var teacherService = new TeacherService();

            var res = teacherService.SelectAll();

            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message);
                Close();
            }
            var teachers = res.Data;

            var teacher = teachers.Single(t => t.Id == _id);

            txtName.Text = teacher.FirstName;
            txtLastName.Text = teacher.LastName;
            txtScore.Text = teacher.Score.ToString();
            rtxtMobiles.Text = string.Join(Environment.NewLine, teacher.MobileNumbers);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
