namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnViewPosts = new System.Windows.Forms.Button();
            this.btnCreatePosts = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewPosts
            // 
            this.btnViewPosts.AutoSize = true;
            this.btnViewPosts.Location = new System.Drawing.Point(182, 135);
            this.btnViewPosts.Name = "btnViewPosts";
            this.btnViewPosts.Size = new System.Drawing.Size(86, 27);
            this.btnViewPosts.TabIndex = 0;
            this.btnViewPosts.Text = "View Posts";
            this.btnViewPosts.UseVisualStyleBackColor = true;
            this.btnViewPosts.Click += new System.EventHandler(this.btnViewPosts_Click);
            // 
            // btnCreatePosts
            // 
            this.btnCreatePosts.AutoSize = true;
            this.btnCreatePosts.Location = new System.Drawing.Point(506, 135);
            this.btnCreatePosts.Name = "btnCreatePosts";
            this.btnCreatePosts.Size = new System.Drawing.Size(99, 27);
            this.btnCreatePosts.TabIndex = 2;
            this.btnCreatePosts.Text = "Create Posts";
            this.btnCreatePosts.UseVisualStyleBackColor = true;
            this.btnCreatePosts.Click += new System.EventHandler(this.btnCreatePosts_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnViewPosts);
            this.panel1.Controls.Add(this.btnCreatePosts);
            this.panel1.Location = new System.Drawing.Point(2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 451);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.BackColor = System.Drawing.Color.FromArgb(0, 158, 161);
            //this.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewPosts;
        private System.Windows.Forms.Button btnCreatePosts;
        private System.Windows.Forms.Panel panel1;
    }
}

