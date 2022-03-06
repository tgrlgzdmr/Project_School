using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_School
{
    public partial class FrmLessons : Form
    {
        public FrmLessons()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_LessonsTableAdapter ds = new DataSet1TableAdapters.Tbl_LessonsTableAdapter();
        DataSet1TableAdapters.Tbl_NotesTableAdapter df = new DataSet1TableAdapters.Tbl_NotesTableAdapter();

        private void FrmLessons_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.LessonList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ds.AddLesson(TxtLessonName.Text);
            MessageBox.Show("Lesson is added");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            df.Fixing(byte.Parse(TxtLessonid.Text));
            ds.DeleteLesson(byte.Parse(TxtLessonid.Text));
            MessageBox.Show("Lesson is deleted");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.UpdateLesson(TxtLessonName.Text,byte.Parse(TxtLessonid.Text));
            MessageBox.Show("Lesson is updated");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            TxtLessonid.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtLessonName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
        }
    }
}
