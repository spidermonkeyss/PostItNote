using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class CreatePostScreen
    {
        static ContainerControl container = new ContainerControl();

        public static void ShowCreatePostScreen()
        {
            //reset the container before filling
            foreach (Control control in container.Controls)
                container.Controls.Remove(control);

            container.Name = "Post Container";
            container.Location = new Point(0, 0);
            container.Size = Form.ActiveForm.ClientSize;
            Form.ActiveForm.Controls.Add(container);

            container.Visible = true;
            Form.ActiveForm.Controls[0].Visible = false;

            CreateTextFields();
            CreateAddNoteBtn();
            CreateBackButton();
        }

        private static void CreateTextFields()
        {
            TextBox titleBox = new TextBox();
            titleBox.Location = new Point(300, 100);
            titleBox.Name = "titleBox";
            titleBox.Size = new Size(100, 22);
            container.Controls.Add(titleBox);

            TextBox contentBox = new TextBox();
            contentBox.Location = new Point(100, 200);
            contentBox.Name = "contentBox";
            contentBox.Size = new Size(300, 22);
            container.Controls.Add(contentBox);
        }

        private static void CreateAddNoteBtn()
        {
            Button addBtn = new Button();
            addBtn.Anchor = AnchorStyles.Top;
            addBtn.AutoSize = true;
            addBtn.Location = new Point(400, 50);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(99, 27);
            addBtn.TextAlign = ContentAlignment.MiddleCenter;
            addBtn.Text = "Add Note";
            addBtn.Click += new EventHandler(addBtn_Click);
            container.Controls.Add(addBtn);
        }
        private static void addBtn_Click(object sender, EventArgs e)
        {
            string title = ((TextBox)container.Controls.Find("titleBox", false)[0]).Text + ".txt"; //title as a text file
            string content = ((TextBox) container.Controls.Find("contentBox", false)[0]).Text;

            //Get project Directory
            DirectoryInfo projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string filePath = projectDir.FullName + "\\Notes";

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, title)))
            {
                outputFile.WriteLine(content);
            }

            Console.WriteLine(title);
            Console.WriteLine(content);
            Console.WriteLine(filePath);

            //go back
            container.Visible = false;
            Form.ActiveForm.Controls[0].Visible = true;
        }

        private static void CreateBackButton()
        {
            Button backBtn = new Button();
            backBtn.Anchor = AnchorStyles.Top;
            backBtn.AutoSize = true;
            backBtn.Location = new Point(100, 50);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(99, 27);
            backBtn.TextAlign = ContentAlignment.MiddleCenter;
            backBtn.Text = "Go Back";
            backBtn.Click += new EventHandler(backBtn_Click);
            container.Controls.Add(backBtn);
        }
        private static void backBtn_Click(object sender, EventArgs e)
        {
            container.Visible = false;
            Form.ActiveForm.Controls[0].Visible = true;
            container.Controls.Clear();
        }
    }
}
