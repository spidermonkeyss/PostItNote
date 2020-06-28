using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NotesScreen.InitNotesScreen(this);
        }

        private void btnViewPosts_Click(object sender, EventArgs e)
        {
            NotesScreen.ShowNoteScreen();
        }

        private void btnCreatePosts_Click(object sender, EventArgs e)
        {
            CreatePostScreen.ShowCreatePostScreen();
        }

        private void ShowControls()
        {
            foreach (Control control in Controls)
                Console.WriteLine(control);
            Console.WriteLine();
        }
    }
}
