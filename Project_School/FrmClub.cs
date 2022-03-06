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
    public partial class FrmClub : Form
    {
        public FrmClub()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T4GE7A8\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void listing()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Clubs", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
           // listing();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            TxtClupid.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            TxtClubName.Text = dataGridView1.Rows[chosen].Cells[1].Value.ToString();
            
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            listing();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Clubs (ClubName) values (@p1)",conn);
            cmd.Parameters.AddWithValue("@p1", TxtClubName.Text);
            cmd.ExecuteNonQuery();
            
            conn.Close();
            listing();
            MessageBox.Show("Club is added");
            
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("Update Tbl_Clubs SET ClubName=@p1 where Clubid=@p2", conn);
            cmd1.Parameters.AddWithValue("@p1", TxtClubName.Text);
            cmd1.Parameters.AddWithValue(@"p2", TxtClupid.Text);
            cmd1.ExecuteNonQuery();
            conn.Close ();
            listing();
            MessageBox.Show("Club is updated");
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            conn.Open ();
            SqlCommand cmd3 = new SqlCommand("Update Tbl_Students SET StdClub=11 where StdClub=@p2", conn);
            cmd3.Parameters.AddWithValue("@p2",TxtClupid.Text);
            cmd3.ExecuteNonQuery();
            conn.Close();
            conn.Open ();
            SqlCommand cmd2 = new SqlCommand("Delete from Tbl_Clubs where Clubid=@p1", conn);
            cmd2.Parameters.AddWithValue("@p1",TxtClupid.Text);
            cmd2.ExecuteNonQuery();
            conn.Close();
            listing ();
            MessageBox.Show("Club is deleted");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }
    }
}
