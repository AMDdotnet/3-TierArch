using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Contracts;

namespace UI
{
    public partial class FrmLessons : Form
    {
        private static Action _action;
        private readonly ILessonService _lessonService;
        public FrmLessons(ILessonService lessonService)
        {
            InitializeComponent();
            _lessonService = lessonService;
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
                _action = Action.update;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtName.Text = dataGridView1.Rows[row].Cells[colName.Index].Value.ToString();
            txtUnits.Text = dataGridView1.Rows[row].Cells[colUnits.Index].Value.ToString();
            txtId.Text = dataGridView1.Rows[row].Cells[colId.Index].Value.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(_action == Action.insert)
            {
                var res = _lessonService.Insert(txtName.Text, byte.Parse(txtUnits.Text));
                if(!res.IsSuccess)
                {
                    errorProvider1.SetError(txtName, res.Message);
                    errorProvider1.SetError(txtUnits, res.Message);
                }
                else
                {
                    btnInsert.Enabled = true;
                    btnUpdate.Enabled = true;
                    panel1.Visible = false;
                    FillGrid();
                }
            }
            else if(_action == Action.update)
            {
                var res = _lessonService.Update(Guid.Parse(txtId.Text), txtName.Text, byte.Parse(txtUnits.Text));
                if (!res.IsSuccess)
                {
                    errorProvider1.SetError(txtName, res.Message);
                    errorProvider1.SetError(txtUnits, res.Message);
                }
                else
                {
                    btnInsert.Enabled = true;
                    btnUpdate.Enabled = true;
                    panel1.Visible = false;
                    FillGrid();
                }
            }
        }

        void FillGrid()
        {
            dataGridView1.Rows.Clear();
            var lessons = _lessonService.GetAll();
            for (int i = 0; i < lessons.Data.Count; i++)
            {
                var id = lessons.Data[i].Id;
                var name = lessons.Data[i].Name;
                var units = lessons.Data[i].Units;
                dataGridView1.Rows.Add(id, name, units);
            }
        }
    }
}
