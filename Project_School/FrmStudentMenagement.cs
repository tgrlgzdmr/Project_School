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
    public partial class FrmStudentMenagement : Form
    {
        public FrmStudentMenagement()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T4GE7A8\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        DataSet1TableAdapters.Tbl_StudentsTableAdapter dss = new DataSet1TableAdapters.Tbl_StudentsTableAdapter();
        DataSet1TableAdapters.Tbl_Notes1TableAdapter dnn=new DataSet1TableAdapters.Tbl_Notes1TableAdapter();
        private void FrmStudentMenagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dss.StudentList();

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Clubs", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbClub.DisplayMember = "ClubName";
            CmbClub.ValueMember = "Clubid";
            CmbClub.DataSource = dt;
            conn.Close();

        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dss.StudentList();
        }

        


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string Gender = "";

            if (RdMan.Checked == true)
            {
                RdWoman.Checked = false;
                Gender = "Man";
            }
            if(RdWoman.Checked == true)
            {
                RdMan.Checked = false;
                Gender = "Woman";
            }
            

            dss.AddStudent(TxtName.Text, TxtSurname.Text, byte.Parse(CmbClub.SelectedValue.ToString()), Gender);
            MessageBox.Show("Student is added");
            dataGridView1.DataSource = dss.StudentList();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string Gender = "";

            if (RdMan.Checked == true)
            {
                RdWoman.Checked = false;
                Gender = "Man";
            }
            if (RdWoman.Checked == true)
            {
                RdMan.Checked = false;
                Gender = "Woman";
            }
            dss.StudentUpdate(TxtName.Text, TxtSurname.Text, byte.Parse(CmbClub.SelectedValue.ToString()), Gender,int.Parse(Txtid.Text));
            MessageBox.Show("Student is updated");
            dataGridView1.DataSource = dss.StudentList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[chosen].Cells[2].Value.ToString();
            if(dataGridView1.Rows[chosen].Cells[3].Value.ToString()=="Man")
            {
                RdMan.Checked=true;
            }
            if(dataGridView1.Rows[chosen].Cells[3].Value.ToString() == "Woman")
            {
                RdWoman.Checked=true;
            }
            CmbClub.SelectedValue= dataGridView1.Rows[chosen].Cells[4].Value.ToString();

        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            dnn.Fixing2(int.Parse(Txtid.Text));
            dss.DeleteStudent(int.Parse(Txtid.Text));
            MessageBox.Show("Student is deleted");
            dataGridView1.DataSource = dss.StudentList();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= dss.PullStd(TxtSearch.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
