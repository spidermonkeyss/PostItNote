using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class NotesScreen
    {
        static ContainerControl postContainer = new ContainerControl();

        public static void InitNotesScreen(Form form)
        {
            postContainer.Name = "Post Container";
            postContainer.Location = new Point(0, 0);
            postContainer.Paint += new PaintEventHandler(Shadow.dropShadowBitmap);
            form.Resize += new EventHandler(NotesScreen.ResizeWindow);
            DirectoryInfo projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            postContainer.BackgroundImage = Image.FromFile(projectDir.FullName + "\\pinboard1.jpg");
            postContainer.BackgroundImageLayout = ImageLayout.Tile;
        }

        public static void ShowNoteScreen()
        {
            postContainer.Size = Form.ActiveForm.ClientSize;
            Form.ActiveForm.Controls.Add(postContainer);

            CreateBackButton();
            CreateNotes();

            postContainer.Visible = true;
            Form.ActiveForm.Controls[0].Visible = false;
            
        }

        private static void CreateBackButton()
        {
            Button backBtn = new Button();
            //backBtn.Anchor = AnchorStyles.Top;
            backBtn.AutoSize = true;
            backBtn.Location = new Point(50, 50);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(99, 27);
            backBtn.TextAlign = ContentAlignment.MiddleCenter;
            backBtn.Text = "Go Back";
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.BackColor = Color.Tomato;
            backBtn.Click += new EventHandler(backBtn_Click);
            postContainer.Controls.Add(backBtn);
        }

        private static void CreateNotes()
        {
            FileInfo[] notes = Program.GetPosts();
            int numOfPostTitles = 0;
            int spaceBetweenPostsX = 150;

            foreach (FileInfo file in notes)
            {
                numOfPostTitles++;
                //container. this is the post it note
                Panel postPanel = new Panel();
                postPanel.Name = "postPanel" + numOfPostTitles;
                postPanel.Location = new Point(10 + ((numOfPostTitles - 1) * spaceBetweenPostsX), 170);
                postPanel.Size = new Size(140, 140);
                postPanel.BorderStyle = BorderStyle.None;
                postPanel.BackColor = Color.FromArgb(206, 237, 0);
                postPanel.MouseDown += ClickAndDrag.note_MouseDown;
                postPanel.MouseMove += ClickAndDrag.note_MouseMove;
                postPanel.MouseUp += ClickAndDrag.note_MouseUp;
                postContainer.Controls.Add(postPanel);

                //remove btn
                Button removeBtn = new Button();
                removeBtn.Anchor = AnchorStyles.Top;
                removeBtn.AutoSize = true;
                removeBtn.Location = new Point(0, 0);
                removeBtn.Name = "removeBtn";
                removeBtn.Size = new Size(15, 20);
                removeBtn.TextAlign = ContentAlignment.MiddleCenter;
                removeBtn.Text = "X";
                removeBtn.Click += new EventHandler(removeBtn_Click);
                postPanel.Controls.Add(removeBtn);

                //title text
                Label postTitleLabel = new Label();
                postTitleLabel.Anchor = AnchorStyles.Top;
                postTitleLabel.AutoSize = true;
                postTitleLabel.Location = new Point(0, 23);
                postTitleLabel.Name = "postTitle";
                postTitleLabel.Size = new Size(99, 27);
                postTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
                string title = file.Name.Substring(0, file.Name.Length-4);
                postTitleLabel.Text = title;
                postPanel.Controls.Add(postTitleLabel);

                //content
                Label noteContent = new Label();
                using (StreamReader sr = file.OpenText())
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                       noteContent.Text = s;
                }
                noteContent.Anchor = AnchorStyles.Top;
                noteContent.AutoSize = true;
                noteContent.Location = new Point(0, 40);
                noteContent.Name = "postContent";
                noteContent.Size = new Size(99, 27);
                noteContent.TextAlign = ContentAlignment.MiddleCenter;
                postPanel.Controls.Add(noteContent);
            }
            Console.WriteLine("Showing " + numOfPostTitles + " post");
        }

        private static void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in ((Control)sender).Parent.Controls)
            {
                if (control.Name == "postTitle")
                {
                    string filePath = Program.GetNotesFolder()  + "\\" + control.Text;
                    File.Delete(filePath);
                    postContainer.Controls.Remove(((Control)sender).Parent);
                    postContainer.Refresh();
                }
            }
        }

        private static void backBtn_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Controls[0].Visible = true;
            postContainer.Visible = false;
            postContainer.Controls.Clear();
            Form.ActiveForm.Controls.Remove(postContainer);
        }

        public static void ResizeWindow(object sender, EventArgs e)
        {
            Console.WriteLine("Window Resized to " + ((Control)sender).Size);
            postContainer.Size = Form.ActiveForm.ClientSize;
        }

    }
}
