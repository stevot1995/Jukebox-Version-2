using System;
using System.IO;
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
    public partial class Setup : Form
    {
        ListBox[] Genre;

       
        string TrackPath = Directory.GetCurrentDirectory() + "\\Tracks\\";
        int selected_genre;

        public Setup()
        {
           
            InitializeComponent();
        }
        string[] Folderbrowser, MP3;
        public void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Folderbrowser = openFileDialog1.FileNames;
                MP3 = openFileDialog1.SafeFileNames;
                for (int M = 0 ; M <MP3.Length; M++)
                {
                    listBox1.Items.Add(MP3[M]);
                }
            }
           
        }

        public string ListofSongs
        {
            get { return listBox2.SelectedItem.ToString(); }
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int TotalNumberofGenre;

            int Tracks;

            // This gets the location where the media folder directory is located.

            string applicationPath = Directory.GetCurrentDirectory() + "\\Media\\";

            // Reads a file on the HDD in the subfolder "media" called "Media.txt"//

            StreamReader myInputStream = File.OpenText(applicationPath + "Media.txt");

            // Obtains the files contents and converts it into a interger. //
            TotalNumberofGenre = Convert.ToInt32(myInputStream.ReadLine());

            // Sets the scroll bar to start scrolling between genres 0-3. //
            

            //Creates a new listbox which is equal the the total number of Genres (3) //

            Genre = new ListBox[TotalNumberofGenre];

            // Adds tracks into the Genres in the listbox //

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
            // Closes the file and also resets the display genre to 0 //
            myInputStream.Close();

            display_genre(0);

        }

        // Displays the genre in the textbox //

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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Copy();
     
        }
        private void Copy()
        {
            int c = listBox1.Items.Count - 1;
            for (int t = c; t >=0; t--)
            {
                if (listBox1.GetSelected(t))
                {
                    listBox2.Items.Add(listBox1.Items[t]);
                    
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Add()
        { int a = listBox1.Items.Count - 1;
            for (int i = a; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    listBox2.Items.Add(listBox1.Items[i]);
                    listBox1.Items.RemoveAt(i);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        
        {
            if (listBox2.SelectedItems.Count != 0)
            {
                while (listBox2.SelectedIndex != -1)
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
            }
            if (listBox1.SelectedItems.Count != 0)
            {
                while (listBox1.SelectedIndex != -1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
