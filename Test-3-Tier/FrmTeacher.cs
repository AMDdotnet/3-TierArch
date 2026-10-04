using BL;
using BL.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Properties;

namespace UI
{
    public partial class FrmTeacher : Form
    {
        int _id;
        private readonly ITeacherService _teacherService;
        public FrmTeacher(int id, ITeacherService teacherService)
        {
            InitializeComponent();
            _id = id;
            _teacherService = teacherService;
        }

        private void FrmTeacher_Load(object sender, EventArgs e)
        {
            FillInfo();
        }

        private void FillInfo()
        {
            var res = _teacherService.SelectAll();

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
            MessageBox.Show(Resources.SystemError);
        }


    }
}
