using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form

    {
        
        public Form1()

        {
           
            InitializeComponent();
        }

      
       
   
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Setup = new Form3();
            Setup.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var About = new Form2();
            About.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
        }
    }
}
