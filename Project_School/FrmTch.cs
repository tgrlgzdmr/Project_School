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
    public partial class FrmTch : Form
    {
        public FrmTch()
        {
            InitializeComponent();
        }

        private void FrmTch_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmClub fr = new FrmClub();
            fr.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLessons frm = new FrmLessons();
            frm.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmStudentMenagement fm = new FrmStudentMenagement();
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmExamNotes frn = new FrmExamNotes();
            frn.Show();

        }
    }
}
