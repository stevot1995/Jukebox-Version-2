using System;
using System.IO;
using WMPLib;

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
    public partial class Main : Form

    {
        ListBox[] Genre;

        WMPLib.WindowsMediaPlayer play = new WMPLib.WindowsMediaPlayer();
        string TrackPath = Directory.GetCurrentDirectory() + "\\Tracks\\";
        int selected_genre;
        int selected_track;

        public Main()

        {
           
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            

        }

        



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        public void click()
        {

            
            
            
        


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Setup = new Setup();
            Setup.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var About = new Info();
            About.Show();
        }

        private void Load_data(object sender, EventArgs e)
        {
            

            int TotalNumberofGenre;

            int Tracks;

            // This gets the location where the media folder directory is located.
            
            string applicationPath = Directory.GetCurrentDirectory() + "\\Media\\";

            // Reads a file on the HDD in the subfolder "media" called "Media.txt"//

            StreamReader myInputStream = File.OpenText(applicationPath + "Media.txt");

            // Obtains the files contents and converts it into a interger. //
            TotalNumberofGenre = Convert.ToInt32( myInputStream.ReadLine());

            // Sets the scroll bar to start scrolling between genres 0-3. //
            hScrollBar1.Maximum = TotalNumberofGenre -1;


            Genre = new ListBox[TotalNumberofGenre];


            for (int G = 0; G < TotalNumberofGenre; G++)
            {
                Tracks = Convert.ToInt32(myInputStream.ReadLine());

                Genre[G] = new ListBox();

                Genre[G].Items.Add(myInputStream.ReadLine());

                for (int t = 1; t <= Tracks; t++)
                {
                    Genre[G].Items.Add(myInputStream.ReadLine());
                }
                                                                 
            }
            // Close the file
            myInputStream.Close();

            display_genre(0);

        }
        private void display_genre(int G)
        {
            selected_genre = G;
            Txt_title.Text = "";
            listBox2.Items.Clear();

            Txt_title.Text = Genre[G].Items[0].ToString();
            

            for (int t = 1; t < Genre[G].Items.Count; t++)
            {
                listBox2.Items.Add(Genre[G].Items[t].ToString());
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            display_genre(hScrollBar1.Value);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            play.URL = TrackPath + Genre[selected_genre].Items[listBox2.SelectedIndex +1].ToString();
            play.controls.play();
        }

        private void select_track(object sender, EventArgs e)
        {
            
        }
    }
}
