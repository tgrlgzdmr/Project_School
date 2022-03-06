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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmStdNotes std = new FrmStdNotes();
            std.No = TxtNo.Text;
            std.Show();
            
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmTch tch = new FrmTch();
            tch.Show();
            this.Hide();
        }
    }
}
