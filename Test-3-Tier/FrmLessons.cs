using BL.Contracts;
using Common.Attributes;
using Common.Extentions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmLessons : Form
    {
        private static Action _action;
        private readonly ILessonService _lessonService;
        private BindingSource _lessonBindingSource = new BindingSource();
        private Lesson _currentLesson;
        public FrmLessons(ILessonService lessonService)
        {
            InitializeComponent();
            _lessonService = lessonService;

            _currentLesson = new Lesson("", 1);
            _lessonBindingSource.DataSource = _currentLesson;

            errorProvider1.DataSource = _lessonBindingSource;

            txtName.DataBindings.Add(
                "Text", _lessonBindingSource, nameof(Lesson.Name), true, DataSourceUpdateMode.OnPropertyChanged);
            txtUnits.DataBindings.Add(
                "Text", _lessonBindingSource, nameof(Lesson.Units), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FrmLessons_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                lblAct.Text = "Insert Action";
                panel1.Visible = true;
                txtId.Visible = false;
                _action = Action.insert;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                btnUpdate.Enabled = false;
                btnInsert.Enabled = false;
                lblAct.Text = "Update Action";
                panel1.Visible = true;
                txtId.Visible = true;
                _action = Action.update;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                txtId.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                txtUnits.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();

            if (!_currentLesson.IsValid)
            {
                MessageBox.Show(_currentLesson.ErrorMessage);
                return;
            }

            if (_action == Action.insert)
            {
                var res = _lessonService.Insert(_currentLesson.Name, _currentLesson.Units);

                btnInsert.Enabled = true;
                btnUpdate.Enabled = true;
                panel1.Visible = false;
                FillGrid();
            }
            else if (_action == Action.update)
            {
                var res = _lessonService.Update(Guid.Parse(txtId.Text), _currentLesson.Name, _currentLesson.Units);

                btnInsert.Enabled = true;
                btnUpdate.Enabled = true;
                panel1.Visible = false;
                FillGrid();
            }
        }

        void FillGrid()
        {
            dataGridView1.DataSource = null;
            var lessons = _lessonService.GetAll();
            dataGridView1.DataSource = lessons.Data.ToDataTable();

            var lessonMetaData = typeof(Lesson);
            var lessonProps = lessonMetaData.GetProperties();
            foreach (var prop in lessonProps)
            {
                var attrs = prop.GetCustomAttributes(false);
                var attr = attrs.OfType<DgvDisplayAttribute>().FirstOrDefault();
                if (attr != null)
                {
                    dataGridView1.Columns[prop.Name].HeaderText = attr.Title;
                    dataGridView1.Columns[prop.Name].Visible = attr.Visible;
                }
                else
                {
                    dataGridView1.Columns[prop.Name].Visible = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }
}
