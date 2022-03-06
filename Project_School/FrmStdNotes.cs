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
    public partial class FrmStdNotes : Form
    {
        public FrmStdNotes()
        {
            InitializeComponent();
        }

        public string No;
        public string x;
        
        DataSet1TableAdapters.Tbl_StudentsTableAdapter dpn = new DataSet1TableAdapters.Tbl_StudentsTableAdapter();
        DataSet1TableAdapters.DataTable2TableAdapter dst = new DataSet1TableAdapters.DataTable2TableAdapter();
        

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T4GE7A8\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");

        //public string Student()
        //{
        //    
        //    /*conn.Open();
        //    SqlCommand cmd1 = new SqlCommand("Select StdName + ' ' + StdSurname from Tbl_Students where Stdid=@p1", conn);
        //    cmd1.Parameters.AddWithValue("@p1", No);
        //    SqlDataReader dr = cmd1.ExecuteReader();
        //    while(dr.Read())
        //    {
        //          x = dr[0].ToString();
        //    }
        //    conn.Close();*/
        //
        //    return dpn.PullStdNama(int.Parse(No)).ToString(); 
        //}


        private void FrmStdNotes_Load(object sender, EventArgs e)
        {
           conn.Open();
           SqlCommand cmd1 = new SqlCommand("Select [StdName]+' '+[StdSurname] from [dbo].[Tbl_Students] where [Stdid]=@p2", conn);
           cmd1.Parameters.AddWithValue("@p2", No);
           SqlDataReader dr = cmd1.ExecuteReader();
               while(dr.Read())
               {
                     x = dr[0].ToString();
               }
           conn.Close();
           this.Text = x;
            //dataGridView1.DataSource = dn.deneys(int.Parse(No));
            dataGridView1.DataSource = dst.Note(int.Parse(No));

            //SqlCommand cmd = new SqlCommand("select LessonName,Exam1,Exam2,Exam3,Project,Average,Situation from Tbl_Notes inner join Tbl_Lessons on Tbl_Notes.Lessonid = Tbl_Lessons.Lessonid WHERE Stdid = @p1", conn);
            //cmd.Parameters.AddWithValue("@p1", No);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }
    }
}
