using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static FileInfo[] GetPosts()
        {
            //Get project Directory
            DirectoryInfo projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string notesPath = projectDir.FullName + "\\Notes";
            DirectoryInfo notesDir = new DirectoryInfo(notesPath);
            FileInfo[] fileNames = notesDir.GetFiles();
            
            return fileNames;
        }

        public static string GetNotesFolder()
        {
            //Get notes directory
            DirectoryInfo projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string notesPath = projectDir.FullName + "\\Notes";

            return notesPath;
        }
    }
}
