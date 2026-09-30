using BL;
using Common;
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
    public partial class FrmTeachers : Form
    {
        ILogger _loger;
        TeacherService teacher;
        public FrmTeachers(ILogger loger)
        {
            InitializeComponent();
            _loger = loger;
            teacher = new TeacherService(_loger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = teacher.SelectAll();
            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message);
                Close();
            }
            var teachers = res.Data;


            var scores = teachers.Select(x => x.Score).ToList();

            var upper12 = teachers
                .Where(teacher => teacher.Score > 12)
                .Select(teacher => new
                {
                    FullName = $"{teacher.FirstName} {teacher.LastName}",
                    teacher.Score
                }).ToList();


            dataGridView1.DataSource = teachers.SkipWhile(t => t.Score != 12).ToList();
        }

        //private bool Filter(Teacher teacher)
        //{
        //    if (teacher.Score > 12)
        //        return true;
        //    else
        //        return false;
        //}
        int pageSize = 50;
        private void FrmTeachers_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("test");
            //List<Action> list = new List<Action>();
            //for (int i = 0; i < 3; i++)
            //{
            //    list.Add(() => Console.WriteLine(i));
            //}

            //foreach (var item in list)
            //{
            //    item();
            //}

            var res = teacher.SelectAll();
            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message);
                Close();
            }


            var teachers = res.Data;
            var filtered = teachers.AsEnumerable();
            //if (teachers.Count > 0)
            //{
            //    var avg = teachers.Average(x => x.Score);
            //}

            //if (!string.IsNullOrEmpty(textBox1.Text))
            //{
            //    filtered = teachers.Where(x => x.FirstName.Contains(textBox1.Text));
            //}
            //if (!string.IsNullOrEmpty(textBox2.Text))
            //{
            //    filtered = teachers.Where(x => x.LastName.Contains(textBox2.Text));
            //}
            //if (!string.IsNullOrEmpty(textBox3.Text))
            //{
            //    var score = int.Parse(textBox3.Text);
            //    filtered = teachers.Where(x => x.Score == score);
            //}

            teachers = filtered.ToList();

            if (teachers.Any())
            {
                var avg = teachers.Average(x => x.Score);
                var max = teachers.Max(x => x.Score);
                var min = teachers.Min(x => x.Score);
            }

            var mobiles = teachers
                .Where(x => x.MobileNumbers != null)
                .SelectMany(x => x.MobileNumbers)
                .ToList();
            var scores = teachers.Select(x => x.Score).ToList();


            var uniqueScores = scores.Distinct().ToList();

            var count = teachers.Count();


            var pages = count / pageSize;

            for (int i = 0; i < pages; i++)
            {
                Button btn = new Button();
                btn.AutoSize = true;
                btn.Text = (i + 1).ToString();
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }

            ShowData(1);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var pageNumber = int.Parse((sender as Button).Text);
            ShowData(pageNumber);
        }

        class TeacherComparer : IEqualityComparer<Teacher>
        {
            public bool Equals(Teacher x, Teacher y)
            {
                Count++;
                if (x.FirstName != y.FirstName)
                    return false;

                if (x.LastName != y.LastName)
                    return false;

                if (x.Id != y.Id)
                    return false;

                return true;
            }
            public static int Count = 0;
            public int GetHashCode(Teacher obj)
            {
                return (obj.Id + obj.FirstName + obj.LastName).GetHashCode();

                //throw new NotImplementedException();
            }
        }

        private void ShowData(int pageNumber)
        {


            //right join
            //        var query = departments
            //.GroupJoin(
            //    employees,
            //    dept => dept.Id,
            //    emp => emp.DepartmentId,
            //    (dept, empGroup) => new { dept, empGroup }
            //)
            //.SelectMany(
            //    x => x.empGroup.DefaultIfEmpty(),
            //    (x, emp) => new
            //    {
            //        DepartmentName = x.dept.Name,
            //        EmployeeName = emp != null ? emp.FullName : "بدون کارمند"
            //    }
            //);


            var res = teacher.SelectAll();
            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message);
                Close();
            }
            var teachers = res.Data;

            var compare = new TeacherComparer();

            teachers = teachers.Distinct(compare).ToList();

            MessageBox.Show(TeacherComparer.Count.ToString());

            dataGridView1.DataSource = teachers.ToList();

            teachers.GroupBy(t => t.FirstName).Select(t => new
            {
                FirstName = t.First().FirstName,
                Count = t.Count(),
                Avg = t.Average(y => y.Score)
            });




            //var filtered = teachers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            //var ordered = filtered
            //    .OrderByDescending(x => x.FirstName)
            //    .ThenByDescending(x => x.LastName);
            //.ThenBy(x => x.LastName)
            //.ThenByDescending(x => x.Score);

            //filtered.Reverse();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //var id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

            //var frm = new FrmTeacher(id);
            //frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = teacher.SelectAll();
            if (!res.IsSuccess)
            {
                MessageBox.Show(res.Message);
                Close();
            }
            dataGridView1.DataSource = res.Data;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var txts = this.Controls.Cast<TextBox>().Where(x => x.Name.StartsWith("btn"));

            var list = txts.ToList();

            foreach (var txt in txts)
            {
                txt.BackColor = Color.Yellow;
            }
        }
    }
}
