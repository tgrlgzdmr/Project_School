using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_School
{
    public partial class FrmExamNotes : Form
    {
        public FrmExamNotes()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable2TableAdapter ds = new DataSet1TableAdapters.DataTable2TableAdapter();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T4GE7A8\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");
        private void FrmExamNotes_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = ds.TchNote();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Lessons", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbLesson.DisplayMember = "LessonName";
            CmbLesson.ValueMember = "Lessonid";
            CmbLesson.DataSource = dt;
            conn.Close();

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Note(int.Parse(Txtid.Text));
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        string c;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            c = CmbLesson.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            CmbLesson.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtExam1.Text = dataGridView1.Rows[chosen].Cells[4].Value.ToString();
            TxtExam2.Text = dataGridView1.Rows[chosen].Cells[5].Value.ToString();
            TxtExam3.Text = dataGridView1.Rows[chosen].Cells[6].Value.ToString();
            TxtProject.Text = dataGridView1.Rows[chosen].Cells[7].Value.ToString();
            TxtAverage.Text = dataGridView1.Rows[chosen].Cells[8].Value.ToString();
            TxtSituation.Text = dataGridView1.Rows[chosen].Cells[9].Value.ToString();
        }
        bool a;
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            double average;
            int Exam1 = Convert.ToInt16(TxtExam1.Text);
            int Exam2 = Convert.ToInt16(TxtExam2.Text);
            int Exam3 = Convert.ToInt16(TxtExam3.Text);
            int Projects = Convert.ToInt16(TxtProject.Text);
            average = (Exam1*20/100)+(Exam2*30/100)+(Exam3*40/100)+(Projects*10/100);
            TxtAverage.Text = average.ToString();
            if(average<60)
            {
                TxtSituation.Text = "Failed";
                a = false;
            }
            else
            {
                TxtSituation.Text = "Passed";
                a = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.UpdateNote(byte.Parse(TxtExam1.Text), byte.Parse(TxtExam2.Text), byte.Parse(TxtExam3.Text), byte.Parse(TxtProject.Text), decimal.Parse(TxtAverage.Text), a, int.Parse(c));
            MessageBox.Show("Student note is updated");
            dataGridView1.DataSource = ds.Note(int.Parse(Txtid.Text));
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ds.AddNote(byte.Parse(CmbLesson.SelectedValue.ToString()), int.Parse(Txtid.Text));
            dataGridView1.DataSource = ds.Note(int.Parse(Txtid.Text));
            //TxtExam3.Text = CmbLesson.SelectedValue.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
