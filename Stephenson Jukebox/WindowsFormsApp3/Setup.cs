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
                for (int M = 0; M < MP3.Length; M++)
                {
                    listBox1.Items.Add(MP3[M]);
                }
            }

        }

        // Displays list of songs //

        public string ListofSongs
        {
            get { return listBox2.SelectedItem.ToString(); }
        }

        // Opens the File browser to look for mp3 files //

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

        // Scroll bar obtains the value to scroll from the display genre //

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            display_genre(hScrollBar1.Value);
        }

        // Clears the items in listbox1 //

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }

        // Allows the items to be copied when selected to listbox1 //


        private void button3_Click(object sender, EventArgs e)
        {
            Copy();

        }

        private void Copy()
        {
            int c = listBox1.Items.Count - 1;
            for (int t = c; t >= 0; t--)
            {
                if (listBox1.GetSelected(t))
                {
                    listBox2.Items.Add(listBox1.Items[t]);

                }
            }
        }

        // Allows the items to be added to the listbox on selection //

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
        
        // allows listbox2 items to be selected //

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Opens the File browser to look for mp3 files //

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        // Allows items to be deleted when selected //

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

        // Closes the form//

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Closes the form//

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Moves the genre to the next one //

        private void button9_Click(object sender, EventArgs e)
        {
            display_genre(hScrollBar1.LargeChange);

        }
        
        // Moves the genre to the previous one //
        private void button6_Click(object sender, EventArgs e)
        {
            display_genre(hScrollBar1.SmallChange);
            


        }

        // Allows items to be deleted when selected //

        private void button8_Click(object sender, EventArgs e)
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

        //Adds item from imported directory//
        private void button7_Click(object sender, EventArgs e)
        {
            Add();
        }

        // allows listbox1 items to be selected //

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
